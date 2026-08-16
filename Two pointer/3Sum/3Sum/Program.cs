namespace _3Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = [-1, 0, 1, 2, -1, -4];
            Console.WriteLine(ThreeSum(nums));
        }

        static List<List<int>> ThreeSum(int[] nums)
        {
            //sort the array
            Array.Sort(nums);
            List<List<int>> result = new List<List<int>>();
            

            for (int i=0; i < nums.Length; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];
                    if (sum < 0) //move left
                    {
                        left += 1;
                    } else if (sum > 0) //move right
                    {
                        right -= 1;
                    } else
                    {
                        List<int> output = new List<int> { nums[i], nums[left], nums[right] };

                        bool containsDuplicate = false;
                        //check for duplicates
                        foreach (List<int> item in result)
                        {
                            
                            
                            if (item[0] == output[0] && item[1] == output[1]  && item[2] == output[2])
                            {
                                containsDuplicate = true;
                            } else
                            {
                                containsDuplicate = false;
                            }
                            
                            //if (containsDuplicate)
                            //{
                            //    left += 1;
                            //    break;
                            //}
                        }
                        if (!containsDuplicate)
                        {
                            result.Add(output);
                        }
                        left += 1; //need to keep moving
                    }
                }
            }

            return result;
        }
    }
}


//[-4, -1, -1, 0, 1, 2]

//    -4

//    -1  2 = -3
//    -1  2 = -3
//     0  2 = -2 
//     1  2 = -1


//   -1
//   -1  2    0 tick
//    0  2    1
//    0  1    0 tick


//   -1
//    0  2   1
//    0  1   0 tick