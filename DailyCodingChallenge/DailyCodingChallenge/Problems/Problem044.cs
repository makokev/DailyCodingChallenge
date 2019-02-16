using DailyCodingChallenge.Problems.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem044 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM044_DESCRIPTION;
		protected override int Number => 44;

		protected override void Run()
		{
			int[] vector = new int[] { 5, 4, 3, 2, 1 };

			Console.WriteLine("Input vector: {0}.", vector.Print());

			int outOfOrder = MergeSort(vector);
			Console.WriteLine("Ordered vector: {0}.", vector.Print());
			Console.WriteLine("Assert outOfOrder = 10: {0}.", 10 == outOfOrder);
		}

		/// <summary>
		/// Sort the array in increasing way and return the number of swap.
		/// Time: O(n*log(n))
		/// </summary>
		/// <param name="v">The array that must be sorted</param>
		/// <returns>The number of required swap</returns>
		private int MergeSort(int[] v)
		{
			// no changes
			if (v.Length <= 1)
				return 0;

			int count = 0;

			// split the array into two sub-arrays
			int l1 = (int)Math.Ceiling(v.Length / 2.0);
			int[] v1 = new int[l1];
			int[] v2 = new int[v.Length - l1];

			int index1 = 0, index2 = 0;
			int i = 0;
			for(i = 0; i < v.Length; i++)
			{
				if(i < l1)
				{
					v1[index1] = v[i];
					index1++;
				}
				else
				{
					v2[index2] = v[i];
					index2++;
				}
			}

			// each array must be sorted
			count += MergeSort(v1);
			count += MergeSort(v2);

			// merge the two array counting swap operations
			for (i = 0, index1 = 0, index2 = 0; index1 < l1 && index2 < v.Length-l1; i++)
			{
				if (v1[index1] > v2[index2])
				{
					v[i] = v2[index2];
					count += (l1 - index1);
					index2++;
				}
				else
				{
					v[i] = v1[index1];
					index1++;
				}
			}

			// appending tail of v1[]
			while(index1 < l1)
			{
				v[i] = v1[index1];
				index1++;
				i++;
			}

			// appending tail of v2[]
			while(index2 < v.Length - l1)
			{
				v[i] = v2[index2];
				index2++;
				i++;
			}

			return count;
		}

	}
}
