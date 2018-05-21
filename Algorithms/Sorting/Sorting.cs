
namespace CodePractice
{
    public static class Sorting
    {

        public static void InsertionSort(int[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                int j = i - 1;
                int value = a[i];
                while (j >= 0 && value < a[j])
                {
                    a[j + 1] = a[j];
                    j = j - 1;
                }
                a[j + 1] = value;
            }
        }

        public static void SelectionSort(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < a[minIndex])
                        minIndex = j;
                }
                if (minIndex != i)
                {
                    int temp = a[i];
                    a[i] = a[minIndex];
                    a[minIndex] = temp;
                }
            }
        }

        public static void BubbleSort(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                bool swapped = false;
                for (int j = 0; j < a.Length - i; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int temp = a[j + 1];
                        a[j + 1] = a[j];
                        a[j] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }
        }


        public static void MergeSort(int[] a, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;
                MergeSort(a, start, mid);
                MergeSort(a, mid + 1, end);

                Merge(a, start, mid, end);
            }
        }

        static void Merge(int[] a, int start, int mid, int end)
        {
            int i = 0, j = 0, k = start;
            int n1 = mid - start + 1;
            int n2 = end - mid;
            int[] left = new int[n1];
            int[] right = new int[n2];

            for (i = 0; i < n1; i++)
            {
                left[i] = a[start + i];
            }
            for (i = 0; i < n2; i++)
            {
                right[i] = a[mid + 1 + i];
            }

            i = 0;
            while (i < n1 && j < n2)
            {
                if (left[i] < right[j])
                {
                    a[k] = left[i];
                    i++;
                }
                else
                {
                    a[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                a[k++] = left[i++];
            }

            while (j < n2)
            {
                a[k++] = right[j++];
            }
        }

        public static void QuickSort(int[] a, int start, int end)
        {
            if (start < end)
            {
                int pivot = Pivot(a, start, end);
                QuickSort(a, start, pivot - 1);
                QuickSort(a, pivot + 1, end);
            }
        }


        static int Pivot(int[] a, int start, int end)
        {
            int pivot = a[end];
            int i = start - 1;
            for (int j = start; j < end; j++)
            {
                if (a[j] <= pivot)
                {
                    i++;
                    Swap(a, i, j);
                }
            }
            Swap(a, i + 1, end);
            return i + 1;
        }

        static void Swap(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        public static void QuickSortCC(int[] a, int left, int right)
        {
            int index = PivotCC(a, left, right);
            if (left < index - 1)
            {
                QuickSortCC(a, left, index - 1);
            }
            if (index < right)
            {
                QuickSortCC(a, index, right);
            }
        }

        static int PivotCC(int[] a, int left, int right)
        {
            int pivot = a[(left + right) / 2];
            while (left <= right)
            {
                while (a[left] < pivot)
                    left++;
                while (pivot < a[right])
                    right--;

                if (left <= right)
                {
                    Swap(a, left, right);
                    left++;
                    right--;
                }
            }
            return left;
        }

        public static void CountSort(int[] a, int n, int exp)
        {
            int[] output = new int[n];
            int[] count = new int[10];
            for (int i = 0; i < n; i++)
                count[(a[i] / exp) % 10]++;

            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(a[i] / exp) % 10] - 1] = a[i];
                count[(a[i] / exp) % 10]--;
            }

            for (int i = 0; i < n; i++)
                a[i] = output[i];
        }
    }
}
