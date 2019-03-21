using DailyCodingChallenge.Problems.Utility;
using DailyCodingChallenge.Problems.Extensions;
using System;
using System.Collections.Generic;

namespace DailyCodingChallenge.Problems
{
	class Problem023 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM023_DESCRIPTION;
		protected override int Number => 23;

		private delegate int DistanceMethod(AStarTreeNode node);
		private DistanceMethod distanceMethod;
		
		#region Input

		private static bool[][] wallPositions = new bool[][] {	new bool[]{ false, false, false, false },
																new bool[]{ true , true , true , false },
																new bool[]{ false, false, false, false },
																new bool[]{ false, true , false, false }
															 };

		private static Couple<int> startPosition = new Couple<int>(3, 0);
		private static Couple<int> endPosition = new Couple<int>(0, 0);

		#endregion

		public Problem023()
		{
			distanceMethod = GetHeuristicDistance;
		}

		protected override void Run()
		{
			Console.WriteLine("Matrix:");
			foreach(bool[] row in wallPositions)
				Console.WriteLine(row.Print());
			
			Console.WriteLine();
			Console.WriteLine("Starting position: {0}", startPosition);
			Console.WriteLine("Ending position: {0}\n", endPosition);

			Couple<int> resultsTree = AStarTreeSearch();
			int minSteps = resultsTree.First;
			int examinedNodes = resultsTree.Second;

			Console.WriteLine("Minimum number of required steps: {0}", minSteps);
			Console.WriteLine("Examined nodes: {0}", examinedNodes);

			Couple<int> resultsGraph = AStarGraphSearch();
			minSteps = resultsGraph.First;
			examinedNodes = resultsGraph.Second;

			Console.WriteLine("Minimum number of required steps: {0}", minSteps);
			Console.WriteLine("Examined nodes: {0}", examinedNodes);

		}

		private Couple<int> AStarTreeSearch()
		{
			Console.WriteLine("A* Tree Search:");

			SortedList<AStarTreeNode> openedNodes = new SortedList<AStarTreeNode>() { new AStarTreeNode(distanceMethod, 0, startPosition) };
			int minSteps = -1;
			int examinedNodes = 0;
			while (openedNodes.Count > 0)
			{
				examinedNodes++;
				AStarTreeNode currentNode = openedNodes[0];
				openedNodes.RemoveAt(0);
				if (IsGoal(currentNode))
				{
					minSteps = currentNode.DistanceFromRoot;
					break;
				}
				openedNodes.AddAll(GetSuccessors(currentNode));
			}
			return new Couple<int>(minSteps, examinedNodes);
		}

		private Couple<int> AStarGraphSearch()
		{
			Console.WriteLine("A* Graph Search:");

			SortedList<AStarGraphNode> openedNodes = new SortedList<AStarGraphNode>() { new AStarGraphNode(distanceMethod, 0, startPosition) };
			SortedList<AStarGraphNode> closedNodes = new SortedList<AStarGraphNode>();

			int minSteps = -1;
			int examinedNodes = 0;
			while (openedNodes.Count > 0)
			{
				examinedNodes++;
				AStarGraphNode currentNode = openedNodes[0];
				openedNodes.RemoveAt(0);
				closedNodes.Add(currentNode);
				if (IsGoal(currentNode))
				{
					minSteps = currentNode.DistanceFromRoot;
					break;
				}
				foreach(AStarGraphNode node in GetSuccessors(currentNode))
				{
					Pair<bool, AStarGraphNode> resultsClosed = ListContains(closedNodes, node);
					Pair<bool, AStarGraphNode> resultsOpened = ListContains(openedNodes, node);
					AStarGraphNode foundedNode = (resultsClosed.First) ? resultsClosed.Second : resultsOpened.Second;
					if ((resultsOpened.First || resultsClosed.First) && node.DistanceFromRoot < foundedNode.DistanceFromRoot)
						foundedNode.UpdateDistance(node.DistanceFromRoot);
					else if(!(resultsOpened.First || resultsClosed.First))
							openedNodes.Add(node);
				}
			}
			return new Couple<int>(minSteps, examinedNodes);
		}

