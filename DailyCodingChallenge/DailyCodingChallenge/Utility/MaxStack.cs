using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Utility
{
	class MaxStack<ValueType> where ValueType : IComparable<ValueType>
	{
		// Linked list is very efficient in insert operations, more than the Stack<T> class
		// that sometimes needs to adjust its dimension with time: O(n).
		private LinkedNode<ValueType> StackRoot { get; set; }
		private LinkedNode<ValueType> StackMaxRoot { get; set; }

		public MaxStack()
		{
			StackRoot = null;
			StackMaxRoot = null;
		}

		/// <summary>
		/// Insert the value on top of the stack.
		/// Time: O(1).
		/// </summary>
		/// <param name="value"></param>
		public void Push(ValueType value)
		{
			LinkedNode<ValueType> valueNode = new LinkedNode<ValueType>(value);
			if (null == StackRoot)
			{
				StackRoot = valueNode;
				StackMaxRoot = new LinkedNode<ValueType>(value);
			}
			else
			{
				// push nello stack
				valueNode.Next = StackRoot;
				StackRoot = valueNode;

				// aggiornamento max
				ValueType max = (value.CompareTo(StackMaxRoot.Value) >= 0) ? value : StackMaxRoot.Value;
				LinkedNode<ValueType> maxNode = new LinkedNode<ValueType>(max);
				maxNode.Next = StackMaxRoot;
				StackMaxRoot = maxNode;
			}
		}

		/// <summary>
		/// Remove and return the first value in the stack (LIFO).
		/// If the stack is empty, default value is returned.
		/// Time: O(1).
		/// </summary>
		/// <returns>The first value in the stack, or default if it's empty</returns>
		public ValueType Pop()
		{
			if (null == StackRoot)
				return default(ValueType);
			ValueType value = StackRoot.Value;
			StackRoot = StackRoot.Next;
			StackMaxRoot = StackMaxRoot.Next;
			return value;
		}

		/// <summary>
		/// Return the max value in the stack.
		/// </summary>
		/// <returns>The max value in the stack</returns>
		public ValueType Max() => (StackMaxRoot != null) ? StackMaxRoot.Value : default(ValueType);
	}

	
}
