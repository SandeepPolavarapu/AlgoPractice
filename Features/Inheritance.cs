using System;

namespace Features
{
    class Inheritance
    {
        public static void Run()
        {
            B b = new D();
            b.BaseMethod();
            b.BaseMethod1();

            D d = new D();
            d.BaseMethod();
            d.BaseMethod1();
            d.DerivedMethod();
        }
    }

    class B
    {
        public void BaseMethod()
        {
            Console.WriteLine("Base Method");
        }

        public virtual void BaseMethod1()
        {
            Console.WriteLine("Base Method1");
        }
    }

    class D : B
    {
        public void BaseMethod()
        {
            Console.WriteLine("Base Method in Derived Class");
        }
        public override void BaseMethod1()
        {
            Console.WriteLine("Base Method1 in Derived Class");
        }

        public void DerivedMethod()
        {
            Console.WriteLine("Derived Method");
        }
    }
}
