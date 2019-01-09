using System;
using System.Collections.Generic;

namespace DailyCodingChallenge.Problems
{
	public class Problem002 : Problem
	{
		#region Input

		private static List<int> NUMBERS = new List<int> { 1, 2, 3, 4, 5 };

		#endregion

		public Problem002() : base(2, ProblemDescription.PROBLEM002_DESCRIPTION) { }

		override public void run()
		{
			int optionNumber;
			Console.WriteLine(this.ToString());
			Console.WriteLine(this.PrintDescription() + "\n");
			Console.WriteLine("Resolving options:");
			Console.WriteLine("1) No constraint.");
			Console.WriteLine("2) Resolve without using division operator.");
			Console.Write("\nSelect the option number: ");
			try
			{
				optionNumber = Convert.ToInt32(Console.ReadLine());
				if (1 == optionNumber)
					Algorithm1();
				else if (2 == optionNumber)
					Algorithm2();
				else
					Console.WriteLine("Option not correct.");
			}
			catch (Exception)
			{
				Console.WriteLine("Number parsing error. Retry.");
			}
		}

		// No constraint, division operator used: complexity O(n)
		private void Algorithm1() {
			int product = 1;
			foreach (int number in NUMBERS)
				product *= number;

			Console.Write("Result: ");

			for (int i = 0; i < NUMBERS.Count; i++)
			{
				if (0 == i)
					Console.Write("[" + NUMBERS[i]);
				else
					Console.Write(", " + product / NUMBERS[i]);
			}
			Console.WriteLine("]");
		}

		// No division operator used: complexity O(n*n)
		private void Algorithm2()
		{
			int[] products = new int[NUMBERS.Count];
			for (int i = 0; i < products.Length; i++)
				products[i] = 1;
				
			for (int i = 0; i < NUMBERS.Count; i++)
			{
				for(int j = 0; j < NUMBERS.Count; j++)
				{
					if (i != j)
						products[j] *= NUMBERS[i];
				}
			}

			Console.Write("Result: ");

			for (int i = 0; i < NUMBERS.Count; i++)
			{
				if (0 == i)
					Console.Write("[" + products[i]);
				else
					Console.Write(", " + products[i]);
			}
			Console.WriteLine("]");
		}
	}
}