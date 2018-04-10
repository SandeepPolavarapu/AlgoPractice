using System;

namespace CodePractice
{
    class QueueExt
    {
    }

    public class MyQueue<T>
    {
        private class QueueNode<T>
        {
            public T Data;
            public QueueNode<T> Next;

            public QueueNode(T data)
            {
                this.Data = data;
            }
        }

        private QueueNode<T> First;
        private QueueNode<T> Last;

        public void Add(T item)
        {
            QueueNode<T> node = new QueueNode<T>(item);

            if (Last != null)
            {
                Last.Next = node;
            }
            Last = node;
            if (First == null)
                First = Last;
        }

        public T Remove()
        {
            if (First == null)
                throw new Exception();
            T data = First.Data;
            First = First.Next;
            if (First == null)
                Last = null;
            return data;
        }

        public T Peek()
        {
            if (First == null)
                throw new Exception();
            return First.Data;
        }

        public bool IsEmpty()
        {
            return First == null;
        }
    }
}
