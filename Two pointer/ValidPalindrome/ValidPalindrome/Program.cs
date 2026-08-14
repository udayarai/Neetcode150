using System.Text.RegularExpressions;

namespace ValidPalindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution1 solution1 = new Solution1();
            string s = "Was it a car or a cat I saw?";
            string s1 = "OP";
            //Console.WriteLine(solution1.IsPalindrome(s1));

            Solution2 solution2 = new Solution2();
            Console.WriteLine(solution2.IsPalindrome(s));
            
        }
    }

    /*
    time complexity = O(N)
    space complexity = O(N)

    Key is to rember how to use Regex that makes our life much easier
    1) format text using regex to only accept letters, numbers and convert it to lowercase
    2) create an empty string to store reverse string
    3) loop through the formatted string in reverse order
    4) add to the empty string you created earlier as you go through each item
    5) finally compare if the original string and the reversed string are same

    */

    public class Solution1
    {
        public bool IsPalindrome(string s)
        {
            string formattedS = Regex.Replace(s, @"[^A-Za-z0-9]", "").ToLower();
            string reversedS = "";

            for (int i = formattedS.Length - 1; i >= 0; i--)
            {
                reversedS += formattedS[i];
            }

            //Console.WriteLine(reversedS);
            //Console.WriteLine(formattedS);

            if (reversedS == formattedS)
            {
                return true;
            }
            
            return false;
        }
    }


    /*
    time complexity = O(N)
    space complexity = O(1)

    Key is to rember how to use Regex that makes our life much easier
    1) format text using regex to only accept letters, numbers and convert it to lowercase
    2) remember in palindrome we have to compare front and back for e.g. abba a must equal a and b must equal b, if odd middle does not need to match 
    3) assign leftIndex = 0 (start left) and rightIndex = formattedString.Length - 1 (o indexed)
    4) use a while loop to say while leftIndex is smaller than rightIndex (allows us to keep moving till we meet at middle)
    5) within the loop now if the left and right index does not match throw false immediately
    6) after loop return true to indicate everything matches except middle

    */

    public class Solution2
    {
        public bool IsPalindrome(string s)
        {
            string formattedS = Regex.Replace(s, @"[^A-Za-z0-9]", "").ToLower();
            int leftIndex = 0;
            int rightIndex = formattedS.Length - 1;

            while(leftIndex < rightIndex)
            {
                if (formattedS[leftIndex] != formattedS[rightIndex])
                {
                    return false;
                }
                leftIndex++;
                rightIndex--;
            }

            return true;
        }
    }
}
