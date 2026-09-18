namespace LongestSubstringWithoutRepeatingCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BruteForceSolution bruteForceSolution = new BruteForceSolution();
            string s = "zxyzxyz";
            string s1 = " ";
            string s2 = "dvdf";
            string s3 = "abcabcbb";
            string s4 = "bbbbb";
            string s5 = "pwwkew";
            string s6 = "a b c d";
            string s7 = "thequickbrownfoxjumpsoverthelazydogthequickbrownfoxjumpsovert";

            //Console.WriteLine(bruteForceSolution.LengthOfLongestSubstring(s2));

            SlightlyOptimalSolution slightlyOptimalSolution = new SlightlyOptimalSolution();
            Console.WriteLine(slightlyOptimalSolution.LengthOfLongestSubstring(s4));
        }
    }

    /*
    we need to convert char into numbers so we know whether it is a continuous string or not and one way to do this is find ASCII of a char

     
    */
    public class BruteForceSolution
    {
        public int LengthOfLongestSubstring(string s)
        {
            List<int> tempList = new List<int>();
            int charAscii;
            int maxLength = 0;

            //loop through each chars
            foreach (char c in s)
            {
                charAscii = (int)c;

                //if list is empty
                if (tempList.Count == 0)
                {
                    tempList.Add(charAscii); //put in char ascii 
                    continue;
                }

                //if duplicate then clear temp list
                if (tempList.Contains(charAscii))
                {
                    if (tempList.Count > maxLength)
                    {
                        maxLength = tempList.Count;
                    }

                    int index = tempList.IndexOf(charAscii); //find the index of charAscii
                    tempList.RemoveRange(0, index + 1); //just remove the original charAscii and everything before it
                    
                    tempList.Add(charAscii); //now add this duplicate charAscii
                } else
                {
                    tempList.Add(charAscii);
                }        
            }

            //to account for cases with single element 
            if (tempList.Count > maxLength)
            {
                maxLength = tempList.Count;
            }


            //if temp array is not empty then current ascii char = temp[temp.Length - 1] this makes it continuous 
            //if not continuous then we reset the temp array
            return maxLength;
        }
    }


    /*
    This solution is conceptually similar to bruteforce solution above

    time complexity is O(N2) because there is one for loop plus .Contains and .IndexOf both can take O(N) and O(N2) become
    space complexity is O(N) because the variable can increase with the increase in string s
     
    1 main thing to solve this problem is we need variable maxLength and a subString
    2 we need to loop through string s we need this for index
    3 as we move our index if there are no duplicates we simply add the element to our subString
    4 if we have a duplicate we find the index and then we reassign our substring by removing duplicate and everything before it
    5 we must re-evaluate maxLength inside duplicate check and at the end 
    6 the most tricky part is for no 3 we must also check substring is not equal to element if that's the case do not add element this is 
        mainly there could be single element only 

     */

    public class SlightlyOptimalSolution
    {
        public int LengthOfLongestSubstring(string s)
        {
            int maxLength = 0;
            string subString = "";

            int leftIndex = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (subString.Contains(s[i]))
                {
                    int duplicateIndex = subString.IndexOf(s[i]); //find the duplicateIndex in the subString
                    subString = subString.Substring(duplicateIndex + 1); //remove duplicate and all elements before it 

                    if (maxLength < subString.Length)
                    {
                        maxLength = subString.Length;
                    }
                }

                if (subString != s[i].ToString())
                {
                    subString += s[i];
                }


                if (maxLength < subString.Length)
                {
                    maxLength = subString.Length;
                }
            }


            return maxLength;
        }
    }
}
