using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem015 : Problem
	{
		private static List<string> STREAM = new List<string> {"string1", "string2", "string3", "string4", "string5" };

		public Problem015() : base(15, ProblemDescription.PROBLEM015_DESCRIPTION){ }

		private double ConvertToPercentage(double value) => Math.Truncate(value * 10000) / 100;

		public override void run()
		{
			Console.WriteLine(this.ToString());
			Console.WriteLine(this.PrintDescription() + "\n");

			Random r = new Random();

			string chosen_string = "";
			double probability = 0.0, p;
			foreach(string s in STREAM)
			{
				p = r.NextDouble();
				Console.WriteLine("String: '" + s + "' with p:" + ConvertToPercentage(p) + "%.");
				if(p > probability)
				{
					probability = p;
					chosen_string = s;
				}
			}
			Console.WriteLine("Chosen string: '" + chosen_string + "'.");
			Console.WriteLine("Probability: " + ConvertToPercentage(probability) + "%.");
		}
	}
}
