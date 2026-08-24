namespace ContainerWithMostWater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BruteForceSolution sol = new BruteForceSolution();
            int[] height = [1, 7, 2, 5, 4, 7, 3, 6];
            //Console.WriteLine(sol.MaxArea(height));
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
}
