using DailyCodingChallenge.Problems.Utility;
using DailyCodingChallenge.Problems.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem033 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM033_DESCRIPTION;
		protected override int Number => 33;

		protected override void Run()
		{

			SortedList<int> sortedList = new SortedList<int>();

			int[] numbers = new int[] { 2, 1, 5, 7, 2, 0, 5 };

			Console.WriteLine("Input list: {0}.", numbers.Print());
			List<double> runningMedians = new List<double>();
			foreach (int number in numbers)
			{
				sortedList.Add(number);
				runningMedians.Add(GetMedian(sortedList));
			}

			Console.WriteLine("Running medians: {0}.", runningMedians.Print());
		}

		private double GetMedian(SortedList<int> sortedList)
		{
			List<int> list = sortedList.ToList();
			if (null == list)
				throw new ArgumentNullException("list null.");
			if (list.Count == 0)
				throw new ArgumentException("Empty list.");
			while(list.Count > 2)
			{
				list.RemoveAt(0);
				list.RemoveAt(list.Count - 1);
			}
			int sum = 0;
			foreach (int number in list)
				sum += number;
			return sum / (double)list.Count;
		}

	}
}
