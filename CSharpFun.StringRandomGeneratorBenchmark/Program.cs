using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace CSharpFun.StringRandomGeneratorBenchmark
{
    class Program
    {
        static void Main(string[] args) => BenchmarkRunner.Run<Benchmarks>();
    }

    [MemoryDiagnoser]
    public class Benchmarks
    {
        private readonly Random _random = new();
        private const string AllowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        [Params(8, 16, 1024)] public int Length { get; set; }

        [Benchmark(Baseline = true)]
        public string StringConcatenation()
        {
            var result = String.Empty;
        
            for (var i = 0; i < Length; i++)
            {
                result += AllowedChars[_random.Next(AllowedChars.Length)];
            }
        
            return result;
        }
        
        [Benchmark]
        public string Linq()
        {
            return new string(
                Enumerable
                    .Range(1, Length)
                    .Select(_ => AllowedChars[_random.Next(AllowedChars.Length)])
                    .ToArray());
        }
        
        [Benchmark]
        public string StringBuilder()
        {
            var stringBuilder = new StringBuilder();
        
            for (var i = 0; i < Length; i++)
            {
                stringBuilder.Append(AllowedChars[_random.Next(AllowedChars.Length)]);
            }
        
            return stringBuilder.ToString();
        }

        [Benchmark]
        public string SpanRandom()
        {
            return String.Create(Length, String.Empty, (span, _) =>
            {
                for (var i = 0; i < Length; i++)
                {
                    span[i] = AllowedChars[_random.Next(AllowedChars.Length)];
                }
            });
        }

        [Benchmark]
        public string SpanRandomNumberGenerator()
        {
            return String.Create(Length, String.Empty, (span, _) =>
            {
                Span<byte> bytes = stackalloc byte[Length];
                using (var crypto = RandomNumberGenerator.Create())
                {
                    crypto.GetBytes(bytes);
                }
                for (var i = 0; i < Length; i++)
                {
                    span[i] = AllowedChars[bytes[i] % AllowedChars.Length];
                }
            });
        }
    }
}