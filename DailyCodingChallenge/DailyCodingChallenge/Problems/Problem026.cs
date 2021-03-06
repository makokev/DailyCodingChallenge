﻿using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;

namespace DailyCodingChallenge.Problems
{
	class Problem026 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM026_DESCRIPTION;
		protected override int Number => 26;

		protected override void Run()
		{
			Console.WriteLine("Insert list's elements:");
			List<int> list = ReadInputIntList(-1);
			Console.WriteLine("Inserted list: "+list.Print());
			Console.Write("Insert the request element: ");
			if (!int.TryParse(Console.ReadLine(), out int k))
			{
				Console.WriteLine("Parse failed.");
				return;
			}

			if(k > list.Count || k <= 0)
			{
				Console.WriteLine("k out of range ( 1 <= k <= Lenght(list)).");
				return;
			}

			int val = -1;
			for (int i = 0; i < list.Count; i++) {
				if (i >= (k - 1))
					val = list[i - k + 1];
			}
			Console.WriteLine("Value = " + val);
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
