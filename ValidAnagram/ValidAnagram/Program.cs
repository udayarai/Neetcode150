/*
Given two strings s and t, return true if the two strings are anagrams of each other, otherwise return false.

An anagram is a string that contains the exact same characters as another string, but the order of the characters can be different. 

Input: s = "racecar", t = "carrace"

Output: true
 
*/




using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace ValidAnagram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.IsAnagram("racecar", "carrace"));
            
        }

        public bool IsAnagram(string s, string t)
        {
            //first check the length must be equal
            if (s.Length != t.Length)
            {
                return false;
            }

            ////convert strings into char arrays
            //char[] sArr = s.ToCharArray();
            //char[] tArr = t.ToCharArray();

            ////sort out the arrays
            //Array.Sort(sArr);
            //Array.Sort(tArr);

            ////compare the array contents 
            //return sArr.SequenceEqual(tArr);

            Dictionary<char, int> charFrequency = new Dictionary<char, int>();

            //loop through the string s and add frequency
            foreach (char letter in s)
            {
                if (charFrequency.ContainsKey(letter))
                {
                    charFrequency[letter]++;
                } else
                {
                    charFrequency.Add(letter, 1);
                }
            }

            //loop through the string and remove frequency
            foreach (char letter in t)
            {
                if (!charFrequency.ContainsKey(letter))
                {
                    return false;
                    
                }

                charFrequency[letter]--;

                if (charFrequency[letter] < 0)
                {
                    return false;
                }
            }

            foreach (var item in charFrequency)
            {
                if (item.Value != 0)
                {
                    return false;
                }    
            }

            return true;
        }
    }
}
