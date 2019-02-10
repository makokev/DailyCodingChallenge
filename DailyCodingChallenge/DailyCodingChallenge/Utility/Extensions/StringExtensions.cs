using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems.Utility
{
	public static class StringExtensions
	{
		public static string Giustify(this string text, int lineSize, int whitePercentage = 70) {
			StringBuilder sb = new StringBuilder();
			
			List<string> lines = text.Trim().Split('\n').ToList();

			List<string> gustifiedLines = new List<string>();
			foreach (string line in lines) {
				if (line.Length > lineSize*(whitePercentage/100))
					gustifiedLines.AddRange(GiustifyLine(line, lineSize));
				else
					gustifiedLines.Add(line);
			}

			StringBuilder builder = new StringBuilder();
			foreach (string giustifiedLine in gustifiedLines)
				builder.AppendLine(giustifiedLine);

			return builder.ToString();
		}

		public static string Reverse(this string text)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = text.Length - 1; i >= 0; i--)
				sb.Append(text[i]);
			return sb.ToString();
		}

		private static List<string> GiustifyLine(string line, int lineSize, int whitePercentage = 70)
		{
			List<string> lines = new List<string>();

			List<List<string>> linesWords = new List<List<string>>();
			List<string> currentLine = new List<string>();
			foreach (string word in line.Split(' '))
			{
				if (CharCount(currentLine) + currentLine.Count + word.Length <= lineSize)
					currentLine.Add(word);
				else
				{
					linesWords.Add(currentLine);
					currentLine = new List<string> { word };
				}
			}
			linesWords.Add(currentLine);

			foreach (List<string> words in linesWords)
			{
				int paddingWhite = lineSize - CharCount(words);
				int remainingWords = words.Count;
				int maxWhite;
				StringBuilder sb = new StringBuilder();
				foreach (string word in words)
				{
					maxWhite = (CharCount(words) >= lineSize * whitePercentage / 100) ? (int)Math.Ceiling((decimal)paddingWhite / remainingWords) : 1;
					sb.Append(word);
					if (paddingWhite > 0)
					{
						int whiteCount = (paddingWhite >= maxWhite) ? maxWhite : paddingWhite;
						for (int i = 0; i < whiteCount; i++)
							sb.Append(" ");
						paddingWhite -= whiteCount;
					}
					remainingWords--;
				}
				lines.Add(sb.ToString());
			}

			return lines;
		}

		private static int CharCount(List<string> list)
		{
			int count = 0;
			foreach (string s in list)
				count += s.Length;
			return count;
		}

	}
}
