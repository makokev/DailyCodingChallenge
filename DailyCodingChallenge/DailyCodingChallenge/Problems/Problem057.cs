using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem057 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM057_DESCRIPTION;
		protected override int Number => 57;

		protected override void Run()
		{
			const string INPUT_STRING = "If you wanna be my lover, you gotta get with my friends";
			const int K = 7;

			List<string> segments = SubdividePhraseIntoSegments(INPUT_STRING, K);

			Console.WriteLine("Process Success: {0}.", (null != segments));
			if(null != segments)
				Console.WriteLine("Printing segments: {0}.", segments.Print());
		}

		private List<string> SubdividePhraseIntoSegments(string phrase, int maxSegmentLenght)
		{
			List<string> list = new List<string>();

			string[] words = phrase.Split(' ');
			// first scan: if word.Length > max --> fail
			foreach (string word in words)
				if (word.Length > maxSegmentLenght)
					return null;

			// second scan: contatenating segments since it is possible
			string segment = "";
			foreach (string word in words)
			{
				if(segment.Length + word.Length + 1 <= maxSegmentLenght)
				{
					segment += (segment.Length == 0) ? word : " " + word;
				}
				else
				{
					segment = "'" + segment + "'";
					list.Add(segment);
					segment = word;
				}
			}

			// inserting the last word (=segment)
			segment = "'" + segment + "'";
			list.Add(segment);
			return list;
		}
	}
}
