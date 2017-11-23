
using System;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //NumberExt.PrintOdd(3, 9);

            //NumberExt.SortPoints();

            //StringExt.PrefixStringEval();

            //StringExt.StringPermutation("abc", "");

            //String txt = "BACDGABCDA";
            //String pat = "ABCD";
            //StringExt.Search(pat, txt);


            //int[] a = new int[8] { 10, 80, 30, 90, 40, 50, 70, 10 };
            //Sorting.MergeSort(a, 0, 4);
            //Sorting.QuickSort(a, 0, 4);
            //Sorting.CountSort(a, 8, 10);
            //for (int i = 0; i < a.Length; i++)
            //    Console.WriteLine(a[i]);

            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)};

            var graph = new Graph<int>(vertices, edges);

            Console.WriteLine(string.Join(", ", GraphAlgorithms.DFS(graph, 2)));

            Console.WriteLine(string.Join(", ", GraphAlgorithms.BFS(graph, 2)));

            System.Console.Read();
            //System.Console.WriteLine("Hello World!\n");
        }



    }
}
