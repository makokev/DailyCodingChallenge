using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem071 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM071_DESCRIPTION;
		protected override int Number => 71;

		private static Random _random = new Random();

		protected override void Run()
		{
			double[] count = new double[5];
			for(int i = 0; i < 10000; i++)
			{
				int r = Rand5();
				count[r-1]++;
			}

			for (int i = 0; i < count.Length; i++)
				Console.WriteLine("count {0} = {1}  ({2}%)", i+1, count[i], count[i]/100.0);
		}

		private int Rand7() => _random.Next(1, 8);

		private int Rand5()
		{
			int r = 0;
			for (int i = 0; i < 5; i++)
				r += Rand7();
			return r % 5 + 1;
		}
	}
}
