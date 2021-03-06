﻿using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;

namespace DailyCodingChallenge.Problems
{
	class Problem036 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM036_DESCRIPTION;
		protected override int Number => 36;

		protected override void Run()
		{
			BinaryNode<int> root = new BinaryNode<int>(15, new BinaryNode<int>(2, new BinaryNode<int>(3), new BinaryNode<int>(4)), new BinaryNode<int>(5, new BinaryNode<int>(3)));
			root.PrintTree();
			int secondMaxValue = GetSecondMaxValue(root);
			Console.WriteLine("Second max value: {0}.", secondMaxValue);
		}

		private int GetSecondMaxValue(BinaryNode<int> root)
		{
			Couple<int> couple = GetTwoMaxValue(root);
			return (couple.First > couple.Second) ? couple.Second : couple.First;
		}

		private Couple<int> GetTwoMaxValue(BinaryNode<int> root)
		{
			if (root.ChildrenCount() == 0)
				return new Couple<int>(root.Value, int.MinValue);

			SortedList<int> sortedList = new SortedList<int>(false);

			// Left child
			Couple<int> left = GetTwoMaxValue(root.Left);
			sortedList.Add(left.First);
			sortedList.Add(left.Second);
			
			// Right child
			if (root.ChildrenCount() == 2)
			{
				Couple<int> right = GetTwoMaxValue(root.Right);
				sortedList.Add(right.First);
				sortedList.Add(right.Second);
			}
			
			// Root
			sortedList.Add(root.Value);

			// Extract two max values
			List<int> list = sortedList.ToList();
			return new Couple<int>(list[0], list[1]);
		}
	}
}
