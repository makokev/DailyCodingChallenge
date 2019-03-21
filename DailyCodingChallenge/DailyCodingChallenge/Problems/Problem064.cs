using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingChallenge.Problems
{
	class Problem064 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM064_DESCRIPTION;
		protected override int Number => 64;

		protected override void Run()
		{
			int dimension;
			do
			{
				Console.Write("Insert the chessboard dimension: ");
			} while (!int.TryParse(Console.ReadLine(), out dimension));

			Console.WriteLine("Chessboard dimension: {0}", dimension);

			int knigthTours = GetKnightTourNumberInChessboard(dimension);
			Console.WriteLine("In a chessboard of dimension {0} there are {1} knight's tour.", dimension, knigthTours);
		}

		private int GetKnightTourNumberInChessboard(int dimension)
		{
			int count = 0;
			bool[,] visitedPositions = new bool[dimension, dimension];
			int minCol = 0, maxCol = dimension - 1;
			int maxRow = Convert.ToInt32((dimension + 0.5) / 2);
			for (int i = 0; i < maxRow; i++)
			{
				for (int j = minCol; j < maxCol; j++)
				{
					visitedPositions[i, j] = true;
					count += RecoursiveKnightTourCounter(new Couple<int>(i, j), visitedPositions, dimension * dimension - 1);
					visitedPositions[i, j] = false;
				}
				minCol++;
				maxCol--;
				if (maxCol == minCol)
					maxCol++;
			}
			// the 4 factor is because the above loop is optimized in order to not repeat rotated configurations.
			return 4 * count;
		}

		private int RecoursiveKnightTourCounter(Couple<int> currentPosition, bool[,] visitedPositions, int availablePositions)
		{
			if (0 == availablePositions)
				return 1;
			int count = 0;
			// Find all the near positions
			List<Couple<int>> nearPositions = GetNearFreePositions(currentPosition, visitedPositions.GetLength(0));
			
			// for each not visited position: recoursivly invocation of KnigthTourCounter and sum the results
			foreach (Couple<int> position in nearPositions)
			{
				if (!visitedPositions[position.First, position.Second])
				{
					visitedPositions[position.First, position.Second] = true;
					count += RecoursiveKnightTourCounter(position, visitedPositions, availablePositions - 1);
					visitedPositions[position.First, position.Second] = false;
				}
			}
			
			return count;
		}

		private List<Couple<int>> GetNearFreePositions(Couple<int> currentPosition, int dimension)
		{
			List<Couple<int>> nearPositions = new List<Couple<int>>
			{
				new Couple<int>(currentPosition.First - 2, currentPosition.Second - 1),
				new Couple<int>(currentPosition.First - 2, currentPosition.Second + 1),
				new Couple<int>(currentPosition.First - 1, currentPosition.Second - 2),
				new Couple<int>(currentPosition.First - 1, currentPosition.Second + 2),
				new Couple<int>(currentPosition.First + 2, currentPosition.Second - 1),
				new Couple<int>(currentPosition.First + 2, currentPosition.Second + 1),
				new Couple<int>(currentPosition.First + 1, currentPosition.Second - 2),
				new Couple<int>(currentPosition.First + 1, currentPosition.Second + 2)
			};
			
			return nearPositions.Where(	x => x.First >= 0 &&
										x.First < dimension &&
										x.Second >= 0 &&
										x.Second < dimension
									  ).ToList(); ;
		}
	}
}
