using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace CSharpFun.RemoveEvenFromArrayBenchmark
{
    class Program
    {
        static void Main(string[] args) => BenchmarkRunner.Run<Benchmarks>();
    }

    [MemoryDiagnoser]
    public class Benchmarks
    {
        private readonly RemoveEvenFromArrayFor _for = new();
        private readonly RemoveEvenFromArrayLinq _linq = new();
        private readonly RemoveEvenFromArraySpan _span = new();
        private readonly RemoveEvenFromArrayForeach _foreach = new();

        private int[] _array = null!;
        
        [GlobalSetup]
        public void GlobalSetup()
        {
            var rand = new Random();
            _array = new int[10000];
            for (var i = 0; i < _array.Length; i++)
            {
                _array[i] = rand.Next();
            }
        }
        
        [Benchmark]
        public void For()
        {
            _for.RemoveEvenFromArray(_array);
        }
        
        [Benchmark]
        public void Foreach()
        {
            _foreach.RemoveEvenFromArray(_array);
        }

        [Benchmark]
        public void Linq()
        {
            _linq.RemoveEvenFromArray(_array);
        }

        [Benchmark]
        public void Span()
        {
            _span.RemoveEvenFromArray(_array);
        }
    }
}