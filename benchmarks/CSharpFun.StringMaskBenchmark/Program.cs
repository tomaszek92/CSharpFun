using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace CSharpFun.StringMaskBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmarks>();
        }
    }

    [MemoryDiagnoser]
    public class Benchmarks
    {
        private const string Password = "Admin1234!@";

        [Benchmark]
        public string MaskNaive()
        {
            var firstChars = Password[..3];
            var restLength = Password.Length - 3;
            for (var i = 0; i < restLength; i++)
            {
                firstChars += "*";
            }

            return firstChars;
        }

        [Benchmark]
        public string MaskStringBuilder1()
        {
            var strBuilder = new StringBuilder();
            strBuilder.Append(Password[..3]);
            var restLength = Password.Length - 3;
            for (var i = 0; i < restLength; i++)
            {
                strBuilder.Append("*");
            }

            return strBuilder.ToString();
        }
        
        [Benchmark]
        public string MaskStringBuilder2()
        {
            var strBuilder = new StringBuilder();
            strBuilder.Append(Password[..3]);
            var restLength = Password.Length - 3;
            for (var i = 0; i < restLength; i++)
            {
                strBuilder.Append('*');
            }

            return strBuilder.ToString();
        }
        
        [Benchmark]
        public string MaskStringBuilder4()
        {
            var strBuilder = new StringBuilder(Password[..3]);
            var restLength = Password.Length - 3;
            for (var i = 0; i < restLength; i++)
            {
                strBuilder.Append('*');
            }

            return strBuilder.ToString();
        }
        
        [Benchmark]
        public string MaskStringBuilder5()
        {
            var strBuilder = new StringBuilder(Password[..3], Password.Length);
            var restLength = Password.Length - 3;
            for (var i = 0; i < restLength; i++)
            {
                strBuilder.Append('*');
            }

            return strBuilder.ToString();
        }

        [Benchmark]
        public string MaskNewString1()
        {
            var firstChars = Password[..3];
            var restLength = Password.Length - 3;
            var asterisks = new string('*', restLength);

            return firstChars + asterisks;
        }
        
        [Benchmark]
        public string MaskNewString2()
        {
            var firstChars = Password[..3];
            var restLength = Password.Length - 3;
            var asterisks = new string('*', restLength);

            return $"{firstChars}{asterisks}";
        }

        [Benchmark]
        public string MaskStringCreate()
        {
            return String.Create(Password.Length, Password, (span, str) =>
            {
                str.AsSpan().CopyTo(span);
                span[3..].Fill('*');
            });
        }
    }
}