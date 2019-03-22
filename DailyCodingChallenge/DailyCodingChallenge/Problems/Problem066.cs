using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem066 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM066_DESCRIPTION;
		protected override int Number => 66;

		private static Random r = new Random();

		protected override void Run()
		{
			const int tries = 1000000;
			Console.WriteLine("Executing {0} launches.", tries);
			int countZero = 0, countOne = 0;
			for (int i = 0; i < tries; i++)
			{
				if (0 == TossNotBiased())
					countZero++;
				else
					countOne++;
			}
			Console.WriteLine("countZero = {0} ({1}%)", countZero, (countZero*100.0/tries));
			Console.WriteLine("countOne = {0} ({1}%)", countOne, (countOne * 100.0 / tries));
			
		}

		private int TossNotBiased()
		{
			int[] sequence = new int[2] { -1, -1 };
			while(true)
			{
				sequence[0] = TossBiased();
				sequence[1] = TossBiased();
				if (sequence[0] == 0 && sequence[1] == 1)
					return 0;
				else if (sequence[0] == 1 && sequence[1] == 0)
					return 1;
			}
		}

		private int TossBiased() => (r.NextDouble() >= 0.6) ? 1 : 0;
		
	}
}
