namespace TrappingRainWater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int[] height = new int[] { 0, 2, 0, 3, 1, 0, 1, 3, 2, 1 };

            Console.WriteLine(sol.Trap(height));
        }
    }

    //time complexity - O(N) becuase we are using 3 for loop N + N + N = 3N we can remove constants which is 3 and it becomes O(N)
    //space-complexity - O(N) because the variable increases with the input for e.g. leftMaxs and rightMaxs length is directly proportional to the length of height
    public class Solution
    {
        public int Trap(int[] height)
        {
            //calculate the max height for each left index element and store them in leftMaxs array
            int[] leftMaxs = new int[height.Length];
            int tempLeftMax = 0;

            for (int i = 0; i < height.Length; i++)
            {
                if (height[i] > tempLeftMax)
                {
                    tempLeftMax = height[i];
                }
                leftMaxs[i] = tempLeftMax;
            }

            //calculate the max height for each right index element and store them in rightMaxs array
            int[] rightMaxs = new int[height.Length];
            int tempRightMax = 0;

            for (int i = height.Length - 1; i >= 0; i--)
            {
                if (height[i] > tempRightMax)
                {
                    tempRightMax = height[i];
                }
                rightMaxs[i] = tempRightMax;
            }

            //calculate the total water
            int totalWater = 0;

            for (int i = 0; i < height.Length - 1; i++)
            {
                totalWater += Min(leftMaxs[i], rightMaxs[i]) - height[i]; //min(leftMax[i], rightMax[i]) - heigt[i]
            }

            return totalWater;
        }

        public int Min(int maxHeight1, int maxHeight2)
        {
            return maxHeight1 > maxHeight2 ? maxHeight2 : maxHeight1; //return minimum height
        }
    }

}
