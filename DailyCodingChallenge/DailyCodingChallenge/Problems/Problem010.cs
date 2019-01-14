using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem010 : Problem
	{
		public Problem010() : base(10, ProblemDescription.PROBLEM010_DESCRIPTION) { }

		protected override void Run()
		{
			JobScheduler jobScheduler = new JobScheduler(5000, MyJob);
			Console.WriteLine("JobScheduler prepared.");
			jobScheduler.Start();
			Console.WriteLine("JobScheduler started.");

		}
		public static void MyJob()
		{
			Console.WriteLine("My Job executed!");
		}
	}
}
