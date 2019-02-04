using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem016 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM016_DESCRIPTION;
		protected override int Number => 16;

		protected override void Run()
		{
			IdLogger logger = new IdLogger(3);
			logger.Record("A");
			logger.Record("B");
			logger.Record("C");
			logger.Record("D");

			Console.WriteLine("Logger[0] = " + logger.GetLast(1));
			Console.WriteLine("Logger[1] = " + logger.GetLast(2));
			Console.WriteLine("Logger[2] = " + logger.GetLast(3));
			Console.WriteLine("Logger[3] = " + logger.GetLast(4));
		}
	}
}
