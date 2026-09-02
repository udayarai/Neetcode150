namespace BestTimeToBuyAndSellStock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] prices = new int[] { 10, 1, 5, 6, 7, 1 };
            Solution sol = new Solution();
            //Console.WriteLine(sol.MaxProfit(prices));

            OptimalSolution optSol = new OptimalSolution();
            Console.WriteLine(optSol.MaxProfit(prices));
        }
    }

    /*
    Brute force method involves looping each item and comparing it with other items
    General rule of thumb is for second loop we must do i + 1 because we cannot buy at past prices
    time complexity is O(N2) because we are using two for loops and looping through each items i.e. n * n = n2
    space complexity is O(1) as we are using variables profit, potential profit which does not increase with increasing input length
     
    */

    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            int profit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                for (int j = i+1; j < prices.Length; j++)
                {
                    int potentialProfit = prices[j] - prices[i];

                    if (potentialProfit > profit )
                    {
                        profit  = potentialProfit;
                    }
                }
            }
            return profit;
        }
    }


    /*
    key idea for solving this problem is if prices[left] < prices[right] then it is profitable else prices[left] = pricesright]
    this works because we assume prices[left] is the current lowest value if prices[left] !< prices[right] then by assigning prices[left] = prices[right] we update our lowest value
    The key idea is maintaining prices[left] as our lowest buying price so far. As we scan forward, if prices[left] < prices[right], we have a profitable window and can update our max profit. Otherwise, we found a new lowest price, so we jump left = right to reset our buying baseline, then continue moving right forward.
    time complexity: because we only use one for loop time complexity is O(N)
    space complexity: we only use constant variables left, right, maxProfit whose values are updated but does not increase with input length so it is O(1)
    */
    public class OptimalSolution
    {
        public int MaxProfit(int[] prices)
        {
            int left = prices[0];
            int right = 0;
            int maxProfit = 0;

            for (int i = 0; i < prices.Length; i++) //can use while loop while (left < right)
            {
                if (i != prices.Length - 1)
                {
                    right = prices[i + 1];
                }
                
                if (left < right)
                {
                    int profit = right - left;
                    if (profit > maxProfit)
                    {
                        maxProfit = profit;
                    }
                }
                else
                {
                    left = right; //we have already found the lower value so we just switch right to left
                }
            }
            return maxProfit;
        }
    }

}
