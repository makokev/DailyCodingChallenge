using DailyCodingChallenge.Problems.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem049 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM049_DESCRIPTION;
		protected override int Number => 49;

		protected override void Run()
		{
			int[] numbers = new int[] { 34, -50, 42, 14, -5, 86 };
			Console.WriteLine("Input numbers: {0}.", numbers.Print());

			int maxContiguousSum = GetContiguousSum(numbers);
			Console.WriteLine("Max contiguous sum: {0}.", maxContiguousSum);
		}

		private int GetContiguousSum(int[] numbers)
		{
			int maxSum = 0;
			int currentSum = 0;
			foreach(int num in numbers)
			{
				currentSum += num;
				if (currentSum < 0)
					currentSum = 0;
				if (currentSum > maxSum)
					maxSum = currentSum;
			}
			return maxSum;
		}
	}
}
