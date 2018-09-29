using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingTest
{
    class Tree
    {
        public static int FindOne(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            int mid = right - left / 2;

            if (nums[left] == 1)
                return left;
            if (nums[right] == 0)
                return -1;

            while (true)
            {
                if (nums[mid] == 0)
                {
                    if (nums[mid + 1] == 1)
                        return mid + 1;
                    else
                        left = mid;
                }
                else
                {

                    if (nums[mid - 1] == 0)
                        return mid;
                    else
                        right = mid;
                }
            }
        }

        public static void TestFindOne()
        {
            int[] nums = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
            Console.WriteLine("First one index is: " + FindOne(nums));
        }

        public static Node BuildTree(int[] nums, int pos)
        {
            if (pos >= nums.Length || nums[pos] == -1)
                return null;

            Node node = new Node(nums[pos]);
            node.nodeLeft = BuildTree(nums, pos * 2 + 1);
            node.nodeRight = BuildTree(nums, pos * 2 + 2);
            return node;

        }

        public static int FindAncestor(Node currentNode, int value_0, int value_1)
        {
            // No Finding 
            if (currentNode == null)
                return -1;

            if (currentNode.value == value_0 || currentNode.value == value_1)
                return currentNode.value;

            int leftValue = FindAncestor(currentNode.nodeLeft, value_0, value_1);
            int rightValue = FindAncestor(currentNode.nodeRight, value_0, value_1);

            if (leftValue != -1 && rightValue != -1)
                return currentNode.value;
            else
                return rightValue + leftValue + 1; // An equation instead of Find 1, return leftValue or rightValue, Find 0 return -1. 

        }

        public static void TestFindAncestor()
        {
            Node root = Tree.BuildTree(new int[] { 1, 2, 3, -1, 4, 5, 6 }, 0);
            Console.WriteLine("The common ancestor is: " + FindAncestor(root, 2, 4));
        }

        public static void PreorderTranverse_Recursive(Node root)
        {
            if (root != null)
            {
                Console.WriteLine(root.value);
                PreorderTranverse_Recursive(root.nodeLeft);
                PreorderTranverse_Recursive(root.nodeRight);
            }
        }

        public static void TestDFSTraverse()
        {
            Node root = Tree.BuildTree(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, -1, -1, 10, 11, 12, 13 }, 0);
            PreorderTranverse_Recursive(root);
        }

        public static void PreorderTraverse(Node root)
        {

        }
    }

    class Node
    {
        public int value;
        public Node nodeLeft;
        public Node nodeRight;
        public Node(int value)
        {
            this.value = value;
        }
    }
}
