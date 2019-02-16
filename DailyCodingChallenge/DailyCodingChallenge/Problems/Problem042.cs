using DailyCodingChallenge.Problems.Utility;
using DailyCodingChallenge.Problems.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem042 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM042_DESCRIPTION;
		protected override int Number => 42;

		protected override void Run()
		{
			int[] numbers = new int[] { 12, 1, 61, 5, 9, 2 };
			int K = 5;

			Console.WriteLine("Input numbers: {0}.", numbers.Print());
			Console.WriteLine("K = {0}.", K);

			List<int> set = GetSubNumbers(numbers, K);
			if (set != null)
				Console.WriteLine("Set with sum {0}: {1}.", K, set.Print());
			else
				Console.WriteLine("No set founded.");
		}

		private List<int> GetSubNumbers(int[] set, int k)
		{
			return GetRecoursiveSubNumbers(set.ToList(), k, new List<int>());
		}

		private List<int> GetRecoursiveSubNumbers(List<int> set, int k, List<int> partialSet)
		{
			if (null == set || null == partialSet)
				return null;
			if (0 == k)
				return partialSet;
			else
			{
				foreach(int n in set)
				{
					if(n <= k)
					{
						List<int> newSet = set.ToList();
						newSet.Remove(n);
						List<int> newPartialSet = partialSet.ToList();
						newPartialSet.Add(n);
						List<int> result = GetRecoursiveSubNumbers(newSet, k - n, newPartialSet);
						if (null != result)
							return result;
					}
				}
				return null;
			}
		}

	}
}
