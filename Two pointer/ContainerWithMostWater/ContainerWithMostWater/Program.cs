namespace ContainerWithMostWater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BruteForceSolution sol = new BruteForceSolution();
            int[] height = [1, 7, 2, 5, 4, 7, 3, 6];
            //Console.WriteLine(sol.MaxArea(height));

            OptimumSolution sol2 = new OptimumSolution();
            int[] height2 = [1, 7, 2, 5, 4, 7, 3, 6];
            int[] height3 = [1, 7, 2, 5, 12, 3, 500, 500, 7, 8, 4, 7, 3, 6];
            Console.WriteLine(sol2.MaxArea(height3));
        }


    }

    /*
    1. Below solution is a brute force solution
    2. Time complexity is O(N2) because we are looping through each and every element twice making it n x n. I am using 2 nested loops to examin every pair of bars.
    3. Space complexity is O(1) because I am only using a fixed number of variables and i am not creating any additional data structures that grows with the input size
    */

    public class BruteForceSolution
    {
        public int MaxArea(int[] heights)
        {
            int height;
            int maxHeight = 0;

            for (int i = 0; i < heights.Length; i++)
            {
                int heightOfBar1 = heights[i];
                //Console.WriteLine(i);
                for (int j = 0; j < heights.Length; j++)
                {
                    if (i != j)
                    {
                        int heightOfBar2 = heights[j];
                        //set the height
                        if (heightOfBar1 > heightOfBar2)
                        {
                            height = heightOfBar2;
                        } else
                        {
                            height = heightOfBar1;
                        }

                        int width = j - i;
                        int area = height * width;

                        if (area > maxHeight)
                        {
                            maxHeight = area;
                        }
                        
                        //Console.WriteLine(j);
                    }
                }
            }

            return maxHeight;
        }
    }

    public class OptimumSolution
    {
        public int MaxArea(int[] heights)
        {
            //we cannot sort as we will change the width
            //we know moving left pointer reduces the width possibly reducing the area
            //we know we height is the minimum of the two boxes because water splills over the shorter wall
            //when we move left we possibly increase or decrease the area depending on height how do we have  a more chance of finding bigger area
            //by moving the shorter bar we may find the bar with a taller height moving the long bar does have little effect as the height is already low
            //time complexity is O(N) because we are only looping once and we do not have multiple loops
            //space complexity is O(1) because I am using fixed variables and i am not creating any additional data structures that grows with the input size

            int leftIndex = 0;
            int rightIndex = heights.Length - 1;
            int maxArea = 0;

            while (leftIndex < rightIndex) 
            {
                int leftBarHeight = heights[leftIndex];
                int rightBarHeight = heights[rightIndex];

                int height = leftBarHeight > rightBarHeight ? rightBarHeight : leftBarHeight;
                int width = rightIndex - leftIndex;
                int area = height * width;
                if (area > maxArea)
                {
                    maxArea = area;
                }

                if (leftBarHeight == rightBarHeight) //we can move either direction
                {
                    leftIndex += 1;
                } else if (leftBarHeight < rightBarHeight)
                {
                    leftIndex += 1;
                } else
                {
                    rightIndex -= 1; //need to reduce the right index
                }

                if (leftIndex == rightIndex) //there wont be two bars to compare //not necessary as while condiiton already handles it
                {
                    break;
                }

            }
            return maxArea;
        }
    }
}
