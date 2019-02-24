using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Utility
{
	class Sudoku
	{
		public SudokuCell[,] Cells { get; private set; }
		private List<SudokuSquare> _squares;
		private List<SudokuRow> _rows;
		private List<SudokuColumn> _columns;

		public List<SudokuSquare> Squares { get => _squares; }
		public List<SudokuRow> Rows { get => _rows; }
		public List<SudokuColumn> Columns { get => _columns; }

		public void Print()
		{
			StringBuilder sb = new StringBuilder();
			for(int i = 0; i < Cells.GetLength(1); i++)
				sb.Append(" ---");

			for (int x = 0; x < Cells.GetLength(0); x++)
			{
				Console.WriteLine(sb.ToString());
				for(int y = 0; y < Cells.GetLength(1); y++)
				{
					Console.Write("| {0} ", Cells[x, y].Value);
				}
				Console.WriteLine("|");
			}
			Console.WriteLine("{0}\n", sb.ToString());
		}

		public static List<int> DefaultDomain = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		public Sudoku() : this(new List<SudokuCell>()) { }

		public Sudoku(IEnumerable<SudokuCell> cells)
		{
			// init rows, columns and squares
			_squares = new List<SudokuSquare>();
			_rows = new List<SudokuRow>();
			_columns = new List<SudokuColumn>();
			for(int index = 0; index < 9; index++)
			{
				_rows.Add(new SudokuRow(index, DefaultDomain.ToList()));
				_columns.Add(new SudokuColumn(index, DefaultDomain.ToList()));
			}

			for (int x = 0, index = 0; x < 9; x+=3)
			{
				for (int y = 0; y < 9; y+=3)
				{
					_squares.Add(new SudokuSquare(x, y, index, DefaultDomain.ToList()));
					index++;
				}
			}
			
			// init cells
			Cells = new SudokuCell[9,9];
			for(int x = 0; x < Cells.GetLength(0); x++)
			{
				for (int y = 0; y < Cells.GetLength(1); y++)
				{
					int z = GetSquareIndex(x, y);
					Cells[x,y] = new SudokuCell(Rows[x], Columns[y], Squares[z]);
				}
			}

			foreach(SudokuCell cell in cells)
			{
				if(DefaultDomain.Contains(cell.Value))
					Cells[cell.Row, cell.Column].Value = cell.Value;
			}

		}

		private int GetSquareIndex(int x, int y)
		{
			foreach(SudokuSquare square in Squares)
			{
				if (square.ContainsPosition(x,y))
					return square.Index;
			}
			throw new ArgumentOutOfRangeException("x and y","The values do not correspon at any SudokuCells");
		}

		public bool IsCompleted
		{
			get{
				bool completed = true;
				foreach (SudokuCell cell in Cells)
				{
					if (!cell.IsValueSetted)
						return false;
				}
				return completed;
			}
		}

		public bool IsCorrect
		{
			get
			{
				bool correct = IsCompleted;
				foreach(SudokuCell cell in Cells)
				{
					correct = correct && !IsAlreadyInRow(cell.Value, cell.Row);
					correct = correct && !IsAlreadyInColumn(cell.Value, cell.Column);
					correct = correct && !IsAlreadyInRow(cell.Value, cell.Square);
				}
				return correct;
			}
		}

		public bool IsAlreadyInRow(int value, int rowIndex)
		{
			int countValue = 0;
			foreach (Couple<int> pos in Rows[rowIndex].Positions)
			{
				if (Cells[pos.First, pos.Second].Value == value)
					countValue++;
			}
			return (countValue > 1);
		}

		public bool IsAlreadyInColumn(int value, int columnIndex)
		{
			int countValue = 0;
			foreach(Couple<int> pos in Columns[columnIndex].Positions)
			{
				if (Cells[pos.First, pos.Second].Value == value)
					countValue++;
			}
			return (countValue > 1);
		}

		public bool IsAlreadyInSquare(int value, int squareIndex)
		{
			int countValue = 0;
			foreach (Couple<int> position in Squares[squareIndex].Positions)
			{
				if (Cells[position.First, position.Second].Value == value)
						countValue++;
			}
			return (countValue > 1);
		}

	}

	abstract class SudokuStructure
	{
		public int Index { get; protected set; }
		private readonly List<int> _domain;
		public List<int> Domain { get => _domain; }
		protected List<Couple<int>> _coveredPositions;
		public List<Couple<int>> Positions { get => _coveredPositions; }


		protected SudokuStructure(int id, List<int> domain)
		{
			Index = id;
			_domain = domain;
			_coveredPositions = GetCovederPosition();
		}

		protected abstract List<Couple<int>> GetCovederPosition();

	}

	class SudokuSquare : SudokuStructure
	{
		private Couple<int> StartingCell { get; set; }
		public SudokuSquare(int startingX, int startingY, int index, List<int> domain) : base(index, domain)
		{
			StartingCell = new Couple<int>(startingX, startingY);
			for (int row = 0; row < 3; row++)
			{
				for (int column = 0; column < 3; column++)
				{
					_coveredPositions.Add(new Couple<int>(StartingCell.First + row, StartingCell.Second + column));
				}
			}
			
		}

		public bool ContainsPosition(Couple<int> position) => ContainsPosition(position.First, position.Second);

		public bool ContainsPosition(int x, int y) => StartingCell.First <= x &&
														x < StartingCell.First + 3 &&
														StartingCell.Second <= y &&
														y < StartingCell.Second + 3;

		protected override List<Couple<int>> GetCovederPosition() => new List<Couple<int>>();

	}

	class SudokuRow : SudokuStructure
	{
		public SudokuRow(int index, List<int> domain) : base(index, domain) { }

		protected override List<Couple<int>> GetCovederPosition()
		{
			List<Couple<int>> coveredPositions = new List<Couple<int>>();
			for (int column = 0; column < 9; column++)
				coveredPositions.Add(new Couple<int>(Index, column));
			return coveredPositions;
		}

	}

	class SudokuColumn : SudokuStructure
	{
		public SudokuColumn(int index, List<int> domain) : base(index, domain) { }

		protected override List<Couple<int>> GetCovederPosition()
		{
			List<Couple<int>> coveredPositions = new List<Couple<int>>();
			for (int row = 0; row < 9; row++)
				coveredPositions.Add(new Couple<int>(row, Index));
			return coveredPositions;
		}
	}

	class SudokuCell
	{
		private Couple<int> Coordinates { get; set; }
		private int _value;
		public int Row => Coordinates.First;
		public int Column => Coordinates.Second;
		public int Square { get; private set; }
		public bool IsValueSetted { get; set; }
		public int Value
		{
			get => _value;
			set
			{
				IsValueSetted = true;
				RemoveFromDomain(value);
				_value = value;
			}
		}

		private SudokuRow TheRow { get; set; }
		private SudokuColumn TheColumn { get; set; }
		private SudokuSquare TheSquare { get; set; }

		public SudokuCell(int value, SudokuRow theRow, SudokuColumn theColumn, SudokuSquare theSquare) 
			: this(theRow, theColumn, theSquare)
		{
			Value = value;
		}

		public SudokuCell(SudokuRow theRow, SudokuColumn theColumn, SudokuSquare theSquare)
		{
			TheRow = theRow;
			TheColumn = theColumn;
			TheSquare = theSquare;
			Coordinates = new Couple<int>(TheRow.Index, TheColumn.Index);
			Square = TheSquare.Index;
			IsValueSetted = false;
		}

		public List<int> Domain
		{
			get
			{
				List<int> cellDomain = new List<int>();//TheRow.Domain;
				//cellDomain.Intersect(TheColumn.Domain);
				//cellDomain.Intersect(TheSquare.Domain);
				foreach(int domainValue in TheRow.Domain)
				{
					if (TheColumn.Domain.Contains(domainValue) && TheSquare.Domain.Contains(domainValue))
						cellDomain.Add(domainValue);
				}
				return cellDomain;
			}
		}

		public void RemoveFromDomain(int domainValue)
		{
			TheRow.Domain.Remove(domainValue);
			TheColumn.Domain.Remove(domainValue);
			TheSquare.Domain.Remove(domainValue);
		}
	}
}
