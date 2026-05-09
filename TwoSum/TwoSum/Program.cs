/*
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.

Example 1:

Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
 
 */


namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var program = new Program();
            program.TwoSum([2, 7, 11, 15], 9);
        }

        public int[] TwoSum(int[] nums, int target)
        {
            // int[] result = new int[2]{0, 0};
            // int currentIndex = 0;
            // foreach (int num in nums)
            // {
            //     int difference = target - num;

            //     var index = Array.IndexOf(nums, difference);

            //     if (index != -1 && index != currentIndex)
            //     {
            //         result[0] = currentIndex;
            //         result[1] = index;
            //         break;
            //     }
            //     currentIndex++;
            // }
            // return result;

            Dictionary<int, int> dict = new Dictionary<int, int>();
            int[] result = new int[2];

            int index = 0;

            foreach (int num in nums)
            {
                int compliment = target - num;
                bool containsCompliment = dict.TryGetValue(compliment, out int value);
                Console.WriteLine("run" + index);
                Console.WriteLine(containsCompliment);
                Console.WriteLine(value);
                Console.WriteLine("\n");
                if (containsCompliment)
                {
                    result[0] = value;
                    result[1] = index;
                    break;
                }

                //check for any possible duplicate keys
                //if (!dict.ContainsKey(num))
                //{
                //    dict.Add(num, index);
                //}
                dict.TryAdd(num, index);

                index++;
            }
            return result;
        }
    }


}
