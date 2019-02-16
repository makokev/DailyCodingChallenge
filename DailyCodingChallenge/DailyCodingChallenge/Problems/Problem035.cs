using DailyCodingChallenge.Problems.Utility;
using DailyCodingChallenge.Problems.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem035 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM035_DESCRIPTION;
		protected override int Number => 35;

		protected override void Run()
		{
			char[] chars = new char[] { 'G', 'B', 'R', 'R', 'B', 'R', 'G' };
			Console.WriteLine("Initial vector: {0}.", chars.Print());
			bool ordered = false;
			char temp;
			while (!ordered)
			{
				ordered = true;
				for(int i = 0; i < chars.Length; i++)
				{
					if(chars[i] == 'R' && i != 0 && chars[i - 1] != 'R')
					{
						ordered = false;
						temp = chars[i - 1];
						chars[i - 1] = chars[i];
						chars[i] = temp;
					} else if(chars[i] == 'B' && i != chars.Length - 1 && chars[i+1] != 'B')
					{
						ordered = false;
						temp = chars[i+1];
						chars[i + 1] = chars[i];
						chars[i] = temp;
					}
				}
			}
			Console.WriteLine("Ordered vector: {0}.", chars.Print());
		}
	}
}
