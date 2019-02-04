using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem030 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM030_DESCRIPTION;
		protected override int Number => 30;

		protected override void Run()
		{
			int[] wallsHeigths = new int[] { 3, 0, 1, 3, 0, 5 };
			Console.WriteLine("Walls print:");
			int[] counts = (int[])wallsHeigths.Clone();
			int maxHeigth = counts.Max();
			for (int h = 0; h < maxHeigth; h++)
			{
				Console.Write("{0} ", maxHeigth - h);
				foreach (int c in counts)
				{
					if (c >= maxHeigth - h)
						Console.Write("██");
					else
						Console.Write("  ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
			Console.WriteLine("Trapped raining water: {0}.\n", GetTrappedWater(wallsHeigths));
		}

		private int GetTrappedWater(int[] wallsHeigths)
		{
			int l = 0;
			int r = wallsHeigths.Length - 1;
			int l_max = -1, r_max = -1;
			int water = 0;

			while(l < r)
			{
				if(wallsHeigths[l] < wallsHeigths[r])
				{
					if (wallsHeigths[l] >= l_max)
						l_max = wallsHeigths[l];
					else
						water += l_max - wallsHeigths[l];
					l++;
				}
				else
				{
					if (wallsHeigths[r] >= r_max)
						r_max = wallsHeigths[r];
					else
						water += r_max - wallsHeigths[r];
					r--;
				}
			}

			return water;
		}
	}
}
