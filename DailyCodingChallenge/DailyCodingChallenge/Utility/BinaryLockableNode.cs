using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Problems.Utility
{
	class BinaryLockableNode<ValueType>
	{
		public ValueType Value { get; private set; }
		public BinaryLockableNode<ValueType> Left { get; private set; }
		public BinaryLockableNode<ValueType> Right { get; private set; }
		public BinaryLockableNode<ValueType> Parent { get; private set; }

		public bool IsLocked { get; private set; }
		public int LockedDescendantsCount { get; private set; }

		public BinaryLockableNode(ValueType value, BinaryLockableNode<ValueType> leftChild = null) : this(value, leftChild, null) { }

		public BinaryLockableNode(ValueType value, BinaryLockableNode<ValueType> leftChild, BinaryLockableNode<ValueType> rightChild)
		{
			Value = value;
			if (null != leftChild)
				leftChild.Parent = this;
			if (null != rightChild)
				rightChild.Parent = this;

			Left = leftChild;
			Right = rightChild;
			Parent = null;
			IsLocked = false;
			LockedDescendantsCount = 0;
		}

		public bool Lock() {
			// check if:
			// 1. The current node is locked
			// 2. The current node is unlockable
			if (IsLocked || !IsLockableUnlockable())
				return false;

			// update
			IncreaseLockedCountParent();
			IsLocked = true;
			return true;

		}

		public bool Unlock() {
			// check if:
			// 1. The current node is locked
			// 2. The current node is unlockable
			if (!IsLocked || !IsLockableUnlockable())
				return false;

			// update
			DecreaseLockedCountParent();
			IsLocked = false;
			return true;
		}

		public bool IsLockableUnlockable() {
			// check if:
			// 1. Any Left descendant is locked
			// 2. Any Right descendant is locked
			// 3. Any ancestor is locked
			return !((null != Left  && Left.IsSubtreeLocked()) ||
					(null != Right && Right.IsSubtreeLocked()) ||
					(AreAncestorsLocked()));
		}

		private void DecreaseLockedCountParent() {
			UpdateLockedParent(-1);
		}

		private void UpdateLockedParent(int value) {
			BinaryLockableNode<ValueType> currentNode = Parent;
			while (null != currentNode)
			{
				currentNode.LockedDescendantsCount += value;
				currentNode = currentNode.Parent;
			}
		}

		private void IncreaseLockedCountParent() {
			UpdateLockedParent(1);
		}

		private bool AreAncestorsLocked() {
			BinaryLockableNode<ValueType> currentNode = this;
			while(null != currentNode.Parent)
			{
				if (currentNode.Parent.IsLocked)
					return true;
				currentNode = currentNode.Parent;
			}

			return false;
		}

		private bool IsSubtreeLocked() {
			if (IsLocked || (null != Left && Left.IsSubtreeLocked()) || (null != Right && Right.IsSubtreeLocked()))
				return true;
			
			return false;
		}

		public void PrintTree()
		{
			PrintTree("", true);
		}

		public void PrintTree(String indent, bool last)
		{
			char LUChar = (IsLocked) ? 'L' : 'U';

			Console.WriteLine(indent + "+- ["+ LUChar+ "-"+LockedDescendantsCount+"] " + Value);
			indent += last ? "   " : "|  ";

			if (null != Left) {
				if (null != Right)
				{
					Left.PrintTree(indent, false);
					Right.PrintTree(indent, true);
				}
				else
					Left.PrintTree(indent, true);
			}
		}
	}
}
