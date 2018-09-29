using System;
using System.Collections.Generic;

namespace ProgrammingTest
{
    class LinerQuestion
    {
        // Two Sum Quesion
        public static bool FindTarget(int[] nums, int target)
        {
            HashSet<int> appeared = new HashSet<int>();

            foreach (int n in nums)
            {
                if (appeared.Contains(target - n))
                    return true;
                appeared.Add(n);

            }
            return false;

        }

        // Merge Two Arrays Quesion
        public static void MergeArrays(int[] nums_0, int length_0, int[] nums_1, int length_1)
        {
            int last = nums_0.Length - 1;
            int pos_0 = length_0 - 1;
            int pos_1 = length_1 - 1;
            while (last != -1)
            {
               if (pos_0 == -1 || pos_1 != -1 && nums_0[pos_0] < nums_1[pos_1])
                    nums_0[last--] = nums_1[pos_1--];
               else
                    nums_0[last--] = nums_0[pos_0--];
            }
        }

        // Check equation
        public static bool CheckEquation(string equation)
        {
            // O(n) complexity
            Stack<char> m_equation = new Stack<char>();
            foreach (char c in equation)
            {
                switch (c)
                {
                    case '(':
                        m_equation.Push(c);
                        break;
                    case '[':
                        m_equation.Push(c);
                        break;
                    case '{':
                        m_equation.Push(c);
                        break;
                    case ')':
                        if (m_equation.Count == 0 || m_equation.Pop() != '(')
                            return false;
                        break;
                    case ']':
                        if (m_equation.Count == 0 || m_equation.Pop() != '[')
                            return false;
                        break;
                    case '}':
                        if (m_equation.Count == 0 || m_equation.Pop() != '{')
                            return false;
                        break;

                }
            }
            return m_equation.Count == 0;
        }

        private static void TestMergeArray()
        {
            int[] num_0 = new int[] { 1, 4, 7, 8, 0, 0, 0 };
            int[] num_1 = new int[] { 2, 3, 5 };
            MergeArrays(num_0, 4, num_1, 3);
            foreach (int n in num_0)
                Console.WriteLine(n);
        }

        private static void TestEquation()
        {
            string equation = "{{{}}}()";
            Console.WriteLine(CheckEquation(equation));
        }
    }
}
