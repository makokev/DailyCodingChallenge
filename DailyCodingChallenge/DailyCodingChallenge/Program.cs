using System;
using System.Collections.Generic;

namespace DailyCodingChallenge
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.SetWindowSize(Console.WindowWidth, Console.WindowHeight + 5);
			DateTime startDate = new DateTime(2019, 1, 1);

			double doubledays = DateTime.Now.Subtract(startDate).TotalDays;
			int totalDays = (int)doubledays;
			totalDays += (doubledays > totalDays) ? 1 : 0;
			Console.WriteLine("Project start date: {0}\t\t\t\t\tDay:{1}\n", startDate.ToString().Split(' ')[0], totalDays);

			bool continueWhile = true;
			
			while (continueWhile)
			{
				bool parsingSuccessed = false;
				int problemNumber = 1;
				Console.WriteLine("List of problems:");

				// Printing problem's names
				List<Type> types = Problem.GetProblemTypes();
				int count = types.Count;
				for (int i = 1; i <= count; i++)
				{
					Console.Write(types[i-1].ToString().Split('.')[2]+"\t");
					if (i % 5 == 0)
						Console.WriteLine();
				}

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
					{
						p.Start();
						Console.Write("Would you like run another problem (y/n)? ");
						string response = Console.ReadLine();
						if (!response.ToLower().Equals("y"))
						{
							continueWhile = false;
							Console.WriteLine("Exit.");
						}
					}
					else
						Console.WriteLine("Problem " + problemNumber + " doesn't exist.\n");
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
