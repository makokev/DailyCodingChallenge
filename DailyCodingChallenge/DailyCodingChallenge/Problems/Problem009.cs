using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem009 : Problem
	{

		#region Input

		private static int[] numbers = new int[]{ 5,-11,-3,1,-5 };

		#endregion

		public Problem009() : base(9, ProblemDescription.PROBLEM009_DESCRIPTION) { }

		public override void run()
		{
			Console.WriteLine(this.ToString());
			Console.WriteLine(this.PrintDescription() + "\n");
			List<int> list = numbers.ToList();
			Console.Write("Input: [");
			for (int i = 0; i < list.Count; i++)
			{
				if (0 == i)
					Console.Write(list[i]);
				else
					Console.Write(", " + list[i]);
			}
			Console.WriteLine("]");

			Console.WriteLine("Result: Largest sum = " + LargestSum(numbers));
		}

		public int LargestSum(int[] numbers)
		{
			int sum = 0;
			List<int> list = numbers.ToList();
			while(list.Count >= 3)
			{
				if (list[2] + list[0] >= list[1])
				{
					if (list[0] > 0)
					{
						sum += list[0];
						list.RemoveAt(0);
					}
				}
				else
				{
					if (list[1] > 0)
					{
						sum += list[1];
						list.RemoveAt(0);
						list.RemoveAt(0);
					}
					else if(list[0] > 0)
					{
						sum += list[0];
						list.RemoveAt(0);
					}
				}
				list.RemoveAt(0);
			}
			if (1 == list.Count)
				sum += list[0];
			else if (2 == list.Count)
			{
				if (list[0] >= list[1] && list[0] > 0)
					sum += list[0];
				else if(list[1] > 0)
					sum += list[1];
			}

			return sum;
		}

	}
}
