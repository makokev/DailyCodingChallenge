using DailyCodingChallenge.Problems.Extensions;
using DailyCodingChallenge.Problems.Utility;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem069 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM069_DESCRIPTION;
		protected override int Number => 69;

		protected override void Run()
		{
			int[] input_numbers = new int[] { -10, -10, 5, 2 };

			Console.WriteLine("The input numbers are: {0}.", input_numbers.Print());

			Pair<int, int[]> results = GetLargestProduct(input_numbers, 3);
			int largestProduct = results.First;
			int[] selectedElements = results.Second;
			Console.WriteLine("The largest product is: {0} = {1}.", selectedElements.Print(separator: " * ", withBrackets: false), largestProduct);
		}

		private Pair<int, int[]> GetLargestProduct(int[] numbers, int elementNumber)
		{
			int maxProduct = int.MinValue;
			int[] selectedElements = new int[elementNumber];
			SortedList<int> positiveList = new SortedList<int>(increasingOrder: false);
			SortedList<int> negativeList = new SortedList<int>(increasingOrder: true );
			
			// init the lists
			foreach(int element in numbers)
			{
				if (element >= 0)
					positiveList.Add(element);
				else
					negativeList.Add(element);
			}

			// proning the solutions:
			// all element the element that are after the allowed number are removed

			while (positiveList.Count > elementNumber)
				positiveList.RemoveAt(positiveList.Count - 1);
			while (negativeList.Count > elementNumber)
				negativeList.RemoveAt(negativeList.Count - 1);

			if (negativeList.Count >= 3)
			{
				maxProduct = 1;
				for(int i = 0; i < elementNumber; i++)
				{
					maxProduct *= negativeList[i];
					selectedElements[i] = negativeList[i];
				}
			}

			int currentProduct, selectedNumber;
			int[] currentSelectedElement = new int[elementNumber];
			for (int i = 0; i <= negativeList.Count; i+=2)
			{
				currentProduct = 1;
				selectedNumber = 0;
				// Have I choose enough negative number in order to reach elementNumber?
				if (i + positiveList.Count >= elementNumber)
				{
					for (int j = 0; j*2 < i; j++)
					{
						currentProduct *= negativeList[i * j];
						currentSelectedElement[selectedNumber] = negativeList[i * j];
						selectedNumber++;
						currentProduct *= negativeList[i * j + 1];
						currentSelectedElement[selectedNumber] = negativeList[i * j];
						selectedNumber++;
					}
					for (int j = 0; j < positiveList.Count && selectedNumber < elementNumber; j++, selectedNumber++)
					{
						currentProduct *= positiveList[j];
						currentSelectedElement[selectedNumber] = positiveList[j];
					}

					if (currentProduct > maxProduct)
					{
						maxProduct = currentProduct;
						selectedElements = currentSelectedElement.ToArray();
					}
				}
			}
			return new Pair<int, int[]>(maxProduct, selectedElements);
		}
	}
}
