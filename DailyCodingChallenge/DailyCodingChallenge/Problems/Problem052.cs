using DailyCodingChallenge.Utility;
using System;

namespace DailyCodingChallenge.Problems
{
	class Problem052 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM052_DESCRIPTION;
		protected override int Number => 52;


		protected override void Run()
		{
			Random random = new Random();
			int cacheDimension = 5;
			int[] keys = new int[cacheDimension];

			// init cache
			LRUCache<int, string> cache = new LRUCache<int, string>(cacheDimension);

			// adding pages
			Console.WriteLine("Adding pages..");
			for (int i = 0; i < cacheDimension; i++)
			{
				cache.Set(i, "page" + i);
				keys[i] = i;
				Console.WriteLine("key: {0}, value: {1}", i, cache.Get(i));
			}

			// reading
			Console.WriteLine("Reading pages..");
			foreach (int key in keys)
				Console.WriteLine("key: {0}, value: {1}", key, cache.Get(key));

			// insert new overflow page
			Console.WriteLine("Adding a new overflow page..");
			cache.Set(10, "page" + 10);

			// reading
			Console.WriteLine("Reading pages..");
			foreach (int key in keys)
				Console.WriteLine("key: {0}, value: {1}", key, cache.Get(key));

			string s = cache.Get(0);
			Console.WriteLine("first page removed? {0}", s == default(string));
		}
	}
}
