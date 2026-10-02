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
            string s8 = "abba";

            //Console.WriteLine(bruteForceSolution.LengthOfLongestSubstring(s2));

            //SlightlyOptimalSolution slightlyOptimalSolution = new SlightlyOptimalSolution();
            //Console.WriteLine(slightlyOptimalSolution.LengthOfLongestSubstring(s4));

            MostOptimalSolution mostOptimalSolution = new MostOptimalSolution();
            Console.WriteLine(mostOptimalSolution.LengthOfLongestSubstring(s5));
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


    /*
The main key to solve this problem

1. Loop through the string
2. left will be the starting index of the current continuous substring/window
3. right is the index of the actual char that we are currently scanning
4. If unique, put the string char as a dictionary key and its index (i.e. right) as the value, compare the max length values
5. If duplicate i.e. dictionary contains the char:
   5.1) Get the index where the char was last seen
   5.2) Move left to the index where it was last seen + 1 only if its inside or at sliding window
   5.3) Calculate the length of the current continuous sequence using:
        right - left + 1
        (+1 is essential because both left and right are included)
   5.4) Compare this length with the current max length
6. Update the dictionary with the current char and its latest index (right)
7. Finally return current max length

Key things to remember:

- Dictionary = char → most recent index
- left = start of current valid window
- right = character currently being scanned
- No need to use Substring()
- right - left + 1 = length of the current window
- left and right only move forward
- O(n) time because we scan the string once and dictionary lookup is O(1) average
- O(m) space complexity because of dictionary and we can only store unique characters in it, m is the unique chars in a string
*/
    public class MostOptimalSolution()
    {
        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int left = 0;
            int currentLength = 0;
            int maxLength = 0;

            for (int right = 0; right < s.Length; right++)
            {
                if (dict.ContainsKey(s[right])) //if duplicate found
                {
                    int lastSeenIndex = dict[s[right]];
                    dict[s[right]] = right; //update the lastSeenIndex dictionary value with new index

                    if (lastSeenIndex >= left) //i.e. only move left if its inside or at the sliding window ***
                    {
                        left = lastSeenIndex + 1;
                    }
                    

                    currentLength = right - left + 1;
                    maxLength = maxLength > currentLength ? maxLength : currentLength;

                } else
                {
                    dict.Add(s[right], right);
                    currentLength = right - left + 1;
                    maxLength = maxLength > currentLength ? maxLength : currentLength;
                }

            }

            return maxLength;

        }
    }
}
