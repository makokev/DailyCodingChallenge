using DailyCodingChallenge.Problems.Utility;
using System;

namespace DailyCodingChallenge.Problems
{
	class Problem008 : Problem
	{
		public Problem008() : base(8, ProblemDescription.PROBLEM008_DESCRIPTION) { }

		protected override void Run()
		{
			Node<int> root = new Node<int>(0, new Node<int>(1), new Node<int>(0, new Node<int>(1, new Node<int>(1), new Node<int>(1)), new Node<int>(0)));
			root.PrintTree();
			Console.Write("Result: ");
			Console.WriteLine("Number of Universal Subtree = " + CountUniversalSubtree(root));
			
		}

		private bool IsUniversalTree(Node<int> root)
		{
			int childrenCount = root.ChildrenCount();
			if (0 == childrenCount)
				return true;
			if (1 == childrenCount)
				return (IsUniversalTree(root.Left) && root.Val.Equals(root.Left.Val));
			else
				return (IsUniversalTree(root.Left) && 
					IsUniversalTree(root.Right) && 
					root.Val.Equals(root.Left.Val) && 
					root.Val.Equals(root.Right.Val));
		}

		private int CountUniversalSubtree(Node<int> root) {
			int count = 0;

			if (1 == root.ChildrenCount())
			{
				count = CountUniversalSubtree(root.Left);
			}
			else if(2 == root.ChildrenCount())
			{
				count  = CountUniversalSubtree(root.Left);
				count += CountUniversalSubtree(root.Right);
			}

			if (IsUniversalTree(root))
				count ++;
			return count;
		}
	}

	
}
