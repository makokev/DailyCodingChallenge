using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingChallenge
{
	class Program
	{
		static void Main(string[] args)
		{
			bool continueWhile = true;
			while (continueWhile)
			{
				bool parsingSuccessed = false;
				int problemNumber = 1;
				Console.WriteLine("List of problems:");

				// Printing problem's names
				foreach(Type t in Problem.GetProblemTypes())
					Console.WriteLine(t.ToString().Split('.')[2]);

				Console.WriteLine();

				// Parsing problem number
				while (!parsingSuccessed)
				{
					Console.Write("Insert the number of the problem that you would resolve (to exit: 0):");
					try
					{
						problemNumber = Convert.ToInt32(Console.ReadLine());
						parsingSuccessed = true;
					}
					catch (Exception)
					{
						Console.WriteLine("Number parsing error. Retry.");
					}
				}
				if (0 != problemNumber)
				{
					Problem p = Problem.GetProblem(problemNumber);
					Console.WriteLine();

					// If the problem exists, run the implementation
					if (null != p)
						p.run();
					else
						Console.WriteLine("Problem " + problemNumber + " doesn't exist.");
					Console.WriteLine("\nEnd Problem.\n");
					Console.WriteLine("------------------------------------------------------------");
				}
				else
				{
					Console.WriteLine("Exit.");
					continueWhile = false;
				}
			}

			Console.Read();
		}
	}
	
}
