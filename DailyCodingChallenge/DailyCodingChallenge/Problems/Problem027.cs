using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem027 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM027_DESCRIPTION;
		protected override int Number => 27;

		protected override void Run()
		{
			Console.Write("Insert text: ");
			string text = Console.ReadLine().Trim();
			Console.WriteLine("Inserted text: '"+text+"'");
			Console.WriteLine("Check parentesis: "+CheckParentesis(text));
		}

		private bool CheckParentesis(string text) {
			Node<char> root = new Node<char>('\0');
			Node<char> currentNode = root;
			Node<char> node;
			foreach (char c in text.ToArray()) {
				switch (c) {
					case '{':
						node = new Node<char>('{');
						currentNode.AddChild(node);
						currentNode = node;
						break;
					case '[':
						node = new Node<char>('[');
						currentNode.AddChild(node);
						currentNode = node;
						break;
					case '(':
						node = new Node<char>('(');
						currentNode.AddChild(node);
						currentNode = node;
						break;
					case '}':
						if (currentNode.Value == '{')
							currentNode = currentNode.ParentNode;
						else
							return false;
						break;
					case ']':
						if (currentNode.Value == '[')
							currentNode = currentNode.ParentNode;
						else
							return false;
						break;
					case ')':
						if (currentNode.Value == '(')
							currentNode = currentNode.ParentNode;
						else
							return false;
						break;
					default:
						Console.WriteLine("Only parentesis admitted: '{', '}', '[', ']', '(', ')'.");
						return false;
				}
			}
			return currentNode == root;

		}
	}
}
