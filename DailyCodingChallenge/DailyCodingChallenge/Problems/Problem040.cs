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
			int[] numbers = new int[] { 6, 1, 3, 3, 3, 6, 6 };
			Console.WriteLine("Input vector: {0}.", numbers.Print());
			
			int n = FindSingleValue(numbers);
			Console.WriteLine("Value founded: {0}.", n);
		}

		/// <summary>
		/// Find the single value present in the array (Time: O(n) - Space: O(1)).
		/// </summary>
		/// <param name="numbers">The values' array.</param>
		/// <returns>The only not-repeated value.</returns>
		private int FindSingleValue(int[] numbers)
		{
			int ones = 0, twos = 0, common_bits;

			// Remind:
			// & : and bit operator
			// | : or  bit operator
			// ^ : xor bit operator
			// ~ : complement bit operator (bit inversion)

			foreach(int num in numbers)
			{
				twos = twos | (ones & num);
				ones = ones ^ num;
				common_bits = ~(ones & twos);
				ones &= common_bits;
				twos &= common_bits;
			}

			return ones;
		}
	}
}
