using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems.Utility
{
	class SortedList<ValueType> where ValueType : IComparable<ValueType>
	{
		private SortedNode Root { get; set; }
		public int Count { get; private set; }
		public bool IncreasingOrder { get; private set; }

		public SortedList(bool increasingOrder)
		{
			Root = null;
			Count = 0;
			IncreasingOrder = increasingOrder;
		}

		public SortedList() : this(true) { }

		public SortedList<ValueType> RevertList()
		{
			SortedList<ValueType> reversed = new SortedList<ValueType>(!IncreasingOrder);
			foreach(ValueType value in ToList())
			{
				reversed.Add(value);
			}
			return reversed;
		}

		/// <summary>
		/// Sorted insertion of the new value.
		/// </summary>
		/// <param name="value">The value that needs to be added.</param>
		public void Add(ValueType value)
		{
			SortedNode newNode = new SortedNode(value);
			if (null == Root)
				Root = newNode;
			else if ((newNode.Value.CompareTo(Root.Value) <= 0 && IncreasingOrder) || (newNode.Value.CompareTo(Root.Value) >= 0 && !IncreasingOrder))
			{
				newNode.Next = Root;
				Root = newNode;
			}
			else
			{
				SortedNode temp;
				SortedNode node = Root;
				SortedNode prev = null;
				bool inserted = false;
				while (node != null && !inserted)
				{
					if ((newNode.Value.CompareTo(node.Value) <= 0 && IncreasingOrder) || (newNode.Value.CompareTo(node.Value) >= 0 && !IncreasingOrder))
					{
						temp = prev.Next;
						prev.Next = newNode;
						newNode.Next = temp;
						inserted = true;
					}
					else
					{
						prev = node;
						node = node.Next;
					}
				}
				if (!inserted)
					prev.Next = newNode;
			}
			Count++;
		}
		
		/// <summary>
		/// Remove the first occurrence of the value.
		/// </summary>
		/// <param name="value">The value that needs to be removed.</param>
		/// <returns>True if it is removed, otherwise false.</returns>
		public bool Remove(ValueType value)
		{
			SortedNode node = Root;
			SortedNode prev = null;
			while(node != null)
			{
				if (value.CompareTo(node.Value) < 0)
					return false;
				if(value.CompareTo(node.Value) == 0)
				{
					if (null == prev)
						Root = node.Next;
					else
						prev.Next = node.Next;
					Count--;
					return true;
				}
				prev = node;
				node = node.Next;
			}
			return false;
		}

		public List<ValueType> ToList()
		{
			List<ValueType> list = new List<ValueType>();
			SortedNode node = Root;
			while(null != node)
			{
				list.Add(node.Value);
				node = node.Next;
			}
			return list;
		}

		/// <summary>
		/// Return the first value if exists, otherwise an Exception is throw.
		/// </summary>
		/// <returns></returns>
		public ValueType First()
		{
				if (0 == Count)
					throw new Exception("No such element. The list is empty.");
				return Root.Value;
		}

		private bool RemoveFirst()
		{
			if (0 == Count)
				return false;
			Root = Root.Next;
			Count--;
			return true;
		}

		class SortedNode : IComparable<SortedNode>
		{
			public ValueType Value { get; private set; }
			public SortedNode Next { get; set; }

			public SortedNode(ValueType value)
			{
				Value = value;
				Next = null;
			}
			
			public int CompareTo(SortedNode other) => Value.CompareTo(other.Value);
		}
	}
}
