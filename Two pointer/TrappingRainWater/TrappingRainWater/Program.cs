namespace TrappingRainWater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            OptimalSolution optSol = new OptimalSolution();
            int[] height = new int[] { 0, 2, 0, 3, 1, 0, 1, 3, 2, 1 };

            Console.WriteLine(optSol.Trap(height));
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

    //time complexity - O(N) because we are only using one while loop 
    //space complexity - O(1) because the variabe does not increase with the increase in input we have a set variable leftIndex, rightIndex etc.
    /*
    1. create a leftIndex and rightIndex variable
    2. create leftMax and rightMax
    3. create a totalArea
    4. While loop
    5. check current leftMaxHeight > current left Height, if yes then leftMaxHeight = current left Height
    6. check current rightMaxHeight to current right Height, if yes then rightMaxHeight = current right Height
    7. check min of the leftMax and rightMaxHeight (remember min height is the bottle neck so we can calculate the area there and move that pointer

    why two pointer pattern ? Because it improves the space complexity as we do not have to create leftMax and rightMax arrays seperately before calculating the area
     */
    public class OptimalSolution()
    {
        public int Trap(int[] height)
        {
            int leftIndex = 0;
            int rightIndex = height.Length - 1;
            int leftMaxHeight = height[leftIndex];
            int rightMaxHeight = height[rightIndex];
            int totalArea = 0;

            while (leftIndex < rightIndex)
            {
                //check current leftMaxHeight to current left Height
                if (height[leftIndex] > leftMaxHeight)
                {
                    leftMaxHeight = height[leftIndex];
                }

                //check current rightMaxHeight to current right Height
                if (height[rightIndex] > rightMaxHeight)
                {
                    rightMaxHeight = height[rightIndex];
                }

                //check minimum of the leftMaxHeight and rightMaxHeight and move the minimum
                if (leftMaxHeight > rightMaxHeight)
                {
                    totalArea += rightMaxHeight - height[rightIndex];
                    rightIndex--; 
                }

                if (rightMaxHeight > leftMaxHeight || rightMaxHeight == leftMaxHeight) //if its equal we can move either left or right 
                {
                    totalArea += leftMaxHeight - height[leftIndex];
                    leftIndex++;
                }
            }
            return totalArea;
        }
    }

}
