using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingChallenge.Problems
{
	class Problem020 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM020_DESCRIPTION;
		protected override int Number => 20;

		protected override void Run()
		{
			Console.WriteLine("List A:");
			List<int> a = ReadInputIntList(-1);
			Console.WriteLine("List B:");
			List<int> b = ReadInputIntList(-1);

			Console.WriteLine("List A: " + a.Print());
			Console.WriteLine("List B: " + b.Print());


			List<int> visited = new List<int>();
			int nodeValue = -1;
			bool founded = false;
			while (!founded && a.Count() > 0 && b.Count() > 0)
			{
				if (visited.Contains(a.First()))
				{
					nodeValue = a.First();
					founded = true;
				}
				else
				{
					visited.Add(a.First());
					a.RemoveAt(0);
				}

				if (visited.Contains(b.First()))
				{
					nodeValue = b.First();
					founded = true;
				}
				else
				{
					visited.Add(b.First());
					b.RemoveAt(0);
				}
			}

			if (founded)
				Console.WriteLine("Node founded! Value = " + nodeValue);
			else
				Console.Write("No node founded.");
		}
	
		private List<int> ReadInputIntList(int exitValue = 0)
		{
			List<int> list = new List<int>();
			while (true)
			{
				Console.Write("Insert an integer value (to exit: " + exitValue + "): ");
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
