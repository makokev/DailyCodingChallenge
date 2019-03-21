using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingChallenge.Problems
{
	class Problem009 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM009_DESCRIPTION;
		protected override int Number => 9;

		#region Input

		private static int[] numbers = new int[]{ 5,-11,-3,1,-5 };

		#endregion
		
		protected override void Run()
		{
			List<int> list = numbers.ToList();
			Console.WriteLine("Input: " + list.Print());
			Console.WriteLine("Result: Largest sum = " + LargestSum(numbers));
		}

		private int LargestSum(int[] numbers)
		{
			int sum = 0;
			List<int> list = numbers.ToList();
			while(list.Count >= 3)
			{
				if (list[2] + list[0] >= list[1])
				{
					if (list[0] > 0)
					{
						sum += list[0];
						list.RemoveAt(0);
					}
				}
				else
				{
					if (list[1] > 0)
					{
						sum += list[1];
						list.RemoveAt(0);
						list.RemoveAt(0);
					}
					else if(list[0] > 0)
					{
						sum += list[0];
						list.RemoveAt(0);
					}
				}
				list.RemoveAt(0);
			}
			if (1 == list.Count)
				sum += list[0];
			else if (2 == list.Count)
			{
				if (list[0] >= list[1] && list[0] > 0)
					sum += list[0];
				else if(list[1] > 0)
					sum += list[1];
			}

			return sum;
		}

	}
}
