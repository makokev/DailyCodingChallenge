using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem070 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM070_DESCRIPTION;
		protected override int Number => 70;

		protected override void Run()
		{
			int number;
			do
			{
				Console.Write("Insert the number of the element that you want: ");
			}while(!int.TryParse(Console.ReadLine(), out number));

			Console.WriteLine("The {0}-th perfect number is: {1}.", number, GetPerfectNumber(number));
		}

		private int GetPerfectNumber(int number)
		{
			int counter = 0;
			int i = 0;
			if (number <= 0)
				return -1;

			while (i < number)
			{
				if (IsPerfect(counter))
					i++;
				counter++;
			}
			return counter - 1;
		}

		private bool IsPerfect(int counter)
		{
			int sum = 0;
			foreach(char digit in counter.ToString())
			{
				sum += int.Parse(""+digit);
			}
			return sum == 10;
		}
	}
}
