/*
Given an array of integers numbers that is sorted in non-decreasing order.

Return the indices (1-indexed) of two numbers, [index1, index2], such that they add up to a given target number target and index1 < index2. Note that index1 and index2 cannot be equal, therefore you may not use the same element twice.

There will always be exactly one valid solution.

Your solution must use 
O
(
1
)
O(1) additional space.

Example 1:

Input: numbers = [1,2,3,4], target = 3

Output: [1,2]
Explanation:
The sum of 1 and 2 is 3. Since we are assuming a 1-indexed array, index1 = 1, index2 = 2. We return [1, 2].

Constraints:

2 <= numbers.length <= 30000
-1000 <= numbers[i] <= 1000
-1000 <= target <= 1000 
*/


namespace TwoIntegerSumII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] numbers = [1, 2, 3, 4];
            int target = 3;
            int[] numbers2 = [1, 1, 3, 4];
            int target2 = 2;

            Console.WriteLine(solution.TwoSum(numbers2, target2));
        }
    }

   
    /*
    time complexity O(N)
    space complexity O(1) because we are only using two variables to save we are not saving each and every item
    
    1) main thing to remember is we need array to be sorted else this technique will not work
    2) sorted means when we move from left we are increasing and when we move from right we are decreasing
    3) so we add left and right if it is equal to target we return index as array be aware if they want index to start at 1 add 1
    4) if left + right is less than target we need to move the left 
    5) if left + right is more than target we need to move the right 
    6) also after while loop return the index array
    7) if we have to sort then time complexity becomes O(N log N) and time complexity becomes O(N) extra space, extra space is the additional memory on top of the input 
    i.e. if we create another array as a result of sort then it needs extra space
    */
    public class Solution
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            int left = 0;
            int right = numbers.Length - 1;

            while (left < right)
            {
                if (numbers[left] + numbers[right] == target)
                {
                    return [left + 1, right + 1];  //since no longer 0 based index starts at 1 so just add one 
                }
                else if (numbers[left] + numbers[right] > target)
                {
                    right -= 1; //move index to right decreases
                }
                else
                {
                    left += 1;
                }
            }
            return [left + 1, right + 1];
        }
    }
}
