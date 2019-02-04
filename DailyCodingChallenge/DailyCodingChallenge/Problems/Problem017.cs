using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem017 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM017_DESCRIPTION;
		protected override int Number => 17;

		#region Static region

		private static string FILESYSTEM = "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext";

		#endregion

		protected override void Run()
		{
			Node<string> root = GenerateTree(FILESYSTEM);
			root.Children.Add(new Node<string>("muahahaha ho aggiunto un nodo a mano"));
			root.PrintTree(); // a nice view representation
			string longestFilePath = GetLongestFilePath(root);
			Console.WriteLine("The longest file path: '" + longestFilePath + "'.");
			Console.WriteLine("The lenght is: " + longestFilePath.Length + ".");

		}

		/// <summary>
		/// Transform the filesystem from string to tree representation.<para/>
		/// Example: root\n\tsubfolder1\n\t\tfile1.exe\n\tsubfolder2\n\t\tfile3.exe
		/// </summary>
		/// <param name="filesystem">string representation of the filesystem</param>
		/// <param name="levelSeparator">separator between levels (folder >> subfolder)</param>
		/// <param name="childSeparator">separator between children of a folder (child1 - child2)</param>
		/// <returns></returns>
		private Node<string> GenerateTree(string filesystem, char levelSeparator = '\n', char childSeparator = '\t')
		{
			int tabCount = 0;
			Node<string> root = null, currentNode = null;
			foreach (string piece in filesystem.Split(levelSeparator))
			{
				if (null == currentNode)
				{
					root = new Node<string>(piece);
					currentNode = root;
					tabCount++;
				}
				else
				{
					int tabs = 0;
					string pieceValue = piece;
					while (pieceValue.StartsWith(""+childSeparator))
					{
						tabs++;
						pieceValue = pieceValue.Substring(1);
					}
					if (tabs > tabCount)
					{
						currentNode = currentNode.Children[currentNode.ChildrenCount - 1];
						tabCount++;
					}
					else if (tabs < tabCount)
					{
						currentNode = currentNode.ParentNode;
						tabCount--;
					}
					currentNode.AddChild(new Node<string>(pieceValue));
				}
			}
			return root;
		}

		/// <summary>
		/// return the longest file path starting from the current node (the path arrives until the real root).
		/// </summary>
		/// <param name="root"></param>
		/// <param name="maxDeepestFile"></param>
		/// <returns></returns>
		private string GetLongestFilePath(Node<string> root, string maxDeepestFile = "")
		{
			string deepestFile = "";
			string path;
			foreach (Node<string> child in root.Children)
			{
				if (IsFile(child))
					path = GetCompletePath(child);
				else
					path = GetLongestFilePath(child, deepestFile);
				if (path.Length > deepestFile.Length)
					deepestFile = path;
			}

			return deepestFile;
		}

		// return the complete path, formed by concatenation of the current value and all ancestor nodes' values.
		private string GetCompletePath(Node<string> node) {
			string path = node.Value;
			while (null != node.ParentNode)
			{
				node = node.ParentNode;
				path = node.Value + "/" + path;
			}

			return path;
		}

		// test if the node is a file: contains a period, an extension and have no children.
		private bool IsFile(Node<string> node)
		{
			return	node.IsLeaf &&
					node.Value.Contains(".") &&
					!node.Value.EndsWith("."); // have an extension
		}
	}
}
