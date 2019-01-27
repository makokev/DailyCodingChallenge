using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem023 : Problem
	{
		private static bool[][] wallPositions = new bool[][] {	new bool[]{ false, false, false, false },
																new bool[]{ true , true , false, true  },
																new bool[]{ false, false, false, false },
																new bool[]{ false, false, false, false }
															 };

		private static Pair<int> startPosition = new Pair<int>(3, 0);
		private static Pair<int> endPosition = new Pair<int>(0, 0);

		public Problem023() : base(23, ProblemDescription.PROBLEM023_DESCRIPTION) { }

		protected override void Run()
		{
			Console.WriteLine("Matrix:\n[");
			foreach(bool[] row in wallPositions)
			{
				Console.WriteLine("\t"+row.ToList().AsString());
			}
			Console.WriteLine("]");
			Console.WriteLine("Starting position: " + startPosition);
			Console.WriteLine("Ending position: " + endPosition);

			Console.WriteLine("Not implemented yet. Sorry!");

			// Stack overflow exception: I have to use an heuristic algorithm, like A*.
			//int minStep = GetMinStep(startPosition, endPosition, 0, new List<Pair<int>>());
			//Console.WriteLine("Minimum number of required steps: {0}", minStep);
		}

		private int GetMinStep(Pair<int> startPosition, Pair<int> endPosition, int partialSteps, List<Pair<int>> visitedPositions) {
			if (startPosition == endPosition)
				return partialSteps;
			int minStep = int.MaxValue;
			List<Pair<int>> newVisitedPositions;
			foreach (Pair<int> newStart in GetAvailablePosition(startPosition, visitedPositions))
			{
				newVisitedPositions = visitedPositions.ToList();
				newVisitedPositions.Add(newStart);
				int steps = GetMinStep(newStart, endPosition, partialSteps+1, newVisitedPositions);
				if (steps < minStep)
					minStep = steps;
			}
			
			return minStep;
		}

		private List<Pair<int>> GetAvailablePosition(Pair<int> startPosition, List<Pair<int>> visitedPositions) {
			List<Pair<int>> availablePositions = new List<Pair<int>>();
			List<Pair<int>> nexPositions = new List<Pair<int>>();
			nexPositions.Add(new Pair<int>(startPosition.X + 1, startPosition.Y));
			nexPositions.Add(new Pair<int>(startPosition.X - 1, startPosition.Y));
			nexPositions.Add(new Pair<int>(startPosition.X, startPosition.Y + 1));
			nexPositions.Add(new Pair<int>(startPosition.X, startPosition.Y - 1));

			foreach (Pair<int> newPos in nexPositions) {
				if (IsValidPosition(newPos) && !visitedPositions.Contains(newPos))
					availablePositions.Add(newPos);
			}

			return availablePositions;
		}

		private bool IsValidPosition(Pair<int> position) {
			int x = position.X;
			int y = position.Y;
			return	x >= 0 && x < wallPositions.Length &&		// x in range
					y >= 0 && y < wallPositions[x].Length &&	// y in range
					!wallPositions[x][y];						// position available (false)
		}
	}

	class Pair<T> {

		public T X { get; private set; }
		public T Y { get; private set; }

		public Pair(T x, T y){
			X = x;
			Y = y;
		}

		public override string ToString()
		{
			return "("+X+","+Y+")";
		}

		public static bool operator ==(Pair<T> first, Pair<T> second) {
			return first.X.Equals(second.X) && first.Y.Equals(second.Y);
		}

		public static bool operator !=(Pair<T> first, Pair<T> second)
		{
			return !(first == second);
		}
	}
}
