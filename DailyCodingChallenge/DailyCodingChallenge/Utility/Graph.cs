using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems.Utility
{
	class Graph
	{
		public int VerticesCount { get; private set; }
		public int EdgesCount { get; private set; }
		private readonly List<Edge> _edges = new List<Edge>();
		public List<Edge> Edges { get => _edges; }

		public Graph(){ }

		public void AddEdge(int from, int to, double cost)
		{
			Edge e = new Edge(from, to, cost);
			if (!Edges.Contains(e))
			{
				VerticesCount += GetNewVerticesCount(from, to);
				EdgesCount++;
				_edges.Add(e);
				
			}
		}

		private int GetNewVerticesCount(int from, int to)
		{
			bool fromPresent = false;
			bool toPresent = false;
			foreach(Edge e in Edges)
			{
				if (e.From == from || e.To == from)
					fromPresent = true;
				if (e.From == to || e.To == to)
					toPresent = true;
				if (fromPresent && toPresent)
					break;
			}
			int count = 0;
			count += (fromPresent) ? 0 : 1;
			count += (toPresent) ? 0 : 1;
			return count;
		}

		public class Edge
		{
			public int From { get; private set; }
			public int To { get; private set; }
			public double Cost { get; private set; }

			public Edge(int from, int to, double cost)
			{
				From = from;
				To = to;
				Cost = cost;
			}

			public override bool Equals(object obj)
			{
				Edge e = obj as Edge;
				return (null == e) ? false : Equals(e);
			}

			public bool Equals(Edge e) => (null == e) ? false : (From == e.From && To == e.To && Cost == e.Cost);

			public override int GetHashCode()
			{
				var hashCode = 456375713;
				hashCode = hashCode * -1521134295 + From.GetHashCode();
				hashCode = hashCode * -1521134295 + To.GetHashCode();
				hashCode = hashCode * -1521134295 + Cost.GetHashCode();
				return hashCode;
			}
		}
	}
}
