using DailyCodingChallenge.Problems.Extensions;
using DailyCodingChallenge.Problems.Utility;
using System;

namespace DailyCodingChallenge.Problems
{
	class Problem051 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM051_DESCRIPTION;
		protected override int Number => 51;

		private static Random random = new Random();
		private int GetRandomFromOneTo(int k) => random.Next(1, k + 1);

		protected override void Run()
		{
			// init
			string[] cards = new string[52];
			for (int i = 0; i < cards.Length; i++)
				cards[i] = "card" + i;

			Console.WriteLine("Initial cards deck: ");
			Console.WriteLine(cards.Print().Justify(100));

			// shuffle
			string temp;
			int randIndex;
			for(int i = 0; i < cards.Length; i++)
			{
				randIndex = GetRandomFromOneTo(cards.Length) - 1;
				temp = cards[randIndex];
				cards[randIndex] = cards[i];
				cards[i] = temp;
			}

			// print out shuffled cards deck
			Console.WriteLine("Shuffled cards deck:");
			Console.WriteLine(cards.Print().Justify(100));
		}
	}
}
