using System;

namespace CodePractice
{
    class StackExt
    {
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
