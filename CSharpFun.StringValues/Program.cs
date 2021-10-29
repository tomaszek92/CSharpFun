using System;

namespace CSharpFun.StringValues
{
    class Program
    {
        static void Main(string[] args)
        {
            var empty = new Microsoft.Extensions.Primitives.StringValues();
            var single = new Microsoft.Extensions.Primitives.StringValues("lorem");
            var multiple = new Microsoft.Extensions.Primitives.StringValues(new[] { "ipsum", "dolor", "sit", "amet" });

            Console.WriteLine(nameof(empty));
            Display(empty);
            
            Console.WriteLine();
            
            Console.WriteLine(nameof(single));
            Display(single);
            
            Console.WriteLine();
            
            Console.WriteLine(nameof(multiple));
            Display(multiple);
        }

        private static void Display(Microsoft.Extensions.Primitives.StringValues strV)
        {
            Console.WriteLine(strV);
            Console.WriteLine(strV.Count);
            Console.WriteLine(strV.ToString());
        }
    }
}