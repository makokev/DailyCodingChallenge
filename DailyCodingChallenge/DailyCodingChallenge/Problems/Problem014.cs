﻿using System;

namespace DailyCodingChallenge.Problems
{
	class Problem014 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM014_DESCRIPTION;
		protected override int Number => 14;

		protected override void Run()
		{
			double pi_value = Math.Truncate(Math.PI * 1000) / 1000;
			Console.WriteLine("Truncate PI value = " + pi_value);

			Random r = new Random();
			double x, y, extimated_pi, count_centered = 0.0;
			bool correctResult = false;
			int iteration = 0;
			do
			{
				iteration++;
				x = r.NextDouble();
				y = r.NextDouble();
				if (x*x + y*y < 1.0)
					count_centered++;
				extimated_pi = 4 * count_centered / iteration;
				correctResult = (extimated_pi >= pi_value && extimated_pi < pi_value + 0.001);
			} while (!correctResult);

			Console.WriteLine("Extimated PI = " + extimated_pi);
			Console.WriteLine("Number of iterations required: " + iteration);
		}
	}
}
