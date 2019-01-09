
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


	}
}
