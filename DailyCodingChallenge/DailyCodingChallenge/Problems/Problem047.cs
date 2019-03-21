using DailyCodingChallenge.Problems.Utility;
using DailyCodingChallenge.Problems.Extensions;
using System;

namespace DailyCodingChallenge.Problems
{
	class Problem047 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM047_DESCRIPTION;
		protected override int Number => 47;

		protected override void Run()
		{
			int[] prices = new int[] { 9, 11, 8, 5, 7, 10 };

			Console.WriteLine("Prices: {0}.", prices.Print());

			Couple<int> couple = new Couple<int>(int.MaxValue, int.MinValue);
			int profit = couple.Second - couple.First;
			for(int i = 0; i < prices.Length-1; i++)
			{
				int currentMax = GetMaxFromIndex(prices, i);
				int currentProfit = currentMax - profit;
				if(profit < currentProfit)
				{
					couple = new Couple<int>(prices[i], currentMax);
					profit = couple.Second - couple.First;
				}
			}

			Console.WriteLine("Buying at {0}E and selling at {1}E you can earn a max profit of {2}E.", couple.First, couple.Second, profit);
		}

		private int GetMaxFromIndex(int[] values, int index)
		{
			if (index > values.Length)
				throw new ArgumentOutOfRangeException("index", "0 <= index < values.Length");
			int max = int.MinValue;
			for(int i = index; i < values.Length; i++)
				max = (values[i] > max) ? values[i] : max;
			return max;
		}
	}
}
