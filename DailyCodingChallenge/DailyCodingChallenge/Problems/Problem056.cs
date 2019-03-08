using System;

namespace DailyCodingChallenge.Problems
{

	/* 
	 * Graph Adjacency Matrix definition:
	 * For a simple graph with vertex set V, the adjacency matrix is a square |V| × |V| matrix A such that its element
	 * Aij is one when there is an edge from vertex i to vertex j, and zero when there is no edge.
	 * The diagonal elements of the matrix are all zero, since edges from a vertex to itself (loops) are not allowed
	 * in simple graphs. 
	 */

	class Problem056 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM056_DESCRIPTION;
		protected override int Number => 56;

		protected override void Run()
		{
			const int colours = 3;
			const int vertices = 5;
			bool[,] adjacencyMatrix = new bool[vertices, vertices]{ 
																	{ false, false, true , false, true  },
																	{ false, false, false, true , false },
																	{ true , false, false, true , false },
																	{ false, true , true , false, true  },
																	{ true , false, false, true , false }
																  };
			Console.WriteLine("The number of different colours is {0}.", colours);
			
			int maxAdjacentsVertices = 0;
			int adjacentsCount;
			for(int i = 0; i < adjacencyMatrix.GetLength(0); i++)
			{
				adjacentsCount = 0;
				for(int j = 0; j < adjacencyMatrix.GetLength(1); j++)
				{
					if (adjacencyMatrix[i, j])
						adjacentsCount++;
				}
				if (adjacentsCount > maxAdjacentsVertices)
					maxAdjacentsVertices = adjacentsCount;
			}
			Console.WriteLine("Max adjacent vertices: {0}.", maxAdjacentsVertices);
			Console.WriteLine("Is it possible to fill all the graph's vertices with the given k different colours: {0}", (colours >= maxAdjacentsVertices));
		}
	}
}
