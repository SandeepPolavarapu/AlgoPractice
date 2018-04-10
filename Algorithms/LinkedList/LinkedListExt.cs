using System;
using System.Collections.Generic;

namespace CodePractice
{
    class LinkedListExt
    {
        public static Node CreateList(int[] arr)
        {
            Node head = null;
            foreach (int i in arr)
            {
                if (head == null)
                {
                    head = new Node(i);
                }
                else
                    head.AppendToTail(i);
            }
            return head;
        }

        public static int PrintKthToLast(Node head, int k)
        {
            if (head == null)
                return 0;
            int n = PrintKthToLast(head.Next, k) + 1;
            if (n == k)
                Console.WriteLine("Data at {0}th to Last is:{1}", k, head.Data);
            return n;
        }

        public static Node PrintKthToLast(Node head, int k, ref int i)
        {
            if (head == null)
                return null;
            Node node = PrintKthToLast(head.Next, k, ref i);
            i++;
            if (i == k)
                return head;
            return node;
        }


    }
    class Node
    {
        public int Data;
        public Node Next;

        public Node(int data)
        {
            Data = data;
        }

        public void AppendToTail(int d)
        {
            Node end = new Node(d);
            Node n = this;
            while (n.Next != null)
                n = n.Next;
            n.Next = end;
        }

        public void DisplayList()
        {
            Node node = this;
            while (node != null)
            {
                Console.WriteLine(node.Data);
                node = node.Next;
            }
        }

        public void DeleteDuplicates()
        {
            HashSet<int> ht = new HashSet<int>();
            Node node = this;
            Node prev = null;
            while (node != null)
            {
                if (ht.Contains(node.Data))
                {
                    prev.Next = node.Next;
                }
                else
                {
                    ht.Add(node.Data);
                    prev = node;
                }
                node = node.Next;
            }
        }
    }
}
