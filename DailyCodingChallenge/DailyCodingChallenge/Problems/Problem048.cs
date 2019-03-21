using DailyCodingChallenge.Problems.Utility;
using System;

namespace DailyCodingChallenge.Problems
{
	class Problem048 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM048_DESCRIPTION;
		protected override int Number => 48;

		protected override void Run()
		{
			char[] preorderedNodes = new char[] { 'a', 'b', 'd', 'e', 'c', 'f', 'g' };
			char[] inorderedNodes  = new char[] { 'd', 'b', 'e', 'a', 'f', 'c', 'g' };

			BinaryNode<char> preorderedTree = BuildPreorderedTree(preorderedNodes);
			BinaryNode<char> inorderedTree = BuildInorderedTree(inorderedNodes);

			Console.WriteLine("Preordered Tree:");
			preorderedTree.PrintTree();

			Console.WriteLine("Inordered Tree:");
			inorderedTree.PrintTree();

			Console.WriteLine("Preordered Tree == Inordered Tree : {0}.", preorderedTree.Equals(inorderedTree));
		}

		private BinaryNode<char> BuildPreorderedTree(char[] nodes)
		{
			BinaryNode<char> root = null;
			if(nodes.Length == 1)
				root = new BinaryNode<char>(nodes[0]);
			else
			{
				int middleIndex = (nodes.Length - 1) / 2; // nodes.Length is always odd (the binary tree is complete!)
				char[] first = new char[middleIndex];
				char[] second = new char[middleIndex];

				for (int i = 1, j = 0; i < nodes.Length; i++, j++)
				{
					if (i < middleIndex)
						first[j] = nodes[i];
					else if (i > middleIndex)
						second[j] = nodes[i];
					else
					{
						first[j] = nodes[i];
						j = -1;
					}
				}

				BinaryNode<char> leftChild = BuildPreorderedTree(first);
				BinaryNode<char> rightChild = BuildPreorderedTree(second);

				root = new BinaryNode<char>(nodes[0], leftChild, rightChild);
			}
				return root;
		}

		private BinaryNode<char> BuildInorderedTree(char[] nodes)
		{
			BinaryNode<char> root = null;
			if(nodes.Length == 1)
				root = new BinaryNode<char>(nodes[0]);
			else
			{
				int middleIndex = (nodes.Length-1)/2; // nodes.Length is always odd (the binary tree is complete!)
				char[] first = new char[middleIndex];
				char[] second = new char[middleIndex];

				for (int i = 0, j = 0; i < nodes.Length; i++, j++)
				{
					if (i < middleIndex)
						first[j] = nodes[i];
					else if (i > middleIndex)
						second[j] = nodes[i];
					else
						j = -1;
				}

				BinaryNode<char> leftChild = BuildInorderedTree(first);
				BinaryNode<char> rightChild = BuildInorderedTree(second);

				root = new BinaryNode<char>(nodes[middleIndex], leftChild, rightChild);
			}
			return root;
		}
	}
}
