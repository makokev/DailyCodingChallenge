using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem018 : Problem
	{
		public Problem018() : base(18, ProblemDescription.PROBLEM018_DESCRIPTION) { }

		protected override void Run()
		{
			Console.WriteLine("Insert values");
			List<int> inputList = ReadInputIntList();
			Console.WriteLine("Inserted list: " + ListAsString(inputList));

			Console.Write("Insert the window size: ");
			if (!int.TryParse(Console.ReadLine(), out int windowSize))
			{
				Console.WriteLine("Input Error: Number format exception.");
				return;
			}

			if (windowSize > inputList.Count)
			{
				Console.WriteLine("Input Error: windowSize must be smaller or equal to inputSize.");
				return;
			}

			Console.WriteLine("Printing maximum values:");
			List<int> window = new List<int>();
			for (int i = 0; i < windowSize; i++)
				window.Add(inputList[i]);
			Console.WriteLine("Windows = " + ListAsString(window) + " -> Max = " + window.Max());
			for (int i = windowSize; i < inputList.Count; i++)
			{
				window.RemoveAt(0);
				window.Add(inputList[i]);
				Console.WriteLine("Windows = " + ListAsString(window) + " -> Max = " + window.Max());
			}

		}

		private string ListAsString(List<int> list)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < list.Count; i++)
			{
				if (0 == i)
					sb.Append("[" + list[i]);
				else
					sb.Append(", " + list[i]);
			}
			sb.Append("]");
			return sb.ToString();
		}

		private List<int> ReadInputIntList()
		{
			List<int> list = new List<int>();
			while (true)
			{
				Console.Write("Insert an integer value (to exit 0): ");
				if (int.TryParse(Console.ReadLine(), out int value))
				{
					if (value != 0)
						list.Add(value);
					else
						break;
				}
			}
			return list;
		}
	}
}
