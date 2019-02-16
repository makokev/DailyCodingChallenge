using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem046 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM046_DESCRIPTION;
		protected override int Number => 46;

		protected override void Run()
		{
			Console.Write("Insert the string: ");
			string inputString = Console.ReadLine().Trim();

			bool found = false;
			string palindromicSubstring = "";
			
			for(int i = inputString.Length; i > 0 && !found; i--)
			{
				foreach(string sub in inputString.GetAllSubstrings(i))
				{
					if(sub.IsPalindrome())
					{
						palindromicSubstring = sub;
						found = true;
						break;
					}
				}
			}
			if (found)
				Console.WriteLine("Max palindromic substring of '{0}' is '{1}' (of length {2}).", inputString, palindromicSubstring, palindromicSubstring.Length);
			else
				Console.WriteLine("No palindromic substring founded.");
		}
	}
}
