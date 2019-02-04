using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem013 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM013_DESCRIPTION;
		protected override int Number => 13;

		protected override void Run()
		{
			Console.Write("Insert the number of different characters: ");
			if (!int.TryParse(Console.ReadLine(), out int charNumber))
			{
				Console.WriteLine("Input Error: Number format exception.");
				return;
			}
			Console.Write("Insert the string: ");
			string word = Console.ReadLine();

			int maxLength = GetMaxLength(charNumber, word);
			Console.WriteLine("Max Length = " + maxLength);
		}

		private int GetMaxLength(int maxChar, string word)
		{
			int maxLength = 0;
			int count;
			for(int i = 0; i < word.Length; i++)
			{
				if (word.Substring(i).Length - 1 > maxLength)
				{
					count = CountLength(maxChar, word.Substring(i));
					if (count > maxLength)
						maxLength = count;
				}
			}
			return maxLength;
		}

		private int CountLength(int maxChar, string word)
		{
			int length = 0;
			int countChar = 0;
			List<char> chars = new List<char>();
			foreach (char c in word)
			{
				if (!chars.Contains(c))
				{
					if (countChar < maxChar)
					{
						chars.Add(c);
						countChar++;
					}
					else
						break;
				}
				length++;
			}
			return length;
		}
	}
}
