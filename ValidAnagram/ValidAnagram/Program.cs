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

            //convert strings into char arrays
            char[] sArr = s.ToCharArray();
            char[] tArr = t.ToCharArray();

            //sort out the arrays
            Array.Sort(sArr);
            Array.Sort(tArr);

            //compare the array contents 
            return sArr.SequenceEqual(tArr);
        }
    }
}
