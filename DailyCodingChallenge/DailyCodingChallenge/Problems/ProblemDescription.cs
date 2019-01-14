﻿
namespace DailyCodingChallenge.Problems
{
	// This calss contains all the problem's descriptions
	class ProblemDescription
	{
		public static string PROBLEM001_DESCRIPTION = "Given a list of numbers and a number k, return whether any two numbers from the list add up to k.\nFor example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 = 17.\nBonus: Can you do this in one pass?";
		public static string PROBLEM002_DESCRIPTION = "Given an array of integers, return a new array such that\neach element at index i of the new array is the product of all the numbers in the original array\nexcept the one at index i.\nFor example, given the array [1, 2, 3, 4, 5] the output will be [120, 60, 40, 30, 24].\nBonus: what if you can't use division?";
		public static string PROBLEM003_DESCRIPTION = "Given the root to a binary tree, implement serialize(root),\nwhich serializes the tree into a string, and deserialize(s), which deserializes the string back\ninto the tree.\nThe following test should pass: node = Node('root', Node('left', Node('left.left')), Node('right'))\nassert deserialize(serialize(node)).left.left.val == 'left.left'";
		public static string PROBLEM004_DESCRIPTION = "Given an array of integers, find the first missing positive integer in linear time and constant space.\nIn other words, find the lowest positive integer that does not exist in the array.\nThe array can contain duplicates and negative numbers as well.\nFor example, the input[3, 4, -1, 1] should give 2. The input[1, 2, 0] should give 3.\nYou can modify the input array in-place.";
		public static string PROBLEM005_DESCRIPTION = "cons(a, b) constructs a pair, and car(pair) and cdr(pair) returns the first and last element of that pair.\nFor example, car(cons(3, 4)) returns 3, and cdr(cons(3, 4)) returns 4.\nImplement car and cdr.";
		public static string PROBLEM006_DESCRIPTION = "An XOR linked list is a more memory efficient doubly linked list.\nInstead of each node holding next and prev fields, it holds a field named both,\nwhich is an XOR of the next node and the previous node. Implement an XOR linked list;\nit has an add(element) which adds the element to the end, and a get(index) which returns the node at index.\nIf using a language that has no pointers(such as Python), you can assume you have access\nto get_pointer and dereference_pointer functions that converts between nodes and memory addresses.";
		public static string PROBLEM007_DESCRIPTION = "Given the mapping a = 1, b = 2, ... z = 26, and an encoded message,\ncount the number of ways it can be decoded.\nFor example, the message '111' would give 3, since it could be decoded as 'aaa', 'ka', and 'ak'.\nYou can assume that the messages are decodable.For example, '001' is not allowed.";
		public static string PROBLEM008_DESCRIPTION = "A unival tree (which stands for 'universal value') is a tree where all nodes under it have the same value.\nGiven the root to a binary tree, count the number of unival subtrees.";
		public static string PROBLEM009_DESCRIPTION = "Given a list of integers, write a function that returns the largest sum of non-adjacent numbers.\nNumbers can be 0 or negative.\nFor example, [2, 4, 6, 2, 5] should return 13, since we pick 2, 6, and 5.\n[5, 1, 1, 5] should return 10, since we pick 5 and 5.\nFollow-up: Can you do this in O(N) time and constant space?";
		public static string PROBLEM010_DESCRIPTION = "Implement a job scheduler which takes in a function f and an integer n, and calls f after n milliseconds.";
		public static string PROBLEM011_DESCRIPTION = "Implement an autocomplete system. That is, given a query string s and a set of all possible query strings,\nreturn all strings in the set that have s as a prefix.\nFor example, given the query string de and the set of strings[dog, deer, deal], return [deer, deal].\nHint: Try preprocessing the dictionary into a more efficient data structure to speed up queries.";
		public static string PROBLEM012_DESCRIPTION = "There exists a staircase with N steps, and you can climb up either 1 or 2 steps at a time.\nGiven N, write a function that returns the number of unique ways you can climb the staircase.\nThe order of the steps matters.\nWhat if, instead of being able to climb 1 or 2 steps at a time, you could climb any number\nfrom a set of positive integers X?\nFor example, if X = {1, 3, 5}, you could climb 1, 3, or 5 steps at a time.";
		public static string PROBLEM013_DESCRIPTION = "Given an integer k and a string s, find the length of the longest substring that contains at most k distinct characters.\nFor example, given s = 'abcba' and k = 2, the longest substring with k distinct characters is 'bcb'.";
		public static string PROBLEM014_DESCRIPTION = "The area of a circle is defined as pi*r^2. Estimate pi to 3 decimal places (3.141) using a Monte Carlo method.\nHint: The basic equation of a circle is x^2 + y^2 = r^2.";
		public static string PROBLEM015_DESCRIPTION = "Given a stream of elements too large to store in memory, pick a random element from the stream with uniform probability.";
		public static string PROBLEM016_DESCRIPTION = "You run an e-commerce website and want to record the last N order ids in a log.\nImplement a data structure to accomplish this, with the following API:\n- Record(order_id) : adds the order_id to the log\n- GetLast(i) : gets the ith last element from the log.(i <= N guaranteed).\n\nYou should be as efficient with time and space as possible.";
		
	}
}
