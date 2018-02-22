using System;

namespace ConsoleApplication1
{
    public static class StringExt
    {
        static int MAX = 256;
        static bool compare(char[] arr1, char[] arr2)
        {
            for (int i = 0; i < MAX; i++)
                if (arr1[i] != arr2[i])
                    return false;
            return true;
        }

        // This function search for all permutations
        // of pat[] in txt[]
        public static void Search(String pat, String txt)
        {
            int M = pat.Length;
            int N = txt.Length;

            // countP[]:  Store count of all 
            // characters of pattern
            // countTW[]: Store count of current
            // window of text
            char[] countP = new char[MAX];
            char[] countTW = new char[MAX];
            for (int i = 0; i < M; i++)
            {
                (countP[pat[i]])++;
                (countTW[txt[i]])++;
            }

            // Traverse through remaining characters
            // of pattern
            for (int i = M; i < N; i++)
            {
                // Compare counts of current window
                // of text with counts of pattern[]
                if (compare(countP, countTW))
                    Console.WriteLine("Found at Index " + (i - M));

                // Add current character to current 
                // window
                (countTW[txt[i]])++;

                // Remove the first character of previous
                // window
                countTW[txt[i - M]]--;
            }

            // Check for the last window in text
            if (compare(countP, countTW))
                Console.WriteLine("Found at Index " + (N - M));
        }


        public static void StringPermutation(string str, string prefix)
        {
            if (str.Length == 0)
                Console.WriteLine(prefix);
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    string rem = str.Substring(0, i) + str.Substring(i + 1);
                    StringPermutation(rem, prefix + str[i]);
                }
            }

        }
        public static void PrefixStringEval()
        {
            var myInput = Console.ReadLine().Trim();
            int output = 0;
            string[] myInputArray = myInput.Split(' ');
            int input1 = int.Parse(myInputArray[1]);
            int input2 = int.Parse(myInputArray[2]);
            switch (myInputArray[0])
            {
                case "+":
                    output = input1 + input2;
                    break;
                case "-":
                    output = input1 - input2;
                    break;
                case "/":
                    output = input1 / input2;
                    break;
                case "*":
                    output = input1 * input2;
                    break;
                case "%":
                    output = input1 % input2;
                    break;
            }
            System.Console.WriteLine(output);
        }

        public static bool IsUniqueChar(string s)
        {
            bool[] countP = new bool[MAX];
            foreach (char c in s)
            {
                if (countP[c])
                    return false;
                else
                    countP[c] = true;
            }
            return true;
        }
    }
}
