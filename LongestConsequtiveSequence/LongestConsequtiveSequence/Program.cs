/*
 Given an array of integers nums, return the length of the longest consecutive sequence of elements that can be formed.

A consecutive sequence is a sequence of elements in which each element is exactly 1 greater than the previous element. The elements do not have to be consecutive in the original array.

You must write an algorithm that runs in O(n) time.

Input: nums = [2,20,4,10,3,4,5] must Output: 4
Input: nums = [0,3,2,5,4,6,1,1] must Output: 7

Constraints
0 <= nums.length <= 100,000
-10^9 <= nums[i] <= 10^9

Notes: Solution shown below is O(n log n)

Algorithm
1) sort in ascending order
2) because the order is ascending we can find consequtive numbers 
3) we create variable currentLength and maxLength
4) now we loop through the sorted array
5) if its first index just continue
6) else if the number at current index is greater than the previous number by 1 then add 1 to currentLength
7) else if the number is a duplicate skip
8) else which means the number is not a consequtive we check 
    if the currentLength > maxLength then assign currentLength to maxLength and reset currentLength to 1
9) finally we do the same out of the loop to cover for sequence at the last

One key takeaway: when facing with out of range index issues comparing with previous number may be a good alternative i.e. array[i] or array[i - 1] instead of array[i+1]

 
 */

namespace LongestConsequtiveSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 2, 20, 4, 10, 3, 4, 5 };
            int[] nums2 = new int[] { 0, 3, 2, 5, 4, 6, 1, 1 };
            int[] nums3 = new int[] { 0, 0 };
            int[] nums4 = new int[] { 1, 3, 5, 2, 4 };

            Console.WriteLine(LongestConsecutiveON(nums4));
        }

        //O(N log N) solution
        public static int LongestConsecutiveONLogN(int[] nums)
        {
            //sort the array in ascending order
            Array.Sort(nums);
            //foreach (int num in nums) { Console.WriteLine(num); }

            //check for empty array
            if (nums.Length == 0)
            {
                return 0;
            }

            int currentLength = 1;
            int maxLength = 1;

            //loop through the sorted array
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                else if (i > 0 && nums[i] - 1 == nums[i - 1])
                {
                    currentLength += 1;
                }
                else if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }
                else
                {
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }
                    currentLength = 1;
                }
            }

            if (currentLength > maxLength)
            {
                maxLength = currentLength;
            }

            //foreach (int num in set) { Console.WriteLine(num); }
            Console.WriteLine("\n");
            return maxLength;
        }


        //O(N) solution
        /*
        1) key idea is copy everything across hashset and loop through it (this takes care of duplicates)
        2) does num - 1 exists if it does then skip loop if it does not that means its a fresh number
        3) if its a fresh number then add to currentLength then loop through the sequence use hashset count as upper bound
        4) now through the loop check if num + 1, num + 2 ....etc exists till the sequence runs out
        5) if it exists then add to current length if it does not then update the maxLength and break
        6) finally return maxLength

         */
        public static int LongestConsecutiveON(int[] nums)
        {
            //put everything in hashset - takes care of duplicates
            HashSet<int> set = new HashSet<int>();
            
            foreach (int num in nums)
            {
                set.Add(num);
            }

            int currentLength = 0;
            int maxLength = 0;

            foreach (int num in set) //loop through hashset to avoid duplicates
            {
                if (set.Contains(num - 1))
                {
                    continue;
                } else
                {
                    currentLength += 1;
                    for (int i = 1; i <= set.Count; i++) 
                    {
                        if (set.Contains(num + i)){
                            currentLength += 1;
                        } else
                        {
                            //update the maxLength if required 
                            if (currentLength > maxLength)
                            {
                                maxLength = currentLength;
                            }
                            currentLength = 0;
                            break;
                        }
                    }
                }
            }

            return maxLength;
        }

    }
}
