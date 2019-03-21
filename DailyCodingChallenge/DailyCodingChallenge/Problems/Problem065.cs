using System;

namespace DailyCodingChallenge.Problems
{
	class Problem065 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM065_DESCRIPTION;
		protected override int Number => 65;

		protected override void Run()
		{
			int[,] input_number = new int[,] {	{  1,  2,  3,  4,  5 },
												{  6,  7,  8,  9, 10 },
												{ 11, 12, 13, 14, 15 },
												{ 16, 17, 18, 19, 20 }
											 };

			int row = 0, col = 0;
			int minRow = 0, maxRow = input_number.GetLength(0) - 1;
			int minCol = 0, maxCol = input_number.GetLength(1) - 1;

			int currentMatrixPosition = 0; // 0: top, 1: right, 2: bottom, 3: left

			/*  
			 *  L			R
			 *  ^			^
			 *	|			|
			 *	01 02 03 04 05 -> T
			 *	16 17 18 19 06 
			 *  15 24 25 20 07
			 *  14 23 22 21 08
			 *  13 12 11 10 09 <- D
			 *	
			 *	T T T T T
			 *	L T T T R 
			 *  L R T R R
			 *  L D D R R
			 *  D D D D R 
			 * 
			 */

			for (int i = 0; i < input_number.Length; i++)
			{
				Console.WriteLine("{0}", input_number[row, col]);
				if(0 == currentMatrixPosition)
				{
					if(col < maxCol)
						col++;
					else
					{
						minRow++;
						row++;
						currentMatrixPosition = 1;
					}
				} else if(1 == currentMatrixPosition)
				{
					if(row < maxRow)
						row++;
					else
					{
						maxCol--;
						col--;
						currentMatrixPosition = 2;
					}
				} else if(2 == currentMatrixPosition)
				{
					if (col > minCol)
						col--;
					else
					{
						maxRow--;
						row--;
						currentMatrixPosition = 3;
					}
				}
				else if(3 == currentMatrixPosition)
				{
					if (row > minRow)
						row--;
					else
					{
						minCol++;
						col++;
						currentMatrixPosition = 0;
					}
				}
			}
		}
	}
}
