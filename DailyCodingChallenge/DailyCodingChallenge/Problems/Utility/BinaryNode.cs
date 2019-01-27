using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems.Utility
{
	class BinaryNode<ValueType>
	{
		private BinaryNode<ValueType> _leftChild;
		private BinaryNode<ValueType> _rightChild;

		public virtual BinaryNode<ValueType> Left { get { return _leftChild; } protected set { _leftChild = value; } }
		public BinaryNode<ValueType> Right => _rightChild;
		public ValueType Value { get; private set; }

		public BinaryNode(ValueType value, BinaryNode<ValueType> leftChild = null) : this(value, leftChild, null){ }

		public BinaryNode(ValueType value, BinaryNode<ValueType> leftChild, BinaryNode<ValueType> rightChild)
		{
			Value = value;
			_leftChild = leftChild;
			_rightChild = rightChild;
		}

		public int ChildrenCount()
		{
			int count = 0;
			if (null != Left)
				count++;
			if (null != Right)
				count++;
			return count;
		}

		public void PrintTree()
		{
			PrintTree("", true);
		}

		public void PrintTree(String indent, bool last)
		{
			Console.WriteLine(indent + "+- " + Value);
			indent += last ? "   " : "|  ";

			if(1 == ChildrenCount())
				Left.PrintTree(indent, true);
			else if(2 == ChildrenCount())
			{
				Left.PrintTree(indent, false);
				Right.PrintTree(indent, true);
			}
		}
	}
}
