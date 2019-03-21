using DailyCodingChallenge.Problems.Utility;
using System;

namespace DailyCodingChallenge.Problems
{
	class Problem010 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM010_DESCRIPTION;
		protected override int Number => 10;

		protected override void Run()
		{
			JobScheduler jobScheduler = new JobScheduler(5000, MyJob);
			Console.WriteLine("JobScheduler prepared.");
			jobScheduler.Start();
			Console.WriteLine("JobScheduler started.");

		}

		private static void MyJob()
		{
			Console.WriteLine("My Job executed!");
		}
	}
}
