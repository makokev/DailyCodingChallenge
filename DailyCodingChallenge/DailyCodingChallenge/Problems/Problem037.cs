using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem037 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM037_DESCRIPTION;
		protected override int Number => 37;

		protected override void Run()
		{
			List<int> set = new List<int>() { 1, 2, 3 };
			List<List<int>> subsets = GenerateAllSubsetOf(set);
			int count = 0;
			foreach (List<int> subset in subsets)
			{
				Console.WriteLine("Subset {0}: {1}", count, subset.AsString());
				count++;
			}
		}

		private List<List<int>> GenerateAllSubsetOf(List<int> set)
		{
			return GenerateSubsetsRecoursively(set, new List<List<int>>());
		}

		private List<List<int>> GenerateSubsetsRecoursively(List<int> set, List<List<int>> subsets)
		{
			if (set.Count != 0)
			{
				List<List<int>> subs = new List<List<int>>();
				if (subsets.Count == 0)
				{
					subs.Add(new List<int>());
					subs.Add(new List<int>() { set[0] });
				}
				else
				{
					foreach (List<int> sub in subsets)
					{
						List<int> newSub = sub.ToList();
						newSub.Add(set[0]);
						subs.Add(newSub);
					}
				}
				set.RemoveAt(0);
				subsets.AddRange(subs);
				return GenerateSubsetsRecoursively(set, subsets);
			}
			return subsets;
		}
	}
}
