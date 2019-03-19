using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem062 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM062_DESCRIPTION;
		protected override int Number => 62;

		protected override void Run()
		{
			int m = 0, n = 0;
			do
			{
				Console.Write("Insert m: ");
			}
			while (!int.TryParse(Console.ReadLine(), out m));

			do
			{
				Console.Write("Insert n: ");
			}
			while (!int.TryParse(Console.ReadLine(), out n));

			Console.WriteLine("In a {0}x{1} matrix the path count is: {2}", m, n, CountPath(m,n));

		}

		private int CountPath(int m, int n)
		{
			if (m == 1 || n == 1)
				return 1;
			return CountPath(m, n - 1) + CountPath(m - 1, n);
		}
	}
}
