using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingChallenge.Problems
{
	class Problem031 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM031_DESCRIPTION;
		protected override int Number => 31;

		protected override void Run()
		{
			Console.Write("Insert the first string: ");
			string s1 = Console.ReadLine();
			Console.Write("Insert the second string: ");
			string s2 = Console.ReadLine();

			Console.WriteLine("Edit distance between '{0}' and '{1}': {2}.", s1, s2, EditDistance(s1, s2));
		}

		private int EditDistance(string s1, string s2)
		{
			int distance = 0;
			int diffLength = s1.Length - s2.Length;
			
			int absDiffLength = (diffLength > 0) ? diffLength : -diffLength;
			distance += absDiffLength;

			string first, second;
			if(diffLength >= 0)
			{
				first = s1;
				second = s2;
			}
			else
			{
				first = s2;
				second = s1;
			}

			List<string> substrings= AllSubstringsOf(first, absDiffLength);
			int minMatch = int.MaxValue;
			foreach (string s in substrings)
			{
				int c = SubstituteToMatch(s, second);
				if (c < minMatch)
					minMatch = c;
			}
			distance += minMatch;
			return distance;
		}

		private int SubstituteToMatch(string s1, string s2)
		{
			int subs = 0;
			if (s1.Length != s2.Length)
				throw new ArgumentException("Strings' Length are different.");
			for(int i = 0; i < s1.Length; i++)
			{
				if (s1[i] != s2[i])
					subs++;
			}
			return subs;
		}

		private List<string> AllSubstringsOf(string s, int removedChar)
		{
			List<string> substrings = new List<string>();
			substrings.Add(s);
			for(int k = 0; k < removedChar; k++)
			{
				List<string> partialStrings = substrings.ToList();
				substrings.Clear();
				foreach (string str in partialStrings) {
					for (int i = 0; i < str.Length; i++)
					{
						string ss = str.Remove(i, 1);
						if(!substrings.Contains(ss))
							substrings.Add(ss);
					}
				}
			}
			return substrings;
		}
	}
}
