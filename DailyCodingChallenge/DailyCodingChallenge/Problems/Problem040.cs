using DailyCodingChallenge.Problems.Utility;
using DailyCodingChallenge.Problems.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem040 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM040_DESCRIPTION;
		protected override int Number => 40;

		protected override void Run()
		{
			List<int> numbers = new List<int> { 6, 1, 3, 3, 3, 6, 6 };
			Console.WriteLine("Input vector: {0}.", numbers.Print());

			Console.WriteLine("SOLVED IN:\n - Time : O(n) OK\n - Space: O(n) NOPE\n");

			int n = FoundSingleValue2(numbers);
			Console.WriteLine("Value founded: {0}.", n);
		}

		/// <summary>
		/// Time : O(n^2). NOPE
		/// Space: O(1). OK
		/// </summary>
		/// <param name="numbers">The values' list.</param>
		/// <returns>The only not-repeated value.</returns>
		private int FoundSingleValue(List<int> numbers)
		{
			int n = -1;
			while (numbers.Count > 0)
			{
				n = numbers[0];
				numbers.Remove(n);
				if (numbers.Contains(n))
				{
					numbers.Remove(n);
					numbers.Remove(n);
				}
				else
					break;
			}
			return n;
		}


		/// <summary>
		/// Time : O(n). OK
		/// Space: O(n). NOPE
		/// </summary>
		/// <param name="numbers">The values' list.</param>
		/// <returns>The only not-repeated value.</returns>
		private int FoundSingleValue2(List<int> numbers)
		{
			List<int> nums = new List<int>();
			HashSet<int> set = new HashSet<int>();
			foreach(int n in numbers)
			{
				if (set.Add(n))
					nums.Add(n);
				else
					nums.Remove(n);
			}
			return nums[0];
		}
	}
}
