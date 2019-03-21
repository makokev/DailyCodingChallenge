using System;
using System.Collections.Generic;

namespace DailyCodingChallenge.Problems
{
	class Problem063 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM063_DESCRIPTION;
		protected override int Number => 63;

		protected override void Run()
		{
			List<List<char>> charMatrix = new List<List<char>> { new List<char>{ 'F', 'A', 'C', 'I'},
																 new List<char>{ 'O', 'B', 'Q', 'P'},
																 new List<char>{ 'A', 'N', 'O', 'B'},
																 new List<char>{ 'M', 'A', 'S', 'S'}
															   };

			string target = "FOAM";

			List<string> stringMatrix = new List<string>();

			// rows
			foreach (List<char> row in charMatrix)
			{
				string word = "";
				foreach (char c in row)
					word += c;
				stringMatrix.Add(word);
			}

			// cols
			for(int i = 0; i < charMatrix[0].Count; i++)
			{
				string word = "";
				foreach (List<char> row in charMatrix)
					word += row[i];
				stringMatrix.Add(word);
			}

			Console.WriteLine("THe charMatrinx contains the target word '{0}'? {1}", target, stringMatrix.Contains(target));
		}
	}
}
