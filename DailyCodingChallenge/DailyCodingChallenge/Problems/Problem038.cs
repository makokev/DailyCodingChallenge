using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem038 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM038_DESCRIPTION;
		protected override int Number => 38;

		protected override void Run()
		{
			Console.Write("Insert the board dimension (NxN): ");
			int n;
			while (!int.TryParse(Console.ReadLine(), out n))
			{
				Console.WriteLine("Parsing error, retry.");
				Console.Write("Insert the board dimension (NxN): ");
			}

			// init domains
			List<List<int>> domains = new List<List<int>>();
			for(int i = 0; i < n; i++)
			{
				domains.Add(new List<int>());
				for(int j = 0; j < n; j++)
				{
					domains[i].Add(j);
				}
			}

			int arrangements = GetQueensArrangements(domains);
			string message = (arrangements > 0) ? arrangements.ToString() : "no possible configuration.";
			Console.WriteLine("Queen arrangements in {0}x{0} board: {1}.", n, message);
		}

		private int GetQueensArrangements(List<List<int>> domains)
		{
			if (domains.Count == 0)
				return 1;
			// Get the smallest domain
			int selectedQueen = 0;
			for(int i = 0; i < domains.Count; i++)
			{
				if (domains[i].Count < domains[selectedQueen].Count)
					selectedQueen = i;
			}
			
			// count possible queen arrangements
			int count = 0;
			foreach(int availablePosition in domains[selectedQueen])
			{
				// clone domains
				List<List<int>> newDomains = new List<List<int>>();
				foreach (List<int> domain in domains)
					newDomains.Add(domain.ToList());

				// update domains
				for (int i = 0; i < domains.Count; i++)
				{
					newDomains[i].Remove(availablePosition);						// remove column
					newDomains[i].Remove( i - selectedQueen + availablePosition); // remove diagonal 1 \
					newDomains[i].Remove(-i + selectedQueen + availablePosition); // remove diagonal 2 /
				}
				newDomains.RemoveAt(selectedQueen);                                 // remove row

				// recursive invocation
				count += GetQueensArrangements(newDomains);
			}
			return count;
		}
	}
}
