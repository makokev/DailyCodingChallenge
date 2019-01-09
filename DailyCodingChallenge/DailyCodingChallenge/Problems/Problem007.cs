using System;
using System.Collections.Generic;

namespace DailyCodingChallenge.Problems
{
	class Problem007 : Problem
	{
		#region Input

		private static string numericString = "77";
		
		#endregion
		
		#region Static region

		private static Dictionary<string, char> dictionary;

		static Problem007()
		{
			dictionary = new Dictionary<string, char>();
			char c = 'a';
			for (int i = 1; i <= 26; i++) {
				dictionary.Add(""+i, c);
				c = (char)(c + 1);
			}
		}

		#endregion

		public Problem007() : base(7, ProblemDescription.PROBLEM007_DESCRIPTION) { }

		public override void run()
		{
			Console.WriteLine(this.ToString());
			Console.WriteLine(this.PrintDescription() + "\n");

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
