using DailyCodingChallenge.Problems.Utility;
using System;

namespace DailyCodingChallenge.Problems
{
	class Problem008 : Problem
	{
		public Problem008() : base(8, ProblemDescription.PROBLEM008_DESCRIPTION) { }

		protected override void Run()
		{
			BinaryNode<int> root = new BinaryNode<int>(0, new BinaryNode<int>(1), new BinaryNode<int>(0, new BinaryNode<int>(1, new BinaryNode<int>(1), new BinaryNode<int>(1)), new BinaryNode<int>(0)));
			root.PrintTree();
			Console.Write("Result: ");
			Console.WriteLine("Number of Universal Subtree = " + CountUniversalSubtree(root));
			
		}

		private bool IsUniversalTree(BinaryNode<int> root)
		{
			int childrenCount = root.ChildrenCount();
			if (0 == childrenCount)
				return true;
			if (1 == childrenCount)
				return (IsUniversalTree(root.Left) && root.Value.Equals(root.Left.Value));
			else
				return (IsUniversalTree(root.Left) && 
					IsUniversalTree(root.Right) && 
					root.Value.Equals(root.Left.Value) && 
					root.Value.Equals(root.Right.Value));
		}

		private int CountUniversalSubtree(BinaryNode<int> root) {
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
