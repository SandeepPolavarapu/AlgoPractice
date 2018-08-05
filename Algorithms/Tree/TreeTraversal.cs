using System;
using System.Collections;

namespace CodePractice.Tree
{
    class TreeTraversal : IEnumerator
    {
        public object Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    class TreeTraversalIterative
    {
        public static void PostOrder(Node root)
        {
            if (root == null)
                return;

            MyStack<Node> s1 = new MyStack<Node>();
            MyStack<Node> s2 = new MyStack<Node>();

            s1.Push(root);

            while (!s1.IsEmpty())
            {
                Node node = s1.Pop();

                if (node.Left != null)
                    s1.Push(node.Left);

                if (node.Right != null)
                    s1.Push(node.Right);

                s2.Push(node);
            }

            while (!s2.IsEmpty())
                Console.Write(s2.Pop().Data + " ");

        }

        public static void PreOrder(Node root)
        {
            if (root == null)
                return;

            MyStack<Node> s1 = new MyStack<Node>();
            s1.Push(root);

            while (!s1.IsEmpty())
            {
                Node node = s1.Pop();

                if (node.Right != null)
                    s1.Push(node.Right);

                if (node.Left != null)
                    s1.Push(node.Left);

                Console.Write(node.Data + " ");
            }
        }

        public static void InOrder(Node root)
        {
            if (root == null)
                return;

            MyStack<Node> s1 = new MyStack<Node>();
            Node current = root;

            while (true)
            {
                while (current != null)
                {
                    s1.Push(current);
                    current = current.Left;
                }

                if (s1.IsEmpty())
                    break;

                Node node = s1.Pop();

                Console.Write(node.Data + " ");
                current = node.Right;
            }
        }

        public static void PostOrderWithOneStack(Node root)
        {
            if (root == null)
                return;

            MyStack<Node> s1 = new MyStack<Node>();

            Node current = root;

            while (current != null || !s1.IsEmpty())
            {
                if (current != null)
                {
                    s1.Push(current);
                    current = current.Left;
                }
                else
                {
                    Node temp = s1.Peek().Right;
                    if (temp == null)
                    {
                        temp = s1.Pop();
                        Console.Write(temp.Data + " ");

                        while (!s1.IsEmpty() && temp == s1.Peek().Right)
                        {
                            temp = s1.Pop();
                            Console.Write(temp.Data + " ");
                        }
                    }
                    else
                    {
                        current = temp;
                    }
                }
            }
        }

        public static void MorrisPreOrderTraversal(Node root)
        {
            if (root == null)
                return;

            Node current = root;

            while (current != null)
            {
                if (current.Left == null)
                {
                    Console.Write(current.Data + " ");
                    current = current.Right;
                }
                else
                {
                    Node predecessor = current.Left;
                    while (predecessor.Right != null && predecessor.Right != current)
                    {
                        predecessor = predecessor.Right;
                    }

                    if (predecessor.Right == null)
                    {
                        predecessor.Right = current;
                        Console.Write(current.Data + " ");
                        current = current.Left;
                    }
                    else
                    {
                        predecessor.Right = null;
                        current = current.Right;
                    }
                }
            }
        }

        public static void MorrisInOrderTraversal(Node root)
        {
            if (root == null)
                return;

            Node current = root;

            while (current != null)
            {
                if (current.Left == null)
                {
                    Console.Write(current.Data + " ");
                    current = current.Right;
                }
                else
                {
                    Node predecessor = current.Left;
                    while (predecessor.Right != null && predecessor.Right != current)
                    {
                        predecessor = predecessor.Right;
                    }
                    if (predecessor.Right == null)
                    {
                        predecessor.Right = current;
                        current = current.Left;
                    }
                    else
                    {
                        predecessor.Right = null;
                        Console.Write(current.Data + " ");
                        current = current.Right;
                    }
                }
            }
        }
    }
}
