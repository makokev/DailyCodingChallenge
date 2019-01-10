using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems.Utility
{
	class AutocompleteSystem
	{
		private AutocompleteNode _root;

		public AutocompleteSystem()
		{
			_root = new AutocompleteNode('\0', "");
		}

		public void Add(string word)
		{
			AutocompleteNode currentNode = _root;
			foreach(char c in word)
			{
				if (currentNode.Children.ContainsKey(c))
				{
					currentNode = currentNode.Children[c];
				}
				else
				{
					currentNode.Children.Add(c, new AutocompleteNode(c, currentNode.Word + c));
					currentNode = currentNode.Children[c];
				}
			}
			if(!currentNode.Children.ContainsKey('\0'))
				currentNode.Children.Add('\0', new AutocompleteNode('\0', currentNode.Word));
		}

		public List<string> FindWordByPrefix(string prefix)
		{
			List<string> list = new List<string>();
			AutocompleteNode currentNode = _root;
			bool prefixFounded = true;
			foreach(char c in prefix)
			{
				if (currentNode.Children.ContainsKey(c))
					currentNode = currentNode.Children[c];
				else
					prefixFounded = false; ;
			}
			if (prefixFounded)
			{
				list.AddRange(GetWords(currentNode));
			}
			return list;
		}

		private List<string> GetWords(AutocompleteNode root)
		{
			List<string> list = new List<string>();
			AutocompleteNode currentNode = root;
			foreach(AutocompleteNode node in currentNode.Children.Values)
			{
				if (node.IsLeaf)
					list.Add(node.Word);
				else
					list.AddRange(GetWords(node));
			}
			return list;
		}

	}

	class AutocompleteNode
	{
		private char _letter;
		private string _word;
		private readonly Dictionary<char, AutocompleteNode> _children;

		public AutocompleteNode(char letter, string word)
		{
			_letter = letter;
			_word = word;
			_children = new Dictionary<char, AutocompleteNode>();
		}

		public Dictionary<char, AutocompleteNode> Children => _children;
		public string Word => _word;
		public char Letter => _letter;
		public bool IsLeaf => _letter == '\0';
	}
}
