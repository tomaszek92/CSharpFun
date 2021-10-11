using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace CSharpFun.ParamsBenchmark
{
    class Program
    {
        static void Main(string[] args) => BenchmarkRunner.Run<Benchmarks>();
    }
    
    [MemoryDiagnoser]
    public class Benchmarks
    {
        [Benchmark]
        public int _10Params() => SumParams(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            
        [Benchmark]
        public int _10ParamsArray() => SumParams(new [] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10});

        [Benchmark]
        public int _10IEnumerableArray() => SumIEnumerable(new [] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10});

        [Benchmark]
        public int _10IEnumerableList() => SumIEnumerable(new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10});

        [Benchmark]
        public int EmptyParams() => SumParams();
            
        [Benchmark]
        public int EmptyParamsArray() => SumParams(Array.Empty<int>());
        
        [Benchmark]
        public int EmptyIEnumerableArray1() => SumIEnumerable(Array.Empty<int>());
        
        [Benchmark]
        public int EmptyIEnumerableArray2() => SumIEnumerable(new int[0]);
        
        [Benchmark]
        public int EmptyIEnumerableList() => SumIEnumerable(new List<int>());
            
        private static int SumParams(params int[] numbers) => numbers.Sum();

        private static int SumIEnumerable(IEnumerable<int> numbers) => numbers.Sum();
    }
}