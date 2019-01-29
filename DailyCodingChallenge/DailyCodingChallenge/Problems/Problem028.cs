using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem028 : Problem
	{

		private static string[] words = "La mamma andò al mercato tutta allegra e contenta.".Split(' ');
		private static int size = 20;

		public Problem028() : base(28, ProblemDescription.PROBLEM028_DESCRIPTION) {	}

		protected override void Run()
		{
			Console.WriteLine("Words' list: {0}.", words.ToList().AsString());
			Console.WriteLine("Line size: {0}", size);

			List<string> lines = GiustifyText(words, size);
			Console.WriteLine("Lines:");
			foreach (string line in lines)
				Console.WriteLine("{0}|", line);
		}

		private List<string> GiustifyText(string[] words, int size) {
			List<List<string>> linesWords = new List<List<string>>();
			List<string> currentLine = new List<string>();
			foreach (string word in words)
			{
				if (CharCount(currentLine) + currentLine.Count + word.Length <= size)
					currentLine.Add(word);
				else
				{
					linesWords.Add(currentLine);
					currentLine = new List<string>();
					currentLine.Add(word);
				}
			}
			linesWords.Add(currentLine);

			List<string> lines = new List<string>();
			foreach (List<string> lineWords in linesWords)
			{
				int paddingWhite = size - CharCount(lineWords);
				int remainingWords = lineWords.Count;
				int maxWhite;
				StringBuilder sb = new StringBuilder();
				foreach (string word in lineWords)
				{
					maxWhite = (int)Math.Ceiling((decimal)paddingWhite / remainingWords);
					sb.Append(word);
					if(paddingWhite > 0)
					{
						int whiteCount = (paddingWhite >= maxWhite) ? maxWhite : paddingWhite;
						for(int i = 0; i < whiteCount; i++)
							sb.Append(" ");
						paddingWhite -= whiteCount;
					}
					remainingWords--;
				}
				lines.Add(sb.ToString());
			}
			return lines;
		}

		private int CharCount(List<string> list) {
			int count = 0;
			foreach (string s in list)
				count += s.Length;
			return count;
		}
	}
}
