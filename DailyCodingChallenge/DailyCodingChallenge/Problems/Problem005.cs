using DailyCodingChallenge.Problems.Utility;
using System;


namespace DailyCodingChallenge.Problems
{
	class Problem005 : Problem
	{	
		public Problem005() : base(5, ProblemDescription.PROBLEM005_DESCRIPTION) { }

		protected override void Run()
		{
			Pair<int, int> pair = new Pair<int, int>(3, 4);
			Console.WriteLine("Input: Pair = " + pair.ToString());
			Console.WriteLine("Trying car(cons(3,4)) = 3 ...");
			Console.Write("Result: ");
			if (Pair<int,int>.Car(Pair<int, int>.Cons(3, 4)) == 3)
				Console.WriteLine("Success!");
			else
				Console.WriteLine("Wrong!");
		}
	}
}
