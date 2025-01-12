﻿using System;
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

            int[] nums1 = { 1,2,2,1 };
            int[] nums2 = { 2,2 };
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
            if (ValidPalindrome(s))
            {
                Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
            }
            else
            {
                Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
            }
        }

        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }

        public static void Display2DArray(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
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
                    med = i + (j - i) / 2; // to find the median or mid index (binary search)
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
                Dictionary<int, int> dict = new Dictionary<int, int>();
                int i, j, value;
                int k = 0;
                int[] output = new int[nums1.Length + nums2.Length];

                for (i = 0; i < nums1.Length; i++)
                {
                    if (dict.ContainsKey(nums1[i])) // checking if dictionary contains the number
                    {
                        dict.TryGetValue(nums1[i], out value);
                        dict[nums1[i]] = ++value;
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
                        dict.TryGetValue(nums2[j], out value);
                        if (value > 0) //checking the value is greater than zero
                        {
                            output[k] = nums2[j];
                            k++;
                            dict[nums2[j]] = --value; // udpate the value once found and decrease the value 
                        }
                    }
                }
                int[] output2 = new int[k]; // creating an array to output
                int w = 0;
                for(w = 0; w<k; w++)
                {
                    output2[w] = output[w]; 
                }
                return output2; // returing the output
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
                //traverse through the array
                for (i = 0; i < A.Length; i++)
                {
                    //if the dictionary already contains the number, then update it's value as 1
                    if (dict.ContainsKey(A[i])) dict[A[i]] = 1;
                    //if dictionary don't have the number, then add the number in dictionary and value as -1
                    else dict.Add(A[i], -1);
                }
                //Now all the unique elements will have -1 as value in the dictionary
                for (i = 0; i < A.Length; i++)
                {
                    dict.TryGetValue(A[i], out value);
                    if (value == -1)
                    {
                        //if the value is -1, then check if the number is largest or not
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
                //Add all the elements and the index/time of those elements in the given keyboard to the dictionary
                for (i = 0; i < keyboard.Length; i++)
                {
                    dict.Add(keyboard[i], i);
                }
                dict.TryGetValue(word[0], out val1);
                //Add the first letter's time to the value time
                time = time + val1;
                //for all the elements in the given word . calculate the time required to type those letters in the word
                for (i = 1; i < word.Length; i++)
                {
                    //fetch the value of the letter in the word
                    dict.TryGetValue(word[i], out val2);
                    /* find the time taken to reach this letter from the previous letter and add it to the time.
                     * val1 is index of previos alphabet in the word, val2 is index of current alphabet
                    * */
                    time = time + ((val2 - val1) > 0 ? (val2 - val1) : (-1) * (val2 - val1));
                    //Update the val1 to val2(value of current alphabet)
                    val1 = val2;
                }
                //return the time taken to type the entire word
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
                        //Read each row in reverse direction and invert the element of the array A at that position and place it in Array B
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
                int i, j, meetingRooms = 1, max = 1;
                int[] start = new int[intervals.GetLength(0)];
                int[] end = new int[intervals.GetLength(0)];

                for (j = 0; j < intervals.GetLength(0); j++)
                {
                    start[j] = intervals[j, 0];
                    end[j] = intervals[j, 1];
                }
                Array.Sort(start);
                Array.Sort(end);
                //Starting from second meeting's start time as the num of meeting rooms is already updated to 1
                i = 1; j = 0;
                //Till all the meetings we will run the loop and increment the meeting rooms
                while (i < start.Length && j < start.Length)
                {
                    //if next event startes ahead of current meeting then increment the count of meeting rooms
                    if (start[i] <= end[j])
                    {
                        meetingRooms++;
                        i++;
                        //keeping track of max number of meeting rooms required
                        if (meetingRooms > max)
                        {
                            max = meetingRooms;
                        }
                    }
                    else
                    {
                        //if next meeting starts after the current meeting ends then decrement the meeting rooms required at that point of time
                        meetingRooms--;
                        j++;
                    }
                }
                //return the max number of meeting rooms
                return max;
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
                //create an array of same length
                int[] B = new int[A.Length];
                //Start i from beginning index and j from end index of array
                while (i < j)
                {
                    //Convert negative numbers to positive
                    if (A[i] < 0) A[i] = A[i] * (-1);
                    if (A[j] < 0) A[j] = A[j] * (-1);
                    //check for largest value and square it and add it in the end in new array
                    if (A[i] >= A[j])
                    {
                        B[k] = A[i] * A[i];
                        //if the largest element is in the beginning then as the sqaure of it is added in new array, increase i
                        i++;
                    }
                    else
                    {
                        B[k] = A[j] * A[j];
                        //if largest element is in the end , as it's square is added in new array, decrement the value of j
                        j--;
                    }
                    //decrease the end index of new array
                    k--;
                }
                if (i == j)
                    B[k] = A[i] * A[i];
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
            //check the alphabets from beginning and ending. If more than 2 individual characters appears int he string, then return false
            try
            {
                int i = 0, j = s.Length - 1, del = 0;
                while (i < j)
                {
                    if (s[i] == s[j])
                    {
                        i++;
                        j--;
                    }
                    else
                    {
                        del++;
                        j--;
                    }
                    if (del >= 2)
                        return false;
                }
                if (i >= j)
                    return true;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing ValidPalindrome()");
            }

            return false;
        }
    }
}

