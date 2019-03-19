using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem061 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM061_DESCRIPTION;
		protected override int Number => 61;

		protected override void Run()
		{
			int baseNumber = 0, powerNumber = 0;
			do
			{
				Console.Write("Insert the base: ");
			}
			while (!int.TryParse(Console.ReadLine(), out baseNumber));

			do
			{
				Console.Write("Insert the power: ");
			}
			while (!int.TryParse(Console.ReadLine(), out powerNumber));

			int result = Pow(baseNumber, powerNumber);
			Console.WriteLine("{0}^{1} = {2}", baseNumber, powerNumber, result);

		}

		private int Pow(int baseNumber, int powerNumber)
		{
			if (powerNumber == 0)
				return 1;
			else if (powerNumber % 2 == 1)
				return baseNumber * Pow(baseNumber, powerNumber - 1);
			else
			{
				int partial = Pow(baseNumber, powerNumber / 2);
				return partial * partial;
			}
		}
	}
}
