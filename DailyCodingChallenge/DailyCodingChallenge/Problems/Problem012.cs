using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem012 : Problem
	{
		private readonly List<int> STEPS = new List<int>();

		public Problem012() : base(12, ProblemDescription.PROBLEM012_DESCRIPTION) { }

		protected override void Run()
		{
			Console.Write("Insert the starcase length: ");
			if (!int.TryParse(Console.ReadLine(), out int staircaseLength))
			{
				Console.WriteLine("Input Error: Number format exception.");
				return;
			}

			while (true)
			{
				Console.Write("Insert a step length (to exit: 0):");
				if (int.TryParse(Console.ReadLine(), out int step))
				{
					if (step > 0)
						STEPS.Add(step);
					else
						break;
				}
			}
			Console.Write("\nInserted steps: ");
			for (int i = 0; i < STEPS.Count; i++)
			{
				if (0 == i)
					Console.Write("[" + STEPS[i]);
				else
					Console.Write(", " + STEPS[i]);
			}
			Console.WriteLine("]");

			Console.WriteLine("\nNumber of unique ways: " + CountStep(staircaseLength));
		}

		private int CountStep(int remainingStairs)
		{
			int count = 0;
			foreach(int step in STEPS)
			{
				if (step == remainingStairs)
					count++;
				if (step < remainingStairs)
					count += CountStep(remainingStairs - step);
			}
			return count;
		}
	}
}
