using System;
using System.Collections.Generic;
using System.Linq;


namespace DailyCodingChallenge.Problems.Utility
{
	class Node<ValueType>
	{
		protected readonly List<Node<ValueType>> _children = new List<Node<ValueType>>();
		public ValueType Value { get; protected set; }

		/// <summary>
		/// Gives a copy of the children nodes. Updates at this copy doesn't affect the original one.<para/>
		/// To update children use: AddChild(child) / RemoveChild(child) / RemoveChildAt(index).
		/// </summary>
		public List<Node<ValueType>> Children => _children.ToList();
		public Node<ValueType> ParentNode { get; protected set; }
		public int ChildrenCount => Children.Count;
		public bool IsLeaf => ChildrenCount == 0;

		public Node(ValueType value, Node<ValueType> parent = null)
		{
			Value = value;
			ParentNode = parent;
		}
		
		public void AddChild(Node<ValueType> child)
		{
			child.ParentNode = this;
			_children.Add(child);
		}

		public void RemoveChild(Node<ValueType> child)
		{
			if (_children.Contains(child))
			{
				_children.Remove(child);
				child.ParentNode = null;
			}
		}

		public void RemoveChildAt(int index) => _children.RemoveAt(index);

		public Node<ValueType> GetChildrenAt(int index) => _children[index];

		public void PrintTree()
		{
			PrintTree("", true);
		}

		public void PrintTree(String indent, bool last)
		{
			Console.WriteLine(indent + "+- " + Value);
			indent += last ? "   " : "|  ";

			for (int i = 0; i < ChildrenCount - 1; i++)
				_children[i].PrintTree(indent, false);
			if(ChildrenCount > 0)
				_children[ChildrenCount-1].PrintTree(indent, true);
			
		}

		public override string ToString() => "Node("+Value+")";

	}
}
