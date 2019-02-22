using DailyCodingChallenge.Problems.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingChallenge.Utility
{
	internal class LRUCache<KeyType,ValueType>
	{
		private readonly Dictionary<KeyType, ValueType> _cacheDictionary;
		private readonly List<KeyType> _cacheList;

		private List<KeyType> CacheList { get => _cacheList; }
		private Dictionary<KeyType,ValueType> CacheDictionary { get => _cacheDictionary; }
		public int FreeSpace { get; private set; }

		public LRUCache(int dimension)
		{
			if (dimension <= 0)
				throw new ArgumentOutOfRangeException("dimension", "The dimension must be strictly positive.");
			FreeSpace = dimension;
			_cacheDictionary = new Dictionary<KeyType, ValueType>();
			_cacheList = new List<KeyType>();
		}

		public void Set(KeyType key, ValueType value)
		{
			if (FreeSpace == 0)
			{
				FreeSpace++;
				CacheDictionary.Remove(CacheList[0]);
				CacheList.RemoveAt(0);
			}
			CacheDictionary[key] = value;
			CacheList.Add(key);
			FreeSpace--;
		}

		public ValueType Get(KeyType key)
		{
			return (CacheDictionary.TryGetValue(key, out ValueType value)) ? value : default(ValueType);
		}

	}
}
