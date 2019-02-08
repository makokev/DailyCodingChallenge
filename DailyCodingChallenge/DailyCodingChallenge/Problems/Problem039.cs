using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem039 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM039_DESCRIPTION;
		protected override int Number => 39;

		private int _spaceDimension = 50;
		private const int ALIVE = 1;
		private const int DEAD = 0;
		private const int EMPTY = -1;

		protected override void Run()
		{
			int tics;

			// init space
			int[,] space = new int[_spaceDimension, _spaceDimension];
			for (int i = 0; i < space.GetLength(0); i++)
				for (int j = 0; j < space.GetLength(1); j++)
					space[i, j] = EMPTY;

			// instert tics
			Console.Write("Insert the number of tics: ");
			while (!int.TryParse(Console.ReadLine(), out tics))
			{
				Console.WriteLine("Parse error, retry.");
				Console.Write("Insert the number of tics: ");
			}

			InsertCells("alive", ALIVE, ref space);
			InsertCells("dead", DEAD, ref space);


			// print cells:
			Console.WriteLine("InitialConfiguration:");
			PrintCells(ref space);

			// executing tics
			for(int k = 0; k < tics; k++)
			{
				int[,] newSpace = new int[_spaceDimension, _spaceDimension];
				for (int i = 0; i < space.GetLength(0); i++)
				{ 
					for (int j = 0; j < space.GetLength(1); j++)
					{
						if (space[i, j] == EMPTY)
							newSpace[i, j] = EMPTY;
						else
						{
							int aliveNeighbours = GetAliveNeighboursCount(i, j, ref space);
							if(space[i,j] == ALIVE)
								newSpace[i, j] = (aliveNeighbours < 2 || aliveNeighbours >= 4) ? DEAD : ALIVE;
							else
								newSpace[i, j] = (3 == aliveNeighbours) ? ALIVE : DEAD;
						}
					}
				}
				space = newSpace;
				PrintCells(ref space);
				System.Threading.Thread.Sleep(1000);
			}	
		}

		private int GetAliveNeighboursCount(int x, int y, ref int[,] space)
		{
			int aliveNeighboursCount = 0;
			foreach(Couple<int> c in GetAvailableNeighbours(x, y))
				if(ALIVE == space[c.X, c.Y])
					aliveNeighboursCount++;
			return aliveNeighboursCount;
		}

		private List<Couple<int>> GetAvailableNeighbours(int x, int y)
		{
			List<Couple<int>> list = new List<Couple<int>>();
			for(int i = -1; i <= 1; i++)
			{
				for(int j = -1; j <= 1; j++)
				{
					if(i != 0 || j != 0)
					{
						Couple<int> c = new Couple<int>(x + i, y + j);
						if (c.X >= 0 && c.X < _spaceDimension && c.Y >= 0 && c.Y < _spaceDimension)
							list.Add(c);
					}
				}
			}
			return list;
		}

		/// <summary>
		/// Insert a cell of type "type" (ALIVE/DEAD) into the space. The cell is substituted if already present in the position.
		/// </summary>
		/// <param name="stringType">string representation of the cell's type (alive/dead).</param>
		/// <param name="type">int representation fo the cell's type (0=ALIVE, 1=DEAD).</param>
		/// <param name="space">the space in whitch the cell must be inserted.</param>
		private void InsertCells(string stringType, int type, ref int[,] space)
		{
			// insert cells number
			Console.Write("Insert the number of initial {0} cells: ", stringType);
			int aliveCells;
			while (!int.TryParse(Console.ReadLine(), out aliveCells))
			{
				Console.WriteLine("Parse error, retry.");
				Console.Write("Insert the number of initial {0} cells: ", stringType);
			}

			// insert cells
			for (int k = 0; k < aliveCells; k++)
			{
				bool read;
				int x = 0, y = 0;
				do
				{
					Console.Write("Insert {0}° {1} cell position (format: x:y): ", k + 1, stringType);
					string position = Console.ReadLine();
					string x_string = position.Split(':')[0];
					string y_string = position.Split(':')[1];
					Console.WriteLine("Position read: x={0}, y={1}.", x_string, y_string);
					read = int.TryParse(x_string, out x) && int.TryParse(y_string, out y);
					if (!read)
						Console.WriteLine("Parse error, retry.");
				} while (!read);

				bool checkDimension;
				do
				{
					checkDimension = true;
					int min = Math.Min(x, y);
					int max = Math.Max(x, y);
					if (min >= 0 && max < _spaceDimension)
						space[x, y] = type;
					else
					{
						checkDimension = false;
						IncrementSpaceDimension(ref space);
						x = x + (int)Math.Truncate(_spaceDimension / 2.0);
						y = y + (int)Math.Truncate(_spaceDimension / 2.0);
					}
				} while (!checkDimension);
			}
		}

		private void PrintCells(ref int[,] space)
		{
			// detecting x_min, x_max, y_min and y_max to print out only necessary position
			int x_min = int.MaxValue, x_max = int.MinValue, y_min = int.MaxValue, y_max = int.MinValue;
			for (int i = 0; i < space.GetLength(0); i++)
			{
				for (int j = 0; j < space.GetLength(1); j++)
				{
					if (space[i, j] != EMPTY)
					{
						x_min = (i < x_min) ? i : x_min;
						x_max = (i > x_max) ? i : x_max;
						y_min = (j < y_min) ? j : y_min;
						y_max = (j > y_max) ? j : y_max;
					}
				}
			}

			// print table header
			Console.Write(" ");
			for (int i = 0; i <= (y_max - y_min); i++)
				Console.Write("-");
			Console.WriteLine();

			// print space
			char c = '\0';
			for (int i = x_min; i <= x_max; i++)
			{
				Console.Write("|"); // line header
				for (int j = y_min; j <= y_max; j++)
				{
					switch (space[i, j])
					{
						case ALIVE:
							c = '*';
							break;
						case DEAD:
							c = '.';
							break;
						default:
							c = ' ';
							break;
					}
					Console.Write(c);
				}
				Console.WriteLine("|"); // line footer
			}

			// print table footer
			Console.Write(" ");
			for (int i = 0; i <= (y_max - y_min); i++)
				Console.Write("-");
			Console.WriteLine();
		}

		private void IncrementSpaceDimension(ref int[,] space)
		{
			int newSpaceDimension = _spaceDimension * 2;
			int[,] newSpace = new int[newSpaceDimension, newSpaceDimension];
			for (int i = 0; i < _spaceDimension; i++)
				for (int j = 0; j < _spaceDimension; j++)
					newSpace[i + (int)Math.Truncate(newSpaceDimension / 2.0), j + (int)Math.Truncate(newSpaceDimension / 2.0)] = space[i, j];
			_spaceDimension = newSpaceDimension;
			space = newSpace;
		}
	}
}
