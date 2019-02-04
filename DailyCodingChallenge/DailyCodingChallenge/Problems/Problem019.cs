using System;
using System.Collections.Generic;
using System.Linq;
namespace DailyCodingChallenge.Problems
{
	class Problem019 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM019_DESCRIPTION;
		protected override int Number => 19;

		#region Static region

		private static int N = 3;
		private static int K = 3;
		private static int[] COLORS = new int[] { 0, 1, 2 };
		private static int[,] COSTS = new int[,] { { 2, 1, 2 }, { 2, 1, 1 }, { 2, 1, 1 } };

		#endregion

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
