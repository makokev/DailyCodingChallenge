using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem024 : Problem
	{
		public Problem024() : base(24, ProblemDescription.PROBLEM024_DESCRIPTION) { }

		protected override void Run()
		{
			BinaryLockableNode<int> root = new BinaryLockableNode<int>(0, new BinaryLockableNode<int>(1, new BinaryLockableNode<int>(2)), new BinaryLockableNode<int>(1));
			root.PrintTree();
			Console.WriteLine("root.Left.Lock() = "+root.Left.Lock());
			root.PrintTree();
			Console.WriteLine("root.Lock() = " + root.Lock());
			root.PrintTree();
			Console.WriteLine("root.Right.Lock() = " + root.Right.Lock());
			root.PrintTree();
			Console.WriteLine("root.Left.Unlock() = " + root.Left.Unlock());
			root.PrintTree();
			Console.WriteLine("root.Left.Left.Lock() = " + root.Left.Left.Lock());
			root.PrintTree();
		}
	}
}
