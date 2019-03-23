using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Utility
{
	class LFUCache<KeyType, ValueType> where KeyType : IComparable<KeyType>
	{
		private readonly Dictionary<KeyType, Pair<ValueType, int>> _cacheDictionary;
		private readonly Dictionary<int, DoubleLinkedList<KeyType>> _countDictionary;
		private readonly Dictionary<KeyType, DoubleLinkedNode<KeyType>> _nodeDictionary;
		private readonly List<int> _countList;

		public Dictionary<KeyType, Pair<ValueType, int>> CacheDictionary { get => _cacheDictionary; }
		public Dictionary<int, DoubleLinkedList<KeyType>> CountDictionary { get => _countDictionary; }
		public Dictionary<KeyType, DoubleLinkedNode<KeyType>> NodeDictionary { get => _nodeDictionary; }
		public List<int> CountList { get => _countList; }
		public int FreeSpace { get; private set; }

		public LFUCache(int n)
		{
			_cacheDictionary = new Dictionary<KeyType, Pair<ValueType, int>>();
			_countDictionary = new Dictionary<int, DoubleLinkedList<KeyType>>();
			_nodeDictionary = new Dictionary<KeyType, DoubleLinkedNode<KeyType>>();
			_countList = new List<int>();
			FreeSpace = n;
		}

		public void Set(KeyType key, ValueType value)
		{
			if(FreeSpace > 0)
				FreeSpace--;				
			else
			{
				// create a free space
				int count = CountDictionary.Keys.First();
				KeyType oldKey = CountDictionary[count].First.Value;
				CountDictionary[count].RemoveFirst();
				if (0 == CountDictionary[count].Count)
					CountDictionary.Remove(count);
				NodeDictionary.Remove(oldKey);
				CacheDictionary.Remove(oldKey);
			}
			// adding the new page
			CacheDictionary[key] = new Pair<ValueType, int>(value, 1);
			if (!CountDictionary.ContainsKey(1))
				CountDictionary[1] = new DoubleLinkedList<KeyType>();

			CountDictionary[1].AddLast(key);
			NodeDictionary[key] = CountDictionary[1].Last;
		}

		public ValueType Get(KeyType key)
		{
			if (CacheDictionary.ContainsKey(key))
			{
				Pair<ValueType, int> pair = CacheDictionary[key];
				int count = pair.Second;
				DoubleLinkedNode<KeyType> node = NodeDictionary[key];
				DoubleLinkedList<KeyType> list = CountDictionary[count];
				if (list.First.Equals(node))
					list.RemoveFirst();
				else if (list.Last.Equals(node))
					list.RemoveLast();
				else
					node.Previous.Next = node.Next;
				if (0 == list.Count)
					CountDictionary.Remove(count);
				int nextCount = count + 1;
				if (!CountDictionary.ContainsKey(nextCount))
					CountDictionary[nextCount] = new DoubleLinkedList<KeyType>();
				CountDictionary[nextCount].AddLast(node.Value);
				NodeDictionary.Remove(key);
				NodeDictionary[key] = CountDictionary[nextCount].Last;
				CacheDictionary.Remove(key);
				CacheDictionary[key] = new Pair<ValueType, int>(pair.First, nextCount);
			}
			return (CacheDictionary.ContainsKey(key)) ? CacheDictionary[key].First : default(ValueType);
		}

		public List<Pair<KeyType, Pair<ValueType, int>>> GetAllCache()
		{
			List<Pair<KeyType, Pair<ValueType, int>>> list = new List<Pair<KeyType, Pair<ValueType, int>>>();
			foreach (KeyType key in CacheDictionary.Keys)
				list.Add(new Pair<KeyType, Pair<ValueType, int>>(key, CacheDictionary[key]));

			return list;
		}

		public List<Pair<int, DoubleLinkedList<KeyType>>> GetAllCount()
		{
			List<Pair<int, DoubleLinkedList<KeyType>>> list = new List<Pair<int, DoubleLinkedList<KeyType>>>();
			foreach(int count in CountDictionary.Keys)
				list.Add(new Pair<int, DoubleLinkedList<KeyType>>(count, CountDictionary[count]));

			return list;
		}

		public List<Pair<KeyType, DoubleLinkedNode<KeyType>>> GetAllNode()
		{
			List<Pair<KeyType, DoubleLinkedNode<KeyType>>> list = new List<Pair<KeyType, DoubleLinkedNode<KeyType>>>();
			foreach (KeyType key in NodeDictionary.Keys)
				list.Add(new Pair<KeyType, DoubleLinkedNode<KeyType>>(key, NodeDictionary[key]));

			return list;
		}

	}
}
