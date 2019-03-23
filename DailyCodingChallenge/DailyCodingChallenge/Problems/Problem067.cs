using DailyCodingChallenge.Problems.Utility;
using DailyCodingChallenge.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem067 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM067_DESCRIPTION;
		protected override int Number => 67;

		protected override void Run()
		{
			LFUCache<int, string> cache = new LFUCache<int, string>(3);
			Console.WriteLine("Adding p1");
			cache.Set(1, "p1");
			PrintTables(cache);
			Console.WriteLine("Adding p2");
			cache.Set(2, "p2");
			PrintTables(cache);
			Console.WriteLine("Adding p3");
			cache.Set(3, "p3");
			PrintTables(cache);
			Console.WriteLine("Getting p1");
			cache.Get(1);
			PrintTables(cache);
			Console.WriteLine("Getting p3");
			cache.Get(3);
			PrintTables(cache);
			Console.WriteLine("Getting p3");
			cache.Get(3);
			PrintTables(cache);
			Console.WriteLine("Adding p4");
			cache.Set(4, "p4");
			PrintTables(cache);

			Console.WriteLine("Getting p4");
			cache.Get(4);
			PrintTables(cache);

			Console.WriteLine("Adding p5");
			cache.Set(5, "p5");
			PrintTables(cache);

		}

		private void PrintTables(LFUCache<int, string> cache)
		{
			Console.WriteLine("TABLES:");
			PrintCache(cache);
			PrintCount(cache);
			PrintNode(cache);
		}

		private void PrintNode(LFUCache<int, string> cache)
		{
			PrintList("Node table:", cache.GetAllNode());
		}

		private void PrintCount(LFUCache<int, string> cache)
		{
			PrintList("Count table:", cache.GetAllCount());
		}

		private void PrintCache(LFUCache<int, string> cache)
		{
			PrintList("Cache table:", cache.GetAllCache());
		}

		private void PrintList(string description, IEnumerable<object> list)
		{
			Console.WriteLine(description);
			foreach (object obj in list)
				Console.WriteLine("{0}", obj.ToString());
			Console.WriteLine();
		}
	}
}
