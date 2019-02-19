using DailyCodingChallenge.Problems.Utility;
using DailyCodingChallenge.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems
{
	class Problem050 : Problem
	{
		protected override string Description => ProblemDescription.PROBLEM050_DESCRIPTION;
		protected override int Number => 50;

		protected override void Run()
		{
			BinaryCompleteNode<string> root = new BinaryCompleteNode<string>("/", new BinaryCompleteNode<string>("+", new BinaryCompleteNode<string>("5"), new BinaryCompleteNode<string>("5")), new BinaryCompleteNode<string>("+", new BinaryCompleteNode<string>("0.25"), new BinaryCompleteNode<string>("0.25")));
			Console.WriteLine("The operations tree:");
			root.PrintTree();

			double result = IntNodeEvaluation(root);
			Console.WriteLine("Result: {0}.", result);
		}

		private double IntNodeEvaluation(BinaryCompleteNode<string> root)
		{
			if (null == root)
				throw new ArgumentNullException("root", "the parameter is null.");
			double result;
			string val = root.Value;

			if (root.HasChildren)
			{
				BinaryCompleteNode<string> leftNode = (BinaryCompleteNode<string>)root.Left;
				double leftCount = IntNodeEvaluation(leftNode);
				BinaryCompleteNode<string> rightNode = (BinaryCompleteNode<string>)root.Right;
				double rightCount = IntNodeEvaluation(rightNode);

				switch (val)
				{
					case "+":
						result = leftCount + rightCount;
						break;
					case "-":
						result = leftCount - rightCount;
						break;
					case "*":
						result = leftCount * rightCount;
						break;
					case "/":
						result = leftCount / rightCount;
						break;
					default:
						throw new ArgumentOutOfRangeException("root.value", "value founded: '"+val+"' (possible values: '+', '-', '*', '/')");
				}
				return result;
			}
			else if(double.TryParse(val, out double n))
					return n;
			else
				throw new ArgumentException("root.value", "the parameter is not a numeric value.");
		}
	}
}
