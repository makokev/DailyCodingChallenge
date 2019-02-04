using DailyCodingChallenge.Problems.Utility;
using DailyCodingChallenge.Problems.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingChallenge.Problems
{
	class Problem023 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM023_DESCRIPTION;
		protected override int Number => 23;

		#region Input

		private static bool[][] wallPositions = new bool[][] {	new bool[]{ false, false, false, false },
																new bool[]{ true , true , false, true  },
																new bool[]{ false, false, false, false },
																new bool[]{ false, false, false, false }
															 };

		private static Couple<int> startPosition = new Couple<int>(3, 0);
		private static Couple<int> endPosition = new Couple<int>(0, 0);

		#endregion

		protected override void Run()
		{
			Console.WriteLine("Matrix:\n[");
			foreach(bool[] row in wallPositions)
			{
				Console.WriteLine("\t"+row.AsString());
			}
			Console.WriteLine("]");
			Console.WriteLine("Starting position: " + startPosition);
			Console.WriteLine("Ending position: " + endPosition);

			Console.WriteLine("Not implemented yet. Sorry!");

			// Stack overflow exception: I have to use an heuristic algorithm, like A*.
			//int minStep = GetMinStep(startPosition, endPosition, 0, new List<Pair<int>>());
			//Console.WriteLine("Minimum number of required steps: {0}", minStep);
		}

		private int GetMinStep(Couple<int> startPosition, Couple<int> endPosition, int partialSteps, List<Couple<int>> visitedPositions) {
			if (startPosition == endPosition)
				return partialSteps;
			int minStep = int.MaxValue;
			List<Couple<int>> newVisitedPositions;
			foreach (Couple<int> newStart in GetAvailablePosition(startPosition, visitedPositions))
			{
				newVisitedPositions = visitedPositions.ToList();
				newVisitedPositions.Add(newStart);
				int steps = GetMinStep(newStart, endPosition, partialSteps+1, newVisitedPositions);
				if (steps < minStep)
					minStep = steps;
			}
			
			return minStep;
		}

		private List<Couple<int>> GetAvailablePosition(Couple<int> startPosition, List<Couple<int>> visitedPositions) {
			List<Couple<int>> availablePositions = new List<Couple<int>>();
			List<Couple<int>> nexPositions = new List<Couple<int>>();
			nexPositions.Add(new Couple<int>(startPosition.X + 1, startPosition.Y));
			nexPositions.Add(new Couple<int>(startPosition.X - 1, startPosition.Y));
			nexPositions.Add(new Couple<int>(startPosition.X, startPosition.Y + 1));
			nexPositions.Add(new Couple<int>(startPosition.X, startPosition.Y - 1));

			foreach (Couple<int> newPos in nexPositions) {
				if (IsValidPosition(newPos) && !visitedPositions.Contains(newPos))
					availablePositions.Add(newPos);
			}

			return availablePositions;
		}

		private bool IsValidPosition(Couple<int> position) {
			int x = position.X;
			int y = position.Y;
			return	x >= 0 && x < wallPositions.Length &&		// x in range
					y >= 0 && y < wallPositions[x].Length &&	// y in range
					!wallPositions[x][y];						// position available (false)
		}
	}
}
