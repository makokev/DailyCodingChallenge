using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem034 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM034_DESCRIPTION;
		protected override int Number => 34;

		protected override void Run()
		{
			/*
			 * 1234
			 * 12341
			 * 123421
			 * 1234321 PAL
			 * 
			 * 1234
			 * 41234
			 * 431234
			 * 4321234 PAL
			 */
			
			Console.Write("Insert the string: ");
			string s = Console.ReadLine().Trim();
			Console.WriteLine("String read: {0}.", s);

			string palindrome = GetFirstPalindrome(s);
			Console.WriteLine("First palindrome (chars added = {0}): {1}.", palindrome.Length - s.Length, palindrome);
		}

		private List<string> GetAllPalindromes(string s)
		{
			List<string> list = new List<string>();
			if (IsPalindrome(s))
				list.Add(s);
			else
			{
				for (int i = 0; i < s.Length / 2; i++)
				{
					if (s[i] != s[s.Length - 1 - i])
					{
						string s1 = s.Insert(i, "" + s[s.Length - 1 - i]);
						string s2 = s.Insert(s.Length - i, "" + s[i]);
						list.AddRange(GetAllPalindromes(s1));
						list.AddRange(GetAllPalindromes(s2));
						return list;
					}
				}
			}
			return list;
		}

		private string GetFirstPalindrome(string s)
		{
			List<string> palindromes = GetAllPalindromes(s);
			string first = "";
			foreach (string p in palindromes)
			{
				if (IsPalindrome(p))
				{
					if ("" == first)
						first = p;
					else if(p.CompareTo(first) < 0)
						first = p;
				}
			}
			return first;
		}

		private bool IsPalindrome(string s)
		{
			for(int i = 0; i < s.Length/2; i++)
			{
				if (s[i] != s[s.Length-1 - i])
					return false;
			}
			return true;
		}
	}
}
