using System;
using System.Collections.Generic;
using System.Linq;
using DailyCodingChallenge.Problems.Utility;

namespace DailyCodingChallenge.Problems
{
	class Problem018 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM018_DESCRIPTION;
		protected override int Number => 18;

		protected override void Run()
		{
			Console.WriteLine("Insert input values:");
			List<int> inputList = ReadInputIntList(-1);
			Console.WriteLine("Inserted list: " + inputList.AsString());

			Console.Write("Insert the window size: ");
			if (!int.TryParse(Console.ReadLine(), out int windowSize))
			{
				Console.WriteLine("Input Error: Number format exception.");
				return;
			}

			if (windowSize > inputList.Count || windowSize <= 0)
			{
				Console.WriteLine("Input Error: windowSize must be smaller or equal to inputSize and greather than 0.");
				return;
			}

			Console.WriteLine("Printing maximum values:");
			List<int> window = new List<int>();
			for (int i = 0; i < windowSize; i++)
				window.Add(inputList[i]);
			Console.WriteLine("Windows = " + window.AsString() + " -> Max = " + window.Max());
			for (int i = windowSize; i < inputList.Count; i++)
			{
				window.RemoveAt(0);
				window.Add(inputList[i]);
				Console.WriteLine("Windows = " + window.AsString() + " -> Max = " + window.Max());
			}

		}

		private List<int> ReadInputIntList(int exitValue = 0)
		{
			List<int> list = new List<int>();
			while (true)
			{
				Console.Write("Insert an integer value (to exit: "+exitValue+"): ");
				if (int.TryParse(Console.ReadLine(), out int value))
				{
					if (value != exitValue)
						list.Add(value);
					else
						break;
				}
			}
			return list;
		}
	}
}
