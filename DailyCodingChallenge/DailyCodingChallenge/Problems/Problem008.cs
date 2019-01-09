using DailyCodingChallenge.Problems.Utility;
using System;

namespace DailyCodingChallenge.Problems
{
	class Problem008 : Problem
	{
		public Problem008() : base(8, ProblemDescription.PROBLEM008_DESCRIPTION) { }

		public override void run()
		{
			Console.WriteLine(this.ToString());
			Console.WriteLine(this.PrintDescription() + "\n");
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
				return (IsUniversalTree(root.left) && root.val.Equals(root.left.val));
			else
				return (IsUniversalTree(root.left) && 
					IsUniversalTree(root.right) && 
					root.val.Equals(root.left.val) && 
					root.val.Equals(root.right.val));
		}

		private int CountUniversalSubtree(Node<int> root) {
			int count = 0;

			if (1 == root.ChildrenCount())
			{
				count = CountUniversalSubtree(root.left);
			}
			else if(2 == root.ChildrenCount())
			{
				count  = CountUniversalSubtree(root.left);
				count += CountUniversalSubtree(root.right);
			}

			if (IsUniversalTree(root))
				count ++;
			return count;
		}
	}

	
}
