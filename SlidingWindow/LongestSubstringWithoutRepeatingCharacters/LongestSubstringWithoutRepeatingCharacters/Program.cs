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
            Console.WriteLine(bruteForceSolution.LengthOfLongestSubstring(s2));
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
}
