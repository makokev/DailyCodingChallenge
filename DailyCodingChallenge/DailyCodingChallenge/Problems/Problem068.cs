using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem068 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM068_DESCRIPTION;
		protected override int Number => 68;

		protected override void Run()
		{
			// init
			List<Couple<int>> bishopPositions = new List<Couple<int>>()
			{
				new Couple<int>(0,0),
				new Couple<int>(1,2),
				new Couple<int>(2,2),
				new Couple<int>(4,0)
			};
			
			// calculate
			int attackNumber = GetAttackNumber(bishopPositions);
			Console.WriteLine("The number of attacks are: {0}.", attackNumber);
		}

		private int GetAttackNumber(List<Couple<int>> bishopPositions)
		{
			int count = 0;
			List<Couple<Couple<int>>> bishopsAttaks = new List<Couple<Couple<int>>>();
			int mainDiagonal, secondDiagonal;
			foreach(Couple<int> bishopPosition in bishopPositions)
			{
				mainDiagonal = bishopPosition.First + bishopPosition.Second;
				secondDiagonal = bishopPosition.First - bishopPosition.Second;
				bishopsAttaks.Add(new Couple<Couple<int>>(bishopPosition, new Couple<int>(mainDiagonal, secondDiagonal)));
			}

			while(bishopsAttaks.Count > 0)
			{
				Couple<Couple<int>> bishopAttak = bishopsAttaks[0];
				bishopsAttaks.RemoveAt(0);
				foreach(Couple<Couple<int>> otherAttak in bishopsAttaks)
				{
					if (bishopAttak.Second.First == otherAttak.Second.First || // mainDiagonal
						bishopAttak.Second.Second == otherAttak.Second.Second) // secondDiagonal
					{
						Console.WriteLine("Bishops in {0} attaks bishop in {1}.", bishopAttak.First, otherAttak.First);
						count++;
					}
				}
			}

			return count;
		}
	}
}
