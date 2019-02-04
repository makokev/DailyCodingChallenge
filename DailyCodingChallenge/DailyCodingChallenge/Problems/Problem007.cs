using System;
using System.Collections.Generic;

namespace DailyCodingChallenge.Problems
{
	class Problem007 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM007_DESCRIPTION;
		protected override int Number => 7;

		#region Static region

		private static Dictionary<string, char> dictionary;

		static Problem007()
		{
			dictionary = new Dictionary<string, char>();
			char c = 'a';
			for (int i = 1; i <= 26; i++)
			{
				dictionary.Add("" + i, c);
				c = (char)(c + 1);
			}
		}

		#endregion

		#region Input

		private static string numericString = "77";
		
		#endregion
				
		protected override void Run()
		{
			Console.WriteLine("Input: '" + numericString + "'.");

			int numberOfTranslations = Translate(numericString);

			Console.WriteLine("Number of different translations: " + numberOfTranslations);
		}

		private int Translate(string text) {
			if (0 == text.Length)
				return 1;
			if (1 == text.Length)
			{
				if (dictionary.ContainsKey(text))
					return 1;
				else
					return 0;
			}
			else
			{
				int num = 0;
				if (dictionary.ContainsKey(text[0].ToString()))
					num += Translate(text.Substring(1));
				
				if (dictionary.ContainsKey(text.Substring(0, 2)))
					num += Translate(text.Substring(2));
				
				return num;
			}
		}
	}
}
