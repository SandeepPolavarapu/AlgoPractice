using System;
using System.Collections.Generic;

namespace CodePractice
{
    class StackExt
    {
        Stack<int> s1 = new Stack<int>();
        Stack<int> s2 = new Stack<int>();

        public void Enqueue(int ele)
        {
            s1.Push(ele);
        }

        public int Dequeue()
        {
            MoveElements();
            return s2.Pop();
        }

        public int Top()
        {
            MoveElements();
            return s2.Peek();
        }

        private void MoveElements()
        {
            if (s2.Count == 0)
            {
                while (s1.Count != 0)
                {
                    s2.Push(s1.Pop());
                }
            }
        }
    }

    public class MyStack<T>
    {
        private class StackNode<T>
        {
            public T data;
            public StackNode<T> Next;

            public StackNode(T data)
            {
                this.data = data;
            }
        }

        private StackNode<T> top;

        public T Pop()
        {
            if (top == null)
                throw new Exception();
            T item = top.data;
            top = top.Next;
            return item;
        }

        public void Push(T item)
        {
            StackNode<T> t = new StackNode<T>(item);
            t.Next = top;
            top = t;
        }

        public T Peek()
        {
            if (top == null)
                throw new Exception();
            return top.data;
        }

        public bool IsEmpty()
        {
            return top == null;
        }
    }
}
