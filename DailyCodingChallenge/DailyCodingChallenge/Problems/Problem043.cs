using DailyCodingChallenge.Utility;
using System;

namespace DailyCodingChallenge.Problems
{
	class Problem043 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM043_DESCRIPTION;
		protected override int Number => 43;

		protected override void Run()
		{
			MaxStack<int> stack = new MaxStack<int>();
			stack.Push(5);
			stack.Push(3);
			stack.Push(18);
			Console.WriteLine("Assert max = 18: {0}.", stack.Max() == 18);
			int value = stack.Pop();
			Console.WriteLine("Assert pop = 18: {0}.", value == 18);
			Console.WriteLine("Assert max = 5: {0}.", stack.Max() == 5);
		}
	}
}
