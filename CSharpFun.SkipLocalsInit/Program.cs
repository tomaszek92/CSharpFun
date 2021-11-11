using System;
using System.Runtime.CompilerServices;

namespace CSharpFun.SkipLocalsInit
{
    class Program
    {
        static void Main(string[] args)
        {
            Foo1();
            Console.WriteLine();
            Foo2();
            Console.WriteLine();
            Foo3();
        }

        [SkipLocalsInit]
        private static unsafe void Foo1()
        {
            DateTime dateTime;
            Console.WriteLine(*&dateTime);

            int i;
            Console.WriteLine(*&i);
        }

        private static unsafe void Foo2()
        {
            DateTime dateTime;
            Console.WriteLine(*&dateTime);
            
            int i;
            Console.WriteLine(*&i);
        }
        
        private static void Foo3()
        {
            Unsafe.SkipInit(out DateTime dateTime);
            Console.WriteLine(dateTime);
            
            Unsafe.SkipInit(out int i);
            Console.WriteLine(i);
        }
    }
}