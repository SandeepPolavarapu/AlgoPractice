using CodePractice.Tree;
using System;

namespace CodePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeAlgo();
            //TrieAlgo();
            //HeapAlgo();
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

        static void TrieAlgo()
        {
            Trie t = new Trie();
            t.CreateRoot();
            int n = Convert.ToInt32(Console.ReadLine());

            for (int nItr = 0; nItr < n; nItr++)
            {
                string[] opContact = Console.ReadLine().Split(' ');

                string op = opContact[0];

                string contact = opContact[1];
                switch (op)
                {
                    case "add":
                        t.Add(contact.ToCharArray());
                        break;
                    case "find":
                        Console.WriteLine(t.FindPrefix(contact.ToCharArray()));
                        break;

                }
            }

        }

        static void AddNumber(int num, MinHeap min, MaxHeap max)
        {
            if (min.Length() == 0 || num < min.Peek())
                min.Add(num);
            else
                max.Add(num);
        }

        static void ReBalance(MinHeap min, MaxHeap max)
        {
            if (min.Length() - max.Length() >= 2)
            {
                max.Add(min.Poll());
            }
            else if (max.Length() - min.Length() >= 2)
            {
                min.Add(max.Poll());
            }
        }

        static decimal GetMedian(MinHeap min, MaxHeap max)
        {
            if (min.Length() == max.Length())
                return Decimal.Divide(min.Peek() + max.Peek(), 2);
            else if (min.Length() > max.Length())
                return min.Peek();
            else
                return max.Peek();
        }

        static void HeapAlgo()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            decimal median;
            MaxHeap max = new MaxHeap(n);
            MinHeap min = new MinHeap(n);
            for (int i = 0; i < n; i++)
            {
                int aItem = Convert.ToInt32(Console.ReadLine());
                AddNumber(aItem, min, max);
                ReBalance(min, max);
                median = GetMedian(min, max);
                //int diff = max.Length() - min.Length();
                //switch (diff)
                //{
                //    case 0:
                //        if (aItem < median)
                //        {
                //            max.Add(aItem);
                //            median = max.Peek();
                //        }
                //        else
                //        {
                //            min.Add(aItem);
                //            median = min.Peek();
                //        }
                //        break;
                //    case 1:
                //        if (aItem < median)
                //        {
                //            min.Add(max.Poll());
                //            max.Add(aItem);
                //        }
                //        else
                //        {
                //            min.Add(aItem);
                //        }
                //        median = Decimal.Divide(min.Peek() + max.Peek(), 2);
                //        break;
                //    case -1:
                //        if (aItem < median)
                //        {
                //            max.Add(aItem);
                //        }
                //        else
                //        {
                //            max.Add(min.Poll());
                //            min.Add(aItem);
                //        }
                //        median = Decimal.Divide(min.Peek() + max.Peek(), 2);
                //        break;
                //}
                Console.WriteLine("{0:N1}", median);
            }
        }
    }
}
