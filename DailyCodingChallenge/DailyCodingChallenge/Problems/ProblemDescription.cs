﻿
namespace DailyCodingChallenge.Problems
{
	// This class contains all the problem's descriptions
	static class ProblemDescription
	{
		public const string PROBLEM001_DESCRIPTION = "Given a list of numbers and a number k, return whether any two numbers from the list add up to k.\nFor example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 = 17.\nBonus: Can you do this in one pass?";
		public const string PROBLEM002_DESCRIPTION = "Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at index i.\nFor example, given the array [1, 2, 3, 4, 5] the output will be [120, 60, 40, 30, 24].\nBonus: what if you can't use division?";
		public const string PROBLEM003_DESCRIPTION = "Given the root to a binary tree, implement serialize(root), which serializes the tree into a string, and deserialize(s), which deserializes the string back into the tree.\nThe following test should pass: node = Node('root', Node('left', Node('left.left')), Node('right')) assert deserialize(serialize(node)).left.left.val == 'left.left'";
		public const string PROBLEM004_DESCRIPTION = "Given an array of integers, find the first missing positive integer in linear time and constant space.\nIn other words, find the lowest positive integer that does not exist in the array.\nThe array can contain duplicates and negative numbers as well.\nFor example, the input[3, 4, -1, 1] should give 2. The input[1, 2, 0] should give 3.\nYou can modify the input array in-place.";
		public const string PROBLEM005_DESCRIPTION = "cons(a, b) constructs a pair, and car(pair) and cdr(pair) returns the first and last element of that pair.\nFor example, car(cons(3, 4)) returns 3, and cdr(cons(3, 4)) returns 4.\nImplement car and cdr.";
		public const string PROBLEM006_DESCRIPTION = "An XOR linked list is a more memory efficient doubly linked list.\nInstead of each node holding next and prev fields, it holds a field named both, which is an XOR of the next node and the previous node. Implement an XOR linked list; it has an add(element) which adds the element to the end, and a get(index) which returns the node at index.\nIf using a language that has no pointers(such as Python), you can assume you have access to get_pointer and dereference_pointer functions that converts between nodes and memory addresses.";
		public const string PROBLEM007_DESCRIPTION = "Given the mapping a = 1, b = 2, ... z = 26, and an encoded message, count the number of ways it can be decoded.\nFor example, the message '111' would give 3, since it could be decoded as 'aaa', 'ka', and 'ak'.\nYou can assume that the messages are decodable. For example, '001' is not allowed.";
		public const string PROBLEM008_DESCRIPTION = "A unival tree (which stands for 'universal value') is a tree where all nodes under it have the same value.\nGiven the root to a binary tree, count the number of unival subtrees.";
		public const string PROBLEM009_DESCRIPTION = "Given a list of integers, write a function that returns the largest sum of non-adjacent numbers.\nNumbers can be 0 or negative.\nFor example, [2, 4, 6, 2, 5] should return 13, since we pick 2, 6, and 5.\n[5, 1, 1, 5] should return 10, since we pick 5 and 5.\nFollow-up: Can you do this in O(N) time and constant space?";
		public const string PROBLEM010_DESCRIPTION = "Implement a job scheduler which takes in a function f and an integer n, and calls f after n milliseconds.";
		public const string PROBLEM011_DESCRIPTION = "Implement an autocomplete system. That is, given a query string s and a set of all possible query strings, return all strings in the set that have s as a prefix.\nFor example, given the query string de and the set of strings[dog, deer, deal], return [deer, deal].\nHint: Try preprocessing the dictionary into a more efficient data structure to speed up queries.";
		public const string PROBLEM012_DESCRIPTION = "There exists a staircase with N steps, and you can climb up either 1 or 2 steps at a time.\nGiven N, write a function that returns the number of unique ways you can climb the staircase.\nThe order of the steps matters.\nWhat if, instead of being able to climb 1 or 2 steps at a time, you could climb any number from a set of positive integers X?\nFor example, if X = {1, 3, 5}, you could climb 1, 3, or 5 steps at a time.";
		public const string PROBLEM013_DESCRIPTION = "Given an integer k and a string s, find the length of the longest substring that contains at most k distinct characters.\nFor example, given s = 'abcba' and k = 2, the longest substring with k distinct characters is 'bcb'.";
		public const string PROBLEM014_DESCRIPTION = "The area of a circle is defined as pi*r^2. Estimate pi to 3 decimal places (3.141) using a Monte Carlo method.\nHint: The basic equation of a circle is x^2 + y^2 = r^2.";
		public const string PROBLEM015_DESCRIPTION = "Given a stream of elements too large to store in memory, pick a random element from the stream with uniform probability.";
		public const string PROBLEM016_DESCRIPTION = "You run an e-commerce website and want to record the last N order ids in a log.\nImplement a data structure to accomplish this, with the following API:\n- Record(order_id) : adds the order_id to the log\n- GetLast(i) : gets the ith last element from the log.(i <= N guaranteed).\n\nYou should be as efficient with time and space as possible.";
		public const string PROBLEM017_DESCRIPTION = "We are interested in finding the longest (number of characters) absolute path to a file within our file system.\nThe string 'dir\\n\\tsubdir1\\n\\t\\tfile1.ext\\n\\t\\tsubsubdir1\\n\\tsubdir2\\n\\t\\tsubsubdir2\\n\\t\\t\\tfile2.ext' represents:\ndir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext\nFor example, in the example above, the longest absolute path is 'dir/subdir2/subsubdir2/file2.ext' and its length is 32 (not including the double quotes).\nGiven a string representing the file system in the above format, return the length of the longest absolute path to a file in the abstracted file system.\nIf there is no file in the system, return 0.\nNote:\n- The name of a file contains at least a period and an extension.\n- The name of a directory or sub-directory will not contain a period.";
		public const string PROBLEM018_DESCRIPTION = "Given an array of integers and a number k, where 1 <= k <= length of the array, compute the maximum values of each subarray of length k.\nFor example, given array = [10, 5, 2, 7, 8, 7] and k = 3, we should get: [10, 7, 8, 8].\nDo this in O(n) time and O(k) space. You can modify the input array in-place and you do not need to store the results. You can simply print them out as you compute them.";
		public const string PROBLEM019_DESCRIPTION = "A builder is looking to build a row of N houses that can be of K different colors.\nHe has a goal of minimizing cost while ensuring that no two neighboring houses are of the same color.\nGiven an N by K matrix where the n_th row and k_th column represents the cost to build the n_th house with k_th color, return the minimum cost which achieves this goal.";
		public const string PROBLEM020_DESCRIPTION = "Given two singly linked lists that intersect at some point, find the intersecting node. The lists are non-cyclical.\nFor example, given A = 3 -> 7 -> 8 -> 10 and B = 99-> 1 -> 8 -> 10, return the node with value 8.\nIn this example, assume nodes with the same value are the exact same node objects.\nDo this in O(M + N) time (where M and N are the lengths of the lists) and constant space.";
		public const string PROBLEM021_DESCRIPTION = "Given an array of time intervals (start, end) for classroom lectures (possibly overlapping), find the minimum number of rooms required.\nFor example, given[(30, 75), (0, 50), (60, 150)], you should return 2.";
		public const string PROBLEM022_DESCRIPTION = "Given a dictionary of words and a string made up of those words (no spaces), return the original sentence in a list.\nIf there is more than one possible reconstruction, return any of them. If there is no possible reconstruction, then return null.\nFor example, given the set of words 'quick', 'brown', 'the', 'fox', and the string 'thequickbrownfox', you should return ['the', 'quick', 'brown', 'fox'].\nGiven the set of words 'bed', 'bath', 'bedbath', 'and', 'beyond', and the string 'bedbathandbeyond', return either['bed', 'bath', 'and', 'beyond] or ['bedbath', 'and', 'beyond'].";
		public const string PROBLEM023_DESCRIPTION = "Given this matrix, a start coordinate, and an end coordinate, return the minimum number of steps required to reach the end coordinate from the start. If there is no possible path, then return null.\nYou can move up, left, down, and right. You cannot move through walls. You cannot wrap around the edges of the board.";
		public const string PROBLEM024_DESCRIPTION = "Implement locking in a binary tree. A binary tree node can be locked or unlocked only if all of its descendants or ancestors are not locked.\nDesign a binary tree node class with the following methods:\n - is_locked, which returns whether the node is locked.\n - lock, which attempts to lock the node.If it cannot be locked, then it should return false.\n   Otherwise, it should lock it and return true.\n - unlock, which unlocks the node. If it cannot be unlocked, then it should return false.\n   Otherwise, it should unlock it and return true.\n\nYou may augment the node to add parent pointers or any other property you would like.\nYou may assume the class is used in a single-threaded program, so there is no need for actual locks or mutexes. Each method should run in O(h), where h is the height of the tree.";
		public const string PROBLEM025_DESCRIPTION = "Implement regular expression matching with the following special characters:\n1) '.' (period) which matches any single character.\n2) '*' (asterisk) which matches zero or more of the preceding element.\n\nThat is, implement a function that takes in a string and a valid regular expression and returns whether or not the string matches the regular expression.\nFor example, given the regular expression 'ra.' and the string 'ray', your function should return true.\nThe same regular expression on the string 'raymond' should return false.\nGiven the regular expression '.*at' and the string 'chat', your function should return true.\nThe same regular expression on the string 'chats' should return false.";
		public const string PROBLEM026_DESCRIPTION = "Given a singly linked list and an integer k, remove the kth last element from the list.\nk is guaranteed to be smaller than the length of the list.\nThe list is very long, so making more than one pass is prohibitively expensive.\nDo this in constant space and in one pass.";
		public const string PROBLEM027_DESCRIPTION = "Given a string of round, curly, and square open and closing brackets, return whether the brackets are balanced (well-formed).\nFor example, given the string '([])[]({})', you should return true.\nGiven the string '([)]' or '((()', you should return false.";
		public const string PROBLEM028_DESCRIPTION = "Write an algorithm to justify text. Given a sequence of words and an integer line length k, return a list of strings which represents each line, fully justified.\nMore specifically, you should have as many words as possible in each line.\nThere should be at least one space between each word. Pad extra spaces when necessary so that each line has exactly length k.\nSpaces should be distributed as equally as possible, with the extra spaces, if any, distributed starting from the left.\nIf you can only fit one word on a line, then you should pad the right-hand side with spaces.\nEach word is guaranteed not to be longer than k.\nFor example, given the list of words:\n['the', 'quick', 'brown', 'fox', 'jumps', 'over', 'the', 'lazy', 'dog'] and k = 16, you should return the following:\n['the  quick brown', # 1 extra space on the left\n 'fox  jumps  over', # 2 extra spaces distributed evenly\n 'the   lazy   dog'] # 4 extra spaces distributed evenly";
		public const string PROBLEM029_DESCRIPTION = "Run-length encoding is a fast and simple method of encoding strings. The basic idea is to represent repeated successive characters as a single count and character.\nFor example, the string 'AAAABBBCCDAA' would be encoded as '4A3B2C1D2A'.\nImplement run-length encoding and decoding.\nYou can assume the string to be encoded have no digits and consists solely of alphabetic characters. You can assume the string to be decoded is valid.";
		public const string PROBLEM030_DESCRIPTION = "You are given an array of non-negative integers that represents a two-dimensional elevation map where each element is unit-width wall and the integer is the height. Suppose it will rain and all spots between two walls get filled up.\nCompute how many units of water remain trapped on the map in O(N) time and O(1) space.\nFor example, given the input[2, 1, 2], we can hold 1 unit of water in the middle.\nGiven the input [3, 0, 1, 3, 0, 5], we can hold 3 units in the first index, 2 in the second, and 3 in the fourth index (we cannot hold 5 since it would run off to the left), so we can trap 8 units of water.";
		public const string PROBLEM031_DESCRIPTION = "The edit distance between two strings refers to the minimum number of character insertions, deletions, and substitutions required to change one string to the other.\nFor example, the edit distance between “kitten” and “sitting” is three: substitute the “k” for “s”, substitute the “e” for “i”, and append a “g”.\nGiven two strings, compute the edit distance between them.";
		public const string PROBLEM032_DESCRIPTION = "Suppose you are given a table of currency exchange rates, represented as a 2D array. Determine whether there is a possible arbitrage: that is, whether there is some sequence of trades you can make, starting with some amount A of any currency, so that you can end up with some amount greater than A of that currency.\nThere are no transaction costs and you can trade fractional quantities.";
		public const string PROBLEM033_DESCRIPTION = "Compute the running median of a sequence of numbers. That is, given a stream of numbers, print out the median of the list so far on each new element.\nRecall that the median of an even-numbered list is the average of the two middle numbers.\nFor example, given the sequence[2, 1, 5, 7, 2, 0, 5], your algorithm should print out: [ 2, 1.5, 2, 3.5, 2, 2, 2 ].";
		public const string PROBLEM034_DESCRIPTION = "Given a string, find the palindrome that can be made by inserting the fewest number of characters as possible anywhere in the word. If there is more than one palindrome of minimum length that can be made, return the lexicographically earliest one (the first one alphabetically).\nFor example, given the string 'race', you should return 'ecarace', since we can add three letters to it(which is the smallest amount to make a palindrome). There are seven other palindromes that can be made from 'race' by adding three letters, but 'ecarace' comes first alphabetically.\nAs another example, given the string 'google', you should return 'elgoogle'.";
		public const string PROBLEM035_DESCRIPTION = "Given an array of strictly the characters 'R', 'G', and 'B', segregate the values of the array so that all the Rs come first, the Gs come second, and the Bs come last. You can only swap elements of the array.\nDo this in linear time and in-place.\nFor example, given the array['G', 'B', 'R', 'R', 'B', 'R', 'G'], it should become['R', 'R', 'R', 'G', 'G', 'B', 'B'].";
	}
}
