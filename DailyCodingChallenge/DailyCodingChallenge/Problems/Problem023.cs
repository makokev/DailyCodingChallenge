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

		private delegate int DistanceMethod(AStarNode node);
		private DistanceMethod distanceMethod;
		
		#region Input

		private static bool[][] wallPositions = new bool[][] {	new bool[]{ false, false, false, false },
																new bool[]{ true , true , false, true  },
																new bool[]{ false, false, false, false },
																new bool[]{ false, false, false, false }
															 };

		private static Couple<int> startPosition = new Couple<int>(3, 3);
		private static Couple<int> endPosition = new Couple<int>(0, 0);

		#endregion

		public Problem023()
		{
			distanceMethod = GetHeuristicDistance;
		}

		protected override void Run()
		{
			Console.WriteLine("Matrix:\n[");
			foreach(bool[] row in wallPositions)
				Console.WriteLine("\t"+row.Print());
			
			Console.WriteLine("]");
			Console.WriteLine("Starting position: " + startPosition);
			Console.WriteLine("Ending position: " + endPosition);

			Console.WriteLine("Tree implementation (graph not available yet, sorry!):");

			SortedList<AStarNode> openedNodes = new SortedList<AStarNode>() { new AStarNode(distanceMethod, 0, startPosition) };
			int minSteps = -1;
			int examinedNodes = 0;
			while(openedNodes.Count > 0)
			{
				examinedNodes++;
				AStarNode currentNode = openedNodes[0];
				Console.WriteLine("Examining: {0}.",currentNode.Coorditates.ToString());
				openedNodes.RemoveAt(0);
				if (IsGoal(currentNode))
				{
					minSteps = currentNode.DistanceFromRoot;
					break;
				}
				openedNodes.AddAll(GetSuccessors(currentNode));
			}

			Console.WriteLine("Minimum number of required steps: {0}", minSteps);
			Console.WriteLine("Examined nodes: {0}", examinedNodes);

		}
		
		private bool IsValidPosition(Couple<int> position) {
			int x = position.X;
			int y = position.Y;
			return	x >= 0 && x < wallPositions.Length &&		// x in range
					y >= 0 && y < wallPositions[x].Length &&	// y in range
					!wallPositions[x][y];						// position available (false)
		}
		
		private List<AStarNode> GetSuccessors(AStarNode node)
		{
			Couple<int> pos = node.Coorditates;
			List<AStarNode> successors = new List<AStarNode>();
			List<AStarNode> nextPositions = new List<AStarNode>
			{
				new AStarNode(distanceMethod, node.DistanceFromRoot+1, new Couple<int>(pos.X + 1, pos.Y)),
				new AStarNode(distanceMethod, node.DistanceFromRoot+1, new Couple<int>(pos.X - 1, pos.Y)),
				new AStarNode(distanceMethod, node.DistanceFromRoot+1, new Couple<int>(pos.X, pos.Y + 1)),
				new AStarNode(distanceMethod, node.DistanceFromRoot+1, new Couple<int>(pos.X, pos.Y - 1))
			};

			foreach (AStarNode newPos in nextPositions)
			{
				if (IsValidPosition(newPos.Coorditates))
					successors.Add(newPos);
			}

			return successors;
		}
		
		private bool IsGoal(AStarNode node) => endPosition == node.Coorditates;

		private int GetManhattanDistance(Couple<int> couple) => Math.Abs(endPosition.X - couple.X) + Math.Abs(endPosition.Y - couple.Y);

		private int GetHeuristicDistance(AStarNode node) => node.DistanceFromRoot + GetManhattanDistance(node.Coorditates);




		class AStarNode : IComparable<AStarNode>
		{
			public DistanceMethod DistanceFunction { get; private set; }
			public int DistanceFromRoot { get; set; }
			public Couple<int> Coorditates { get; private set; }

			public AStarNode(DistanceMethod func, int distanceFromRoot, int x, int y) : this(func, distanceFromRoot, new Couple<int>(x, y)) { }

			public AStarNode(DistanceMethod func, int distanceFromRoot, Couple<int> coordinates)
			{
				DistanceFunction = func;
				DistanceFromRoot = distanceFromRoot;
				Coorditates = coordinates;
			}

			public int CompareTo(AStarNode other) => DistanceFunction(this) - DistanceFunction(other);

			public bool Equal(AStarNode other) => CompareTo(other) == 0;
		}

	}
}
