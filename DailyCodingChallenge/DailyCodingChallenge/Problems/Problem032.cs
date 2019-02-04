using DailyCodingChallenge.Problems.Utility;
using DailyCodingChallenge.Problems.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DailyCodingChallenge.Problems.Utility.Graph;

namespace DailyCodingChallenge.Problems
{
	class Problem032 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM032_DESCRIPTION;
		protected override int Number => 32;

		protected override void Run()
		{
			Graph g = new Graph();
			//edge 0 --> 1
			g.AddEdge(0, 1, Math.Log(32));		/* 5*/
			g.AddEdge(0, 2, Math.Log(16));		/* 4*/
			g.AddEdge(1, 3, Math.Log(8));		/* 3*/
			g.AddEdge(2, 1, Math.Log(0.015625));/*-6*/
			g.AddEdge(3, 2, Math.Log(4));		/* 2*/

			PrintGraph(g);

			BellmanFordAlgorithm(ref g, g.Edges.First().From);
			
		}

		private void PrintGraph(Graph g)
		{
			Console.WriteLine("Graph:");
			foreach (Edge e in g.Edges)
				Console.WriteLine("{0} --({1})--> {2}", e.From, e.Cost, e.To);
			Console.WriteLine();
		}

		private void BellmanFordAlgorithm(ref Graph g, int source)
		{
			double[] distance = new double[g.VerticesCount];
			int[] predecessor = new int[g.VerticesCount];

			//step 1: fill the distance array and predecessor array
			for(int i = 0; i < g.VerticesCount; i++)
			{
				distance[i] = double.MaxValue;
				predecessor[i] = -1;
			}

			//mark the source vertex
			distance[source] = 0;

			//step 2: relax edges |V| - 1 times (maximim number of times to adjust all vertices' cost)
			for(int i = 1; i < g.VerticesCount; i++)
			{
				for(int j = 0; j < g.EdgesCount; j++)
				{
					Edge e = g.Edges[j];
					if(distance[e.From] != double.MaxValue && distance[e.To] > distance[e.From] + e.Cost)
					{
						distance[e.To] = distance[e.From] + e.Cost;
						predecessor[e.To] = e.From;
					}
				}
			}

			//step 3: detect negative cycle
			//if value changes then we have a negative cycle in the graph
			//and we cannot find the shortest distances
			bool negativeCycleFound = false;
			for (int j = 0; j < g.EdgesCount && !negativeCycleFound; j++)
			{
				Edge e = g.Edges[j];
				if (distance[e.From] != int.MaxValue && distance[e.To] > distance[e.From] + e.Cost)
				{
					negativeCycleFound = true;
				}
			}

			if (negativeCycleFound)
			{
				Console.WriteLine("Negative cycle founded.");
				Console.WriteLine("Cycle: {0}", predecessor.AsString());
			}
			else
				Console.WriteLine("No cycle founded.");
			Console.WriteLine("Distances: {0}", distance.AsString());
		}
	}
}
