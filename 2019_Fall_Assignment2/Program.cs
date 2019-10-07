using System;
using System.Collections.Generic;

namespace _2019_Fall_Assignment2
{
    class Program
    {
        public static void Main(string[] args)
        {
            int target = 5;
            int[] nums = { 1, 3, 5, 6 };
            Console.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));

            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] intersect = Intersect(nums1, nums2);
            Console.WriteLine("Intersection of two arrays is: ");
            DisplayArray(intersect);
            Console.WriteLine("\n");

            int[] A = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
            Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "cba";
            Console.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));

            int[,] image = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };
            int[,] flipAndInvertedImage = FlipAndInvertImage(image);
            Console.WriteLine("The resulting flipped and inverted image is:\n");
            Display2DArray(flipAndInvertedImage);
            Console.Write("\n");

            int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 } };
            int minMeetingRooms = MinMeetingRooms(intervals);
            Console.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);

            int[] arr = { -4, -1, 0, 3, 10 };
            int[] sortedSquares = SortedSquares(arr);
            Console.WriteLine("Squares of the array in sorted order is:");
            DisplayArray(sortedSquares);
            Console.Write("\n");

            string s = "abca";
            if(ValidPalindrome(s)) {
                Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
            }
            else
            {
                Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
            }
        }

        public static void DisplayArray(int[] a)
        {
            foreach(int n in a)
            {
                Console.Write(n + " ");
            }
        }

        public static void Display2DArray(int[,] a)
        {
            for(int i=0;i<a.GetLength(0);i++)
            {
                for(int j=0;j<a.GetLength(1);j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.Write("\n");
            }
        }

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int i = 0, j = nums.Length - 1, med;
                while (i < j)
                {
                    med = i + (j - i) / 2; // to find the median or mid index (quick sort)
                    if (target == nums[med]) return med; // if the middle index is the target return
                    if (target < nums[med]) j = med - 1; // repeat the process for first half
                    else i = med + 1;
                }
                if (target <= nums[i]) return i; // if the target index is found return the index
                return i + 1; // 
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            }

            return 0;
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            try
            {
                // Write your code here

                Dictionary<int, int> dict = new Dictionary<int, int>();
                int i, j, value;
                int k = 0;
                int[] output = new int[nums1.Length + nums2.Length];

                for (i = 0; i < nums1.Length; i++)
                {
                    if (dict.ContainsKey(nums1[i])) // checking if dictionary contains the number
                    {

                    }
                    else
                    {
                        dict.Add(nums1[i], 1); // if not add it to the dictionary and assign a value to the key as 1

                    }

                }

                for (j = 0; j < nums2.Length; j++)
                {
                    if (dict.ContainsKey(nums2[j])) // checking the second array elements with the dicitionary
                    {
                        dict[nums2[j]] = 2; // if it is true then change the number to 2 else it will be 1
                    }

                }

                foreach (var dc in dict)
                {
                    dict.TryGetValue(dc.Key, out value); // getting the values in the dictionaries where they have the same elements in both arrays

                    if (value == 2) // checking the values
                    {
                        output[k] = dc.Key; // outputting the key
                        k++;
                        Console.WriteLine(dc.Key);


                    }

                }
                //int[] output2 = new int[output.Length];
                //foreach (int p in output)
                //{
                //  if (output[p] == 0)
                // {
                //    Console.WriteLine(p);
                //}
                //}

                return output;

                for (j = 0; j < nums2.Length; j++)
                {
                    if (dict.ContainsKey(nums2[j]))
                    {
                        dict[nums2[j]] = 2;
                    }

                }

                foreach (var dc in dict)
                {
                    dict.TryGetValue(dc.Key, out value);

                    if (value == 2)
                    {
                        output[k] = dc.Key;
                        k++;


                    }

                }


                return output;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing Intersect()");
            }

            return new int[] { };
        }

        public static int LargestUniqueNumber(int[] A)
        {
            try
            {
                // Write your code here
                int i, max = -1, value;
                Dictionary<int, int> dict = new Dictionary<int, int>();
                for (i = 0; i < A.Length; i++)
                {
                    if (dict.ContainsKey(A[i])) dict[A[i]] = 1;
                    else dict.Add(A[i], -1);
                }
                for (i = 0; i < A.Length; i++)
                {
                    dict.TryGetValue(A[i], out value);
                    if (value == -1)
                    {
                        if (A[i] > max)
                            max = A[i];
                    }
                }
                return max;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
            }

            return 0;
        }

        public static int CalculateTime(string keyboard, string word)
        {
            try
            {
                int i, val1, val2, time = 0;
                Dictionary<char, int> dict = new Dictionary<char, int>();
                for (i = 0; i < keyboard.Length; i++)
                {
                    dict.Add(keyboard[i], i);
                }
                dict.TryGetValue(word[0], out val1);
                time = time + val1;
                for (i = 1; i < word.Length; i++)
                {
                    dict.TryGetValue(word[i], out val2);
                    time = time + ((val2 - val1) > 0 ? (val2 - val1) : (-1) * (val2 - val1));
                    val1 = val2;
                }
                return time;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing CalculateTime()");
            }

            return 0;
        }

        public static int[,] FlipAndInvertImage(int[,] A)
        {
            try
            {
                int i, j, m = 0, n = 0;
                int[,] B = new int[A.GetLength(0), A.GetLength(1)];
                for (i = 0, m = 0; i < A.GetLength(0); i++, m++)
                {
                    for (j = A.GetLength(1) - 1, n = 0; j >= 0; j--, n++)
                    {
                        B[m, n] = (A[i, j] == 0 ? 1 : 0);
                    }
                }
                return B;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
            }

            return new int[,] { };
        }

        public static int MinMeetingRooms(int[,] intervals)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MinMeetingRooms()");
            }

            return 0;
        }

        public static int[] SortedSquares(int[] A)
        {
            try
            {
                int i = 0, j = A.Length - 1, k = A.Length - 1;
                int[] B = new int[A.Length];
                while (i < j)
                {
                    if (A[i] < 0) A[i] = A[i] * (-1);
                    if (A[j] < 0) A[j] = A[j] * (-1);
                    if (A[i] >= A[j])
                    {
                        B[k] = A[i] * A[i];
                        i++;
                    }
                    else
                    {
                        B[k] = A[j] * A[j];
                        j--;
                    }
                    k--;
                }
                if (i == j)
                    B[k] = A[i];
                return B;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SortedSquares()");
            }

            return new int[] { };
        }

        public static bool ValidPalindrome(string s)
        {
            try
            {
                int[] alpha = new int[26];
                int i, count = 0;
                for (i = 0; i < s.Length; i++)
                {
                    alpha[s[i] - 'a']++;
                }
                for (i = 0; i < alpha.Length; i++)
                {
                    if (alpha[i] % 2 != 0)
                        count++;
                }
                if (count >= 2)
                    return false;
                else return true;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing ValidPalindrome()");
            }

            return false;
        }
    }
}

