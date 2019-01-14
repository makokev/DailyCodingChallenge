using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems.Utility
{
	class Node<ValueType>
	{
		private ValueType _value;
		private Node<ValueType> _leftChild = null;
		private Node<ValueType> _rightChild = null;

		public Node<ValueType> Left => _leftChild;
		public Node<ValueType> Right => _rightChild;
		public ValueType Val => _value;

		public Node(ValueType value)
		{
			_value = value;
		}

		public Node(ValueType value, Node<ValueType> leftChild) : this(value)
		{
			_leftChild = leftChild;
		}

		public Node(ValueType value, Node<ValueType> leftChild, Node<ValueType> rightChild) : this(value, leftChild)
		{
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

		public void PrintTree() {
			this.PrintTree("", true);
		}

		public void PrintTree(String indent, bool last)
		{
			Console.WriteLine(indent + "+- " + Val);
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
