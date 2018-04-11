using System;

namespace Features
{
    class Delegate
    {

        private int inta;
        public delegate int ReturnInt(int a);
        public Action<int> SetInteger;
        public Func<int, int> GetInteger;
        Converter<int, string> ConvertorPointer;
        Comparison<int> ComparisonPointer;

        public int ReturnIntMethod(int a)
        {
            return a;
        }

        public void SetIntegerMethod(int a)
        {
            inta = a;
        }

        public int GetIntegerMethod(int a)
        {
            return inta * a;
        }

        public string ConvertIntToStringMethod(int a)
        {
            return a.ToString();
        }
        public int CompareIntMethod(int a, int b)
        {
            return a.CompareTo(b);
        }

        public event EventHandler MyEvent
        {
            add
            {
                Console.WriteLine("add operation");
            }

            remove
            {
                Console.WriteLine("remove operation");
            }
        }

        public void DoNothing(object sender, EventArgs e)
        {
        }

        public Delegate()
        {
            ReturnInt d1 = new ReturnInt(ReturnIntMethod);
            Console.WriteLine(d1.Invoke(10));

            SetInteger = SetIntegerMethod;
            SetInteger.Invoke(1);

            GetInteger = GetIntegerMethod;
            Console.WriteLine(GetInteger.Invoke(2));

            ConvertorPointer = ConvertIntToStringMethod;
            Console.WriteLine(ConvertorPointer.Invoke(3));

            ComparisonPointer = new Comparison<int>(CompareIntMethod);
            int[] arr = new int[] { 1, 23, 5 };
            Array.Sort(arr, ComparisonPointer);

            Console.WriteLine("{0}", string.Join(", ", arr));
            //arr.ToList().ForEach(Console.WriteLine);

            MyEvent += new EventHandler(DoNothing);
            MyEvent -= null;

        }

    }
}
