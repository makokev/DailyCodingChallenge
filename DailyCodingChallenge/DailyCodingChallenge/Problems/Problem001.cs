using System;
using System.Collections.Generic;

namespace DailyCodingChallenge.Problems
{
	public class Problem001 : Problem
	{
		#region Input

		private static int K = 17;
		private static List<int> NUMBERS = new List<int> { 10, 15, 3, 7 };
		
		#endregion

		private List<int> _differences;

		public Problem001() : base(1, ProblemDescription.PROBLEM001_DESCRIPTION)
		{
			_differences = new List<int>();
		}

		override public void run()
		{
			Console.WriteLine(this.ToString());
			Console.WriteLine(this.PrintDescription() + "\n");

			bool founded = false;
			int firstNumber = 0, diff = 0;
			foreach (int number in NUMBERS) //one pass
			{	
				diff = K - number;
				if (_differences.Contains(diff))
				{
					founded = true;
					firstNumber = number;
					break;
				}
				else
					_differences.Add(number);
			}
			Console.WriteLine("Result: " + founded + " (" + firstNumber + " + " + diff + " = " + K + ")");
		}

	}
}