using DailyCodingChallenge.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems.Utility
{
	class SortedList<ValueType> : IEnumerable<ValueType> where ValueType : IComparable<ValueType>
	{
		private LinkedNode<ValueType> Root { get; set; }
		public int Count { get; private set; }
		public bool IncreasingOrder { get; private set; }

		public SortedList(bool increasingOrder)
		{
			Root = null;
			Count = 0;
			IncreasingOrder = increasingOrder;
		}

		public SortedList() : this(true) { }

		/// <summary>
		/// Return a new SortedList in with the ordering in reverted.
		/// </summary>
		/// <returns>The reversed SortedList</returns>
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
			LinkedNode<ValueType> newNode = new LinkedNode<ValueType>(value);
			if (null == Root)
				Root = newNode;
			else if ((newNode.Value.CompareTo(Root.Value) <= 0 && IncreasingOrder) || (newNode.Value.CompareTo(Root.Value) >= 0 && !IncreasingOrder))
			{
				newNode.Next = Root;
				Root = newNode;
			}
			else
			{
				LinkedNode<ValueType> temp;
				LinkedNode<ValueType> node = Root;
				LinkedNode<ValueType> prev = null;
				bool inserted = false;
				while (node != null && !inserted)
				{
					if ((newNode.CompareTo(node) <= 0 && IncreasingOrder) || (newNode.CompareTo(node) >= 0 && !IncreasingOrder))
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

		public void AddAll(IEnumerable<ValueType> list)
		{
			foreach (ValueType value in list)
				Add(value);
		}

		/// <summary>
		/// Remove the first occurrence of the value.
		/// </summary>
		/// <param name="value">The value that needs to be removed.</param>
		/// <returns>True if it is removed, otherwise false.</returns>
		public bool Remove(ValueType value)
		{
			LinkedNode<ValueType> node = Root;
			LinkedNode<ValueType> prev = null;
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

		public bool RemoveAt(int index)
		{
			LinkedNode<ValueType> node = Root;
			LinkedNode<ValueType> prev = null;
			int i = 0;
			while (node != null && i < index)
			{
				prev = node;
				node = node.Next;
				i++;
			}

			if (i == index && node != null)
			{
				if (null == prev)
					Root = node.Next;
				else
					prev.Next = node.Next;
				Count--;
				return true;
			}
			return false;
		}

		public List<ValueType> ToList()
		{
			List<ValueType> list = new List<ValueType>();
			LinkedNode<ValueType> node = Root;
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

		public IEnumerator<ValueType> GetEnumerator()
		{
			LinkedNode<ValueType> node = Root;
			while (null != node)
			{
				yield return node.Value;
				node = node.Next;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public ValueType this[int index]
		{
			get
			{
				if (index >= Count || index < 0)
					throw new IndexOutOfRangeException();
				LinkedNode<ValueType> node = Root;
				int i = 0;
				while (node != null && i < index)
				{
					node = node.Next;
					i++;
				}
				return node.Value;
			}
			set
			{
				if (index >= Count || index < 0)
					throw new IndexOutOfRangeException();
				LinkedNode<ValueType> node = Root;
				int i = 0;
				while (node != null && i < index)
				{
					node = node.Next;
					i++;
				}
				node.Value = value;
			}
		}


	}
}
