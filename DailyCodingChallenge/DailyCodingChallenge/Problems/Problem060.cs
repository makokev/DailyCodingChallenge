using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem060 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM060_DESCRIPTION;
		protected override int Number => 60;

		protected override void Run()
		{
			List<int> input_numbers = new List<int>() { 15, 5, 20, 10, 35, 15, 10 };

			Console.WriteLine("Input set: {0}.\n", input_numbers.Print());

			int sum = 0;
			foreach (int number in input_numbers)
				sum += number;

			int threshold = sum / 2;

			Console.WriteLine("Subsets sum (total_sum / 2): {0}.", threshold);
			Console.WriteLine("Is the input set splittable into two subset of sum {0}? {1}.", threshold, CheckSplittableElements(input_numbers, threshold));

		}

		private bool CheckSplittableElements(List<int> elements, int sum)
		{
			List<int> list = new List<int>();
			List<List<int>> combinations = new List<List<int>>() { new List<int>() };
			foreach(int element in elements)
			{
				if (AddCurrentElementToCombinationsAndCheckSum(element, sum, combinations))
					return true;
			}
			return false;
		}

		private bool CheckCombinationsSum(int sum, List<List<int>> combinations)
		{
			int currentSum;
			foreach(List<int> combination in combinations)
			{
				currentSum = (from element in combination
							  select element).Sum();
				if (currentSum == sum)
					return true;
			}
			return false;
		}

		private bool AddCurrentElementToCombinationsAndCheckSum(int element, int sum, List<List<int>> combinations)
		{
			List<List<int>> newCombinations = new List<List<int>>();
			foreach (List<int> combination in combinations)
				newCombinations.Add(combination.ToList());

			foreach (List<int> newCombination in newCombinations)
				newCombination.Add(element);
	
			combinations.AddRange(newCombinations);

			return CheckCombinationsSum(sum, newCombinations);
		}
	}
}
