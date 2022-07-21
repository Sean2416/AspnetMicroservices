using StackExchange.Redis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace LeetCode
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            string a = "";
           // var ab = RedisHaFactory.RedisDB.StringSet("test12", "Write string value from another master");
            var stringGet = RedisHaFactory.RedisDB.StringGet("test12", CommandFlags.DemandReplica);
            Console.WriteLine(stringGet.ToString());

            RedisFactory1.RedisDB.StringSet("6381", "Write string value to 6381.");            
            stringGet = RedisFactory1.RedisDB.StringGet("6381");
            Console.WriteLine(stringGet.ToString());

            do
            {
                a = Console.ReadLine();

                var answer = MySqrt(2147483647);

                Console.WriteLine(answer);

            } while (a != "-1");
        }

        //69. Sqrt(x)
        public static int MySqrt(int x)
        {
            int result = 0;

            if (x == 0)
                return 0;

            if (x <= 3)
                return 1;

            for (int i = 1; i <= (x / 2); i++)
            {
                if (x/i== i)
                    return i;

                if (x / i > i)
                    result = i;
                else
                    break;

            }

            return result;
        }

        //67. Add Binary
        public static string AddBinary(string a, string b)
        {
            string result = "";
            int indexA = a.Length-1, indexB = b.Length-1;
            int over = 0;

            do {

                int tmp = int.Parse(a[indexA--].ToString()) + int.Parse(b[indexB--].ToString()) + over;

                if (tmp < 2)
                {
                    result += tmp;
                    over = 0;
                }
                else if (tmp == 2)
                {
                    result += '0';
                    over = 1;
                }
                else
                {
                    result += '1';
                    over = 1;
                }

            } while (indexA >= 0 && indexB >= 0);

            if (indexA >= 0)
            {

                for (var i = indexA; i >= 0; i--)
                {
                    int tmp = int.Parse(a[i].ToString()) + over;

                    if (tmp < 2)
                    {
                        result += tmp;
                        over = 0;
                    }
                    else if (tmp == 2)
                    {
                        result += '0';
                        over = 1;
                    }
                }
            }
            else if (indexB >= 0)
            {
                for (var i = indexB; i >= 0; i--)
                {
                    int tmp = int.Parse(b[i].ToString()) + over;

                    if (tmp < 2)
                    {
                        result += tmp;
                        over = 0;
                    }
                    else if (tmp == 2)
                    {
                        result += '0';
                        over = 1;
                    }
                }
            }
            
            if (over == 1)
                result += "1";

            string val = "";

            for(var i=result.Length-1; i>=0;i--)
                val += result[i].ToString();

            return val;
        }

        //9. Palindrome Number
        public static bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;
            var tmp = x.ToString();
            var result = new char[tmp.Length];
            int index = 0;
            for (var i = result.Length - 1; i >= 0; i--)
                result[index++] = tmp[i];

            return int.Parse(result) == x;
        }

        //13. Roman to Integer
        public static int RomanToInt(string s)
        {
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var a = getRomanNumberMap(s[i]);
                var b = (i == s.Length - 1) ? 0 : getRomanNumberMap(s[i + 1]);

                if (a >= b)
                {
                    result += a;
                }
                else
                {
                    result += b - a;
                    i++;
                }

            }

            return result;
        }

        //14. Longest Common Prefix
        public static string LongestCommonPrefix(string[] strs)
        {
            //取最小字串作為目標比對
            var target = strs[0];
            foreach (var s in strs)
            {
                if (s.Length < target.Length)
                    target = s;
            }

            for (int i = target.Length; i >= 1; i--)
            {
                var tmp = target.Substring(0, i);
                int count = 0;

                foreach (var s in strs)
                {
                    if (s.Substring(0, i) != tmp)
                        break;
                    count++;
                }

                if (count == strs.Length)
                    return tmp;
            }

            return "";
        }

        //20. Valid Parentheses
        public static bool IsValidParentheses(string s)
        {
            Dictionary<char, char> symbol = new Dictionary<char, char>();
            symbol.Add(')', '(');
            symbol.Add('}', '{');
            symbol.Add(']', '[');

            Stack<char> stack = new Stack<char>();

            foreach (var c in s)
            {

                if (symbol.ContainsKey(c))
                {
                    if (stack.Count > 0 && stack.Peek() == symbol[c])
                        stack.Pop();
                    else
                        return false;
                }
                else if (symbol.ContainsValue(c))
                    stack.Push(c);
                else
                    return false;

            }

            return stack.Count == 0;
        }

        //26. Remove Duplicates from Sorted Array
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            int count = 1;

            for (int i = 1; i < nums.Length; i++) //從index[1]開始比較數字
            {
                if (nums[count - 1] != nums[i])   //假設數字不同
                {
                    nums[count] = nums[i];  //則換上新的數字
                    count++;    //在將要儲存的位置往下移
                }
            }
            return count;
        }

        //Remove Element
        public static int RemoveElement(int[] nums, int val)
        {
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }
            return i;
        }

        // Implement strStr()
        public static int StrStr(string haystack, string needle)
        {

            for (var i = 0; i < haystack.Length - needle.Length; i++)
            {
                if (haystack.Substring(i, needle.Length) == needle)
                    return i;
            }

            return haystack.IndexOf(needle);
        }

        //35. Search Insert Position
        public static int SearchInsert(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= target)
                    return i;
            }
            return nums.Length;
        }

        //58. Length of Last Word
        public static int LengthOfLastWord(string s)
        {
            var a = s.Trim().Split(' ');
            return a[a.Length - 1].Length;
        }

        //66. Plus One
        public static int[] PlusOne(int[] digits)
        {
            string s = "";

            foreach (var digit in digits)
                s += digit.ToString();

            var answer = decimal.Parse(s) + 1;

            int[] result = new int[answer.ToString().Length];

            int i = 0;

            foreach (var c in answer.ToString())
                result[i++] = int.Parse(c.ToString());

            return result;
        }

        private static int getRomanNumberMap(char c)
        {
            switch (c)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    return 0;
            }
        }
    }
}