		private Pair<bool, AStarGraphNode> ListContains(SortedList<AStarGraphNode> list, AStarGraphNode node)
		{
			Pair<bool, AStarGraphNode> results = new Pair<bool, AStarGraphNode>(false, null);
			foreach(AStarGraphNode currentNode in list)
			{
				if (currentNode.Coorditates == node.Coorditates)
				{
					results = new Pair<bool, AStarGraphNode>(true, currentNode);
					break;
				}
			}
			return results;
		}

		private bool IsValidPosition(Couple<int> position) {
			int x = position.First;
			int y = position.Second;
			return	x >= 0 && x < wallPositions.Length &&		// x in range
					y >= 0 && y < wallPositions[x].Length &&	// y in range
					!wallPositions[x][y];						// position available (false)
		}
		
		private List<AStarGraphNode> GetSuccessors(AStarTreeNode node)
		{
			Couple<int> pos = node.Coorditates;
			List<AStarGraphNode> successors = new List<AStarGraphNode>();
			List<AStarGraphNode> nextPositions = new List<AStarGraphNode>
			{
				new AStarGraphNode(distanceMethod, node.DistanceFromRoot+1, new Couple<int>(pos.First + 1, pos.Second)),
				new AStarGraphNode(distanceMethod, node.DistanceFromRoot+1, new Couple<int>(pos.First - 1, pos.Second)),
				new AStarGraphNode(distanceMethod, node.DistanceFromRoot+1, new Couple<int>(pos.First, pos.Second + 1)),
				new AStarGraphNode(distanceMethod, node.DistanceFromRoot+1, new Couple<int>(pos.First, pos.Second - 1))
			};

			foreach (AStarGraphNode newPos in nextPositions)
			{
				if (IsValidPosition(newPos.Coorditates))
					successors.Add(newPos);
			}

			return successors;
		}
		
		private bool IsGoal(AStarTreeNode node) => endPosition == node.Coorditates;

		private int GetManhattanDistance(Couple<int> couple) => Math.Abs(endPosition.First - couple.First) + Math.Abs(endPosition.Second - couple.Second);

		private int GetHeuristicDistance(AStarTreeNode node) => node.DistanceFromRoot + GetManhattanDistance(node.Coorditates);

		class AStarTreeNode : IComparable<AStarTreeNode>
		{
			public DistanceMethod DistanceFunction { get; private set; }
			public int DistanceFromRoot { get; set; }
			public Couple<int> Coorditates { get; private set; }

			public AStarTreeNode(DistanceMethod func, int distanceFromRoot, int x, int y) : this(func, distanceFromRoot, new Couple<int>(x, y)) { }

			public AStarTreeNode(DistanceMethod func, int distanceFromRoot, Couple<int> coordinates)
			{
				DistanceFunction = func;
				DistanceFromRoot = distanceFromRoot;
				Coorditates = coordinates;
			}

			// for sorting reasons
			public int CompareTo(AStarTreeNode other) => DistanceFunction(this) - DistanceFunction(other);
			
			// for sorting reasons
			public bool Equal(AStarTreeNode other) => CompareTo(other) == 0;
		}

		class AStarGraphNode : AStarTreeNode
		{
			public List<AStarGraphNode> ChildNodes { get; } = new List<AStarGraphNode>();

			public AStarGraphNode(DistanceMethod func, int distanceFromRoot, int x, int y) : base(func, distanceFromRoot, x, y) { }
			public AStarGraphNode(DistanceMethod func, int distanceFromRoot, Couple<int> couple) : base(func, distanceFromRoot, couple) { }

			public void UpdateDistance(int newDistanceFromRoot)
			{
				if (newDistanceFromRoot < 0)
					throw new ArgumentOutOfRangeException("newDistanceFromRoot", "the distance cannot be negative.");
				DistanceFromRoot = newDistanceFromRoot;
				foreach (AStarGraphNode child in ChildNodes)
					child.UpdateDistance(newDistanceFromRoot + 1);
			}
		}

	}
}
