using System;
using System.Collections.Generic;
using System.Linq;
namespace DailyCodingChallenge.Problems
{
	class Problem019 : Problem
	{
		private static int N = 3;
		private static int K = 3;
		private static int[] COLORS = new int[] { 0, 1, 2 };
		private static int[,] COSTS = new int[,] { { 2, 1, 2 }, { 2, 1, 1 }, { 2, 1, 1 } };

		public Problem019() : base(19, ProblemDescription.PROBLEM019_DESCRIPTION) { }

		protected override void Run()
		{
			int cost = GetMinCost();
			Console.WriteLine("Minimum cost = " + cost);
		}

		private int GetMinCost()
		{
			return GetRecoursiveMinCost(0, 0, -1);
		}

		private int GetRecoursiveMinCost(int house, int partialCost, int previousColor)
		{
			if (house == N)
				return partialCost;
			else
			{
				int minCost = int.MaxValue;
				for(int i = 0; i < COLORS.Length; i++)
				{
					if (COLORS[i] != previousColor)
					{
						int cost = GetRecoursiveMinCost(house + 1, partialCost + COSTS[house, COLORS[i]], COLORS[i]);
						if (cost < minCost)
							minCost = cost;
					}
				}
				return minCost;
			}
		}

	}
}
