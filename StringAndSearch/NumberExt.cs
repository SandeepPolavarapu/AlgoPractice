using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    static class NumberExt
    {
        public static void PrintOdd(int l, int r)
        {
            if (l % 2 == 0)
            {
                l = l + 1;
            }
            int arrayLength = (r - l) / 2 + 1;
            int[] oddNos = new int[arrayLength];
            int i = 0;
            do
            {
                oddNos[i] = l;
                i++;
                l = l + 2;
            } while (l <= r);

            for (int j = 0; j < oddNos.Length; j++)
                Console.WriteLine(oddNos[j]);

        }

        public static void SortPoints()
        {
            //Read input from stdin and provide input before running
            var line1 = System.Console.ReadLine().Trim();
            var N = Int32.Parse(line1);
            List<Tuple<int, int>> inputList = new List<Tuple<int, int>>();
            for (var i = 0; i < N; i++)
            {
                line1 = System.Console.ReadLine().Trim();
                var stringArray = line1.Split(' ');
                inputList.Add(new Tuple<int, int>(Int32.Parse(stringArray[0]), Int32.Parse(stringArray[1])));
            }
            inputList.Sort((x, y) =>
            {
                int res = x.Item1.CompareTo(y.Item1);
                return res != 0 ? res : y.Item2.CompareTo(x.Item2);
            });

            foreach (Tuple<int, int> set in inputList)
                Console.WriteLine(set.Item1 + " " + set.Item2);

        }
    }
}
