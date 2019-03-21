using System;

namespace DailyCodingChallenge.Problems
{
	class Problem045 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM045_DESCRIPTION;
		protected override int Number => 45;

		private static Random _random = new Random();

		protected override void Run()
		{
			int[] count = new int[7];
			for (int i = 0; i < 7; i++)
				count[i] = 0;
			for(int i = 0; i < 10000; i++)
				count[Rand7()-1]++;

			Console.WriteLine("Results:");
			for (int i = 0; i < 7; i++)
				Console.WriteLine("count[{0}] = {1}.", i+1, count[i]);
		}

		private int Rand7()
		{
			int r = 0;
			for (int i = 0; i < 7; i++)
				r += Rand5();
			return r % 7 + 1;
		}
		
		private int Rand5()
		{
			return _random.Next(5) + 1;
		}
	}
}
