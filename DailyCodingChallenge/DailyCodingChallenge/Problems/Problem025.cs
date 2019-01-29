using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem025 : Problem
	{
		public Problem025() : base(25, ProblemDescription.PROBLEM025_DESCRIPTION) {	}

		protected override void Run()
		{
			Console.Write("Insert regex expression: ");
			string regex = Console.ReadLine().Trim();
			Console.Write("Insert text: ");
			string text = Console.ReadLine().Trim();
			Console.WriteLine("Regex: '" + regex + "'");
			Console.WriteLine("Text: '" + text + "'");
		
			Console.WriteLine("Result: " + CheckRegex(regex, text));
		}

		private bool CheckRegex(string regex, string text) {
			if (regex.Length == 0 && text.Length == 0)
				return true;

			if ((regex.Length != 0 && text.Length == 0) || (regex.Length == 0 && text.Length != 0))
				return false;

			if (regex.StartsWith("*")) {
				if (regex.Length > 1)
				{
					bool result = false;
					for(int i = 1; i < text.Length && !result; i++)
					{
						if (CheckRegex(regex.Substring(1), text.Substring(i)))
							result = true;
					}
					return result;
				}
				else
					return true;
			}

			if (regex.ElementAt(0) == text.ElementAt(0) || regex.StartsWith("."))
				return CheckRegex(regex.Substring(1), text.Substring(1));

			return false;
		}
	}
}
