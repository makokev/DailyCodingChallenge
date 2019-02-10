using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DailyCodingChallenge.Problems
{
	class Problem004 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM004_DESCRIPTION;
		protected override int Number => 4;
		
		#region Input

		private int[] values = new int[] { 3, 4, -1, 1, 2, 6 };

		#endregion
		
		protected override void Run()
		{
			List<int> list = values.ToList();
			Console.Write("Input: " + list.Print());
			
			int minMissing = (list.Count > 0) ? 1 : int.MinValue;

			while (list.Count > 0)
			{
				int actualMin = list.Min();
				if (minMissing == actualMin)
					minMissing++;
				else if (actualMin > minMissing)
					break;
				list.Remove(actualMin);
			}

			if (minMissing != int.MinValue)
				Console.WriteLine("Minimum missing integer value: " + minMissing);
			else
				Console.WriteLine("The list is empty.");
		}
	}
}
