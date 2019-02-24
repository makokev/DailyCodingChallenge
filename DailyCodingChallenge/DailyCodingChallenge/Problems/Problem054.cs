using DailyCodingChallenge.Problems.Extensions;
using DailyCodingChallenge.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem054 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM054_DESCRIPTION;
		protected override int Number => 54;

		protected override void Run()
		{
			Sudoku sudoku = new Sudoku();

			FillSudoku(ref sudoku);

			if (null != sudoku)
			{
				Console.WriteLine("Printing the sudoku schema:");
				sudoku.Print();
				Console.WriteLine("Sudoku is completed: {0}", sudoku.IsCompleted);
				Console.WriteLine("Sudoku is correct: {0}", sudoku.IsCorrect);
			}
			else
				Console.WriteLine("Result: No solution founded.");
		}

		private void FillSudoku(ref Sudoku sudoku)
		{
			sudoku = SolveSudokuRecoursively(sudoku, 9);
		}

		private Sudoku SolveSudokuRecoursively(Sudoku sudoku, int minDomainSize)
		{
			// testing the termination condition
			while (!sudoku.IsCompleted)
			{
				// selecting the cell with the smallest domain (for efficiency)
				SudokuCell selectedCell = null;
				int domainSize = int.MaxValue;
				foreach (SudokuCell cell in sudoku.Cells)
				{
					if (!cell.IsValueSetted && cell.Domain.Count < domainSize)
					{
						selectedCell = cell;
						domainSize = cell.Domain.Count;
					}

					if (domainSize <= minDomainSize)
						break;
				}

				if (domainSize < minDomainSize)
					minDomainSize = domainSize;

				// applying eache domain value and generate the new sudoku schema
				foreach (int domainValue in selectedCell.Domain.ToList())
				{
					// cloning the Sudoku
					Sudoku newSudoku = new Sudoku(sudoku.Cells.ToEnumerable<SudokuCell>());

					// update schema and domains
					newSudoku.Cells[selectedCell.Row, selectedCell.Column].Value = domainValue;

					// reinvocation
					Sudoku s = SolveSudokuRecoursively(newSudoku, minDomainSize);
					if (s.IsCorrect)
						return s;
				}
			}
			return sudoku;
		}
	}
}
