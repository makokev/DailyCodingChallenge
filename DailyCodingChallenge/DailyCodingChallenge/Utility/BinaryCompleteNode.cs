using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Utility
{
	/// <summary>
	/// Represents a BinaryNode with 0 or 2 children (complete internal node or leaf).
	/// </summary>
	/// <typeparam name="ValueType">The value's type</typeparam>
	class BinaryCompleteNode<ValueType> : BinaryNode<ValueType>
	{
		public BinaryCompleteNode(ValueType value) : this(value, null, null) { }

		public BinaryCompleteNode(ValueType value, BinaryCompleteNode<ValueType> leftChild, BinaryCompleteNode<ValueType> rightChild) : base(value, leftChild, rightChild)
		{
			if (null == leftChild && null != rightChild)
				throw new ArgumentNullException("leftChild");
			if (null == rightChild && null != leftChild)
				throw new ArgumentNullException("rightChild");
		}

		public bool HasChildren => ChildrenCount() > 0;
	}
}
