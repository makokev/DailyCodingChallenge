using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Utility
{
	class DoubleLinkedList<ValueType> : IEnumerable<ValueType> where ValueType : IComparable<ValueType>
	{
		public DoubleLinkedNode<ValueType> First { get; set; }
		public DoubleLinkedNode<ValueType> Last { get; set; }
		public int Count { get; set; }

		public void AddFirst(ValueType value)
		{
			DoubleLinkedNode<ValueType> node = new DoubleLinkedNode<ValueType>(value);
			if (0 == Count)
				Last = node;
			else
			{
				node.Next = First;
				node.Next.Previous = node;
			}
			First = node;
			Count++;
		}

		public void AddLast(ValueType value)
		{
			DoubleLinkedNode<ValueType> node = new DoubleLinkedNode<ValueType>(value);
			if (0 == Count)
				First = node;
			else
			{
				node.Previous = Last;
				node.Previous.Next = node;
			}
			Last = node;
			Count++;
		}

		public void RemoveNode(DoubleLinkedNode<ValueType> node)
		{
			if (First.Equals(node))
				RemoveFirst();
			else if (Last.Equals(node))
				RemoveLast();
			else
			{
				DoubleLinkedNode<ValueType> temp = node.Previous;
				node.Previous.Next = node.Next;
				node.Next.Previous = temp;
				Count--;
			}
		}

		public bool RemoveFirst()
		{
			if (Count > 0)
			{
				First = First.Next;
				if (1 == Count)
					Last = First;
				else
					First.Previous = null;
				Count--;
				return true;
			}
			return false;
		}

		public bool RemoveLast()
		{
			if (Count > 0)
			{
				Last = Last.Previous;
				if (1 == Count)
					First = Last;
				else
					Last.Next = null;
				Count--;
				return true;
			}
			return false;
		}

		public IEnumerator<ValueType> GetEnumerator()
		{
			DoubleLinkedNode<ValueType> node = First;
			while (null != node)
			{
				yield return node.Value;
				node = node.Next;
			}
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public override string ToString() => this.ToList().Print();
	}

	class DoubleLinkedNode<ValueType> : IComparable<DoubleLinkedNode<ValueType>> where ValueType : IComparable<ValueType>
	{
		public ValueType Value { get; set; }
		public DoubleLinkedNode<ValueType> Previous { get; set; }
		public DoubleLinkedNode<ValueType> Next { get; set; }

		public DoubleLinkedNode(ValueType value, DoubleLinkedNode<ValueType> previous = null, DoubleLinkedNode<ValueType> next = null)
		{
			Value = value;
			Previous = previous;
			Next = next;
		}

		public int CompareTo(DoubleLinkedNode<ValueType> other)
		{
			if (null == other)
				throw new ArgumentNullException("other", "the parameter is null.");
			return Value.CompareTo(other.Value);
		}

		public bool Equals(DoubleLinkedNode<ValueType> other) =>  CompareTo(other) == 0;

		public override bool Equals(object obj)
		{
			DoubleLinkedNode<ValueType> other = obj as DoubleLinkedNode<ValueType>;
			return (null == other) ? false : Equals(other);
		}

		public override int GetHashCode()
		{
			var hashCode = 650495386;
			hashCode = hashCode * -1521134295 + EqualityComparer<ValueType>.Default.GetHashCode(Value);
			hashCode = hashCode * -1521134295 + EqualityComparer<DoubleLinkedNode<ValueType>>.Default.GetHashCode(Previous);
			hashCode = hashCode * -1521134295 + EqualityComparer<DoubleLinkedNode<ValueType>>.Default.GetHashCode(Next);
			return hashCode;
		}

		public override string ToString()
		{
			return String.Format("Node({0})", Value.ToString());
		}
	}
}
