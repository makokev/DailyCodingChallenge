using DailyCodingChallenge.Problems.Extensions;
using System;
using System.Collections.Generic;

namespace DailyCodingChallenge.Problems
{
	class Problem058 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM058_DESCRIPTION;
		protected override int Number => 58;

		protected override void Run()
		{
			int[] input_array = new int[10]{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			int element = input_array[0];
			
			// rotate the array
			int rotations = new Random().Next(10);
			int[] rotated_array = new int[input_array.Length];
			int input_index;
			for(int i = 0; i < rotated_array.Length; i++)
			{
				input_index = (i + rotations) % rotated_array.Length;
				rotated_array[i] = input_array[input_index];
			}

			// printing the array
			Console.WriteLine("The rotated array: {0}.\n", rotated_array.Print());

			// find the element index
			int elementIndex = GetElementIndex(rotated_array, element);
			Console.WriteLine("The element {0} is at position {1}.", element, elementIndex);
		}

		private int GetElementIndex(int[] array, int element) => GetRecursiveElementIndex(array, element, 0);

		private int GetRecursiveElementIndex(int[] array, int element, int cumulativeIndex)
		{
			int halfIndex = array.Length / 2;
			int endIndex = array.Length-1;
			int index;

			// check in the middle
			if (element == array[halfIndex])
				index = cumulativeIndex + halfIndex;
			else
			{
				// "binary search"
				// check array conditions and select the first or the second half of the array
				if (array[halfIndex] > array[endIndex])
				{
					index = (array[halfIndex] > element && element > array[endIndex]) ?
						GetRecursiveElementIndex(Subarray(array, 0, halfIndex), element, cumulativeIndex) :
						GetRecursiveElementIndex(Subarray(array, halfIndex), element, cumulativeIndex + halfIndex);
				}
				else
				{
					index = (array[halfIndex] > element || element > array[endIndex]) ?
						GetRecursiveElementIndex(Subarray(array, 0, halfIndex), element, cumulativeIndex) :
						GetRecursiveElementIndex(Subarray(array, halfIndex), element, cumulativeIndex + halfIndex);
				}
			}
			return index;
		}

		private int[] Subarray(int[] array, int startIndex = 0, int length = int.MaxValue)
		{
			if (length == int.MaxValue)
				length -= array.Length;
			List<int> subArray = new List<int>();
			for (int i = startIndex; i < array.Length && i < (startIndex + length); i++)
				subArray.Add(array[i]);
			return subArray.ToArray();
		}
	}
}
