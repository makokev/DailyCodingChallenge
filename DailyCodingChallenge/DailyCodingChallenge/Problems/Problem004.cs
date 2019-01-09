using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem004 : Problem
	{
		#region Input

		private int[] values = new int[] { 3, 4, -1, 1, 2, 6 };

		#endregion

		public Problem004() : base(4, ProblemDescription.PROBLEM004_DESCRIPTION){ }

		public override void run()
		{
			Console.WriteLine(this.ToString());
			Console.WriteLine(this.PrintDescription() + "\n");

			List<int> list = values.ToList();
			Console.Write("Input: [");
			for (int i = 0; i < list.Count; i++)
			{
				if (0 == i)
					Console.Write(list[i]);
				else
					Console.Write(", " + list[i]);
			}
			Console.WriteLine("]");

			int minMissing = (list.Count > 0) ? 1 : int.MinValue;

			while (list.Count > 0)
			{
				int actualMin = list.Min();
				if (minMissing == actualMin)
					minMissing++;
				else if (actualMin > minMissing)
					break;
				list.Remove(actualMin);
			}

			if (minMissing != int.MinValue)
				Console.WriteLine("Minimum missing integer value: " + minMissing);
			else
				Console.WriteLine("The list is empty.");

		}
	}
}
