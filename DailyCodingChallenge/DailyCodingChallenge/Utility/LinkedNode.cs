using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Utility
{
	/// <summary>
	/// It represents a node containing a value of type: <typeparamref name="ValueType"/> that can be linked in a list.
	/// <typeparamref name="ValueType"/> must implement the IComprarable(<typeparamref name="ValueType"/>) interface.
	/// </summary>
	/// <typeparam name="ValueType">The value's type</typeparam>
	class LinkedNode<ValueType> : IComparable<LinkedNode<ValueType>> where ValueType : IComparable<ValueType>
	{
		public ValueType Value { get; private set; }
		public LinkedNode<ValueType> Next { get; set; }

		public LinkedNode(ValueType value)
		{
			Value = value;
			Next = null;
		}

		public int CompareTo(LinkedNode<ValueType> other) => Value.CompareTo(other.Value);

	}

}
