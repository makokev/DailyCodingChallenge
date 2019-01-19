
using System;
using System.Collections.Generic;
using System.Linq;
using DailyCodingChallenge.Problems.Utility;
namespace DailyCodingChallenge.Problems
{
	class Problem019 : Problem
	{
		private static int N = 2;
		private static int K = 3;
		private static int[] COLORS = new int[] { 0, 1, 2 };
		

		private static int[,] COSTS = new int[,] { { 1, 2, 2 }, { 2, 1, 1 }, { 2, 2, 1 } };

		public Problem019() : base(19, ProblemDescription.PROBLEM019_DESCRIPTION) { }

		protected override void Run()
		{
			List<int> colorList = COLORS.ToList();
			int cost;
			cost = GetMinCost(colorList);
			Console.WriteLine("Minimum cost = " + cost);
			
		}

		private int GetMinCost(List<int> colors)
		{
			return GetRecoursiveMinCost(0, 0, colors);
			
		}

		private int GetRecoursiveMinCost(int house, int partialCost, List<int> colors)
		{
			if (house == N)
				return partialCost;
			else
			{
				house++;
				int minCost = int.MaxValue;
				for(int i = 0; i < colors.Count; i++)
				{
					List<int> nextColors = colors.ToList();
					nextColors.RemoveAt(i);
					int cost = GetRecoursiveMinCost(house, partialCost + COSTS[house, i], nextColors);
					if(cost < minCost)
					{
						minCost = cost;
					}
				}
				return minCost;
			}
		}

	}
}
