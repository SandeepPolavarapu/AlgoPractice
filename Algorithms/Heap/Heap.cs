namespace CodePractice
{

    abstract class Heap
    {
        protected int curIndex;
        protected int size;
        protected int[] a;
        public Heap(int n)
        {
            size = n;
            a = new int[n];
        }

        public int Length()
        {
            return curIndex;
        }

        public int Peek()
        {
            return a[0];
        }

        public int Poll()
        {
            int item = a[0];
            a[0] = a[curIndex - 1];
            curIndex--;
            HeapifyDown();
            return item;
        }

        public void Add(int item)
        {
            a[curIndex] = item;
            curIndex++;
            HeapifyUp();
        }

        protected void Swap(int index1, int index2)
        {
            int temp = a[index1];
            a[index1] = a[index2];
            a[index2] = temp;
        }

        protected abstract void HeapifyDown();


        protected abstract void HeapifyUp();


        protected int GetLeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        protected int GetRightChildIndex(int index)
        {
            return index * 2 + 2;
        }

        protected int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        protected bool HasLeftChild(int index)
        {
            return curIndex >= GetLeftChildIndex(index);
        }

        protected bool HasRightChild(int index)
        {
            return curIndex >= GetRightChildIndex(index);
        }

        protected bool HasParent(int index)
        {
            return GetParentIndex(index) >= 0;
        }

        protected int GetLeftChild(int index)
        {
            return a[GetLeftChildIndex(index)];
        }

        protected int GetRightChild(int index)
        {
            return a[GetRightChildIndex(index)];
        }

        protected int GetParent(int index)
        {
            return a[GetParentIndex(index)];
        }
    }

    class MaxHeap : Heap
    {
        public MaxHeap(int size) : base(size) { }
        protected override void HeapifyDown()
        {
            int index = 0;
            while (true)
            {
                int maxIndex = 0;
                if (HasLeftChild(index) && HasRightChild(index))
                    maxIndex = GetLeftChild(index) > GetRightChild(index) ? GetLeftChildIndex(index) : GetRightChildIndex(index);
                else if (HasLeftChild(index))
                    maxIndex = GetLeftChildIndex(index);

                if (a[index] >= a[maxIndex])
                    break;
                else
                    Swap(index, maxIndex);
                index = maxIndex;
            }

        }

        protected override void HeapifyUp()
        {
            int index = curIndex - 1;
            while (HasParent(index) && a[index] > GetParent(index))
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }
    }

    class MinHeap : Heap
    {
        public MinHeap(int size) : base(size) { }

        protected override void HeapifyDown()
        {
            int index = 0;

            while (true)
            {
                int minIndex = 0;
                if (HasLeftChild(index) && HasRightChild(index))
                    minIndex = GetLeftChild(index) < GetRightChild(index) ? GetLeftChildIndex(index) : GetRightChildIndex(index);
                else if (HasLeftChild(index))
                    minIndex = GetLeftChildIndex(index);

                if (a[index] <= a[minIndex])
                    break;
                else
                    Swap(index, minIndex);
                index = minIndex;
            }

        }

        protected override void HeapifyUp()
        {
            int index = curIndex - 1;

            while (HasParent(index) && a[index] < GetParent(index))
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }

        }

    }

}
