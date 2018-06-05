using CodePractice.Tree;
using System;

namespace CodePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //TreeAlgo();

            HeapAlgo();
            Console.Read();

            //Console.WriteLine("Hello World!\n");
        }

        static void NumberExtension()
        {
            NumberExt.PrintOdd(3, 9);
            NumberExt.SortPoints();
        }

        static void StringExtension()
        {
            StringExt.PrefixStringEval();

            StringExt.StringPermutation("abc", "");

            String txt = "BACDGABCDA";
            String pat = "ABCD";
            StringExt.Search(pat, txt);
        }

        static void SortingAlgo()
        {
            int[] a = new int[7] { 5, 3, 6, 4, 1, 2, 9 };
            //Sorting.MergeSort(a, 0, 6);
            //Sorting.QuickSort(a, 0, 6);
            //Sorting.QuickSortCC(a, 0, 6);
            Sorting.CountSort(a, 7, 1);
            for (int i = 0; i < a.Length; i++)
                Console.WriteLine(a[i]);
        }

        static void LinkedListAlgo()
        {
            Node head = LinkedListExt.CreateList(new int[] { 1, 3, 5, 1, 7 });
            head.DisplayList();
            head.DeleteDuplicates();
            head.DisplayList();
            LinkedListExt.PrintKthToLast(head, 2);
            int i = 0;
            Console.WriteLine(LinkedListExt.PrintKthToLast(head, 2, ref i).Data);
        }
        static void GraphAlgo()
        {
            GraphExt.ExecuteDirectedGraph();
        }
        static void TreeAlgo()
        {
            TreeExt.Execute();

        }

        static void StackAlgo()
        {
            StackExt se = new StackExt();

            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                string expression = Console.ReadLine();
                //Console.WriteLine(expression);
                if (expression[0] == '1')
                    se.Enqueue(Convert.ToInt32(expression.Substring(2)));
                else if (expression == "2")
                    se.Dequeue();
                else
                    Console.WriteLine(se.Top());
            }
        }

        static void HeapAlgo()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            Heap.Heap mh = new Heap.MaxHeap(n);
            for (int i = 0; i < n; i++)
            {
                int aItem = Convert.ToInt32(Console.ReadLine());
                mh.Add(aItem);
                Console.WriteLine(mh.Poll());
            }
        }
    }
}
