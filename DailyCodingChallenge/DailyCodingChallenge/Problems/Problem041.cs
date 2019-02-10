using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem041 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM041_DESCRIPTION;
		protected override int Number => 41;

		protected override void Run()
		{
			// ('A', 'B'), ('A', 'C'), ('B', 'C'), ('C', 'A')
			List<Couple<string>> couples = new List<Couple<string>> {	new Couple<string>("A","B"),
																		new Couple<string>("A","C"),
																		new Couple<string>("B","C"),
																		new Couple<string>("C","A")
																	};
			string startingPoint = "A";

			Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
			foreach(Couple<string> couple in couples)
			{
				if (dictionary.Keys.Contains(couple.X))
					dictionary[couple.X].Add(couple.Y);
				else
					dictionary[couple.X] = new List<string> { couple.Y };
			}

			List<string> path = GetPath(dictionary, startingPoint);
			if (null != path)
				Console.WriteLine("Path: {0}.", path.Print(separator:" -> ", withBrackets: false));
			else
				Console.WriteLine("No path founded.");
			
		}

		private List<string> GetPath(Dictionary<string, List<string>> dictionary, string start)
		{
			List<string> path = new List<string> { start };
			return RecoursiveGetPath(dictionary, path);
		}
		
		private List<string> RecoursiveGetPath(Dictionary<string, List<string>> dictionary, List<string> partialPath)
		{
			if (dictionary.Count == 0 || null == partialPath)
				return partialPath;

			string start = partialPath.Last();
			if (dictionary.Keys.Contains(start))
			{
				foreach(string newStart in dictionary[start])
				{
					Dictionary<string, List<string>> dictionaryCopy = CopyDictionary(dictionary);
					List<string> newPath = partialPath.ToList();
					newPath.Add(newStart);
					dictionaryCopy[start].Remove(newStart);
					if (0 == dictionaryCopy[start].Count)
						dictionaryCopy.Remove(start);
					List<string> thePath = RecoursiveGetPath(dictionaryCopy, newPath);
					if (null != thePath)
						return thePath;
				}
			}
			return null;
		}

		private Dictionary<string, List<string>> CopyDictionary(Dictionary<string, List<string>> dictionary)
		{
			Dictionary<string, List<string>> dictionaryCopy = new Dictionary<string, List<string>>();
			foreach(string key in dictionary.Keys)
				dictionaryCopy.Add(key, dictionary[key].ToList());
			return dictionaryCopy;
		}
	}
}
