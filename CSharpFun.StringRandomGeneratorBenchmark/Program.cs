using System;
using System.Buffers;
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
            var stringBuilder = new StringBuilder(Length);
        
            for (var i = 0; i < Length; i++)
            {
                stringBuilder.Append(AllowedChars[_random.Next(AllowedChars.Length)]);
            }
        
            return stringBuilder.ToString();
        }
        
        [Benchmark]
        public string StringBuilderArrayRandomNumberGenerator()
        {
            var stringBuilder = new StringBuilder(Length);
        
            var bytes = new byte[Length];
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(bytes);
            }
            for (var i = 0; i < Length; i++)
            {
                stringBuilder.Append(AllowedChars[bytes[i] % AllowedChars.Length]);
            }
            
            return stringBuilder.ToString();
        }

        [Benchmark]
        public string StringBuilderArrayPoolRandomNumberGenerator()
        {
            var stringBuilder = new StringBuilder(Length);
        
            var bytes = ArrayPool<byte>.Shared.Rent(Length);
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(bytes);
            }
            for (var i = 0; i < Length; i++)
            {
                stringBuilder.Append(AllowedChars[bytes[i] % AllowedChars.Length]);
            }
            ArrayPool<byte>.Shared.Return(bytes);
            
            return stringBuilder.ToString();
        }
        
        [Benchmark]
        public string StringBuilderStackallockRandomNumberGenerator()
        {
            var stringBuilder = new StringBuilder(Length);
        
            Span<byte> bytes = stackalloc byte[Length];
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(bytes);
            }
            for (var i = 0; i < Length; i++)
            {
                stringBuilder.Append(AllowedChars[bytes[i] % AllowedChars.Length]);
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
        public string SpanArrayRandomNumberGenerator()
        {
            return String.Create(Length, String.Empty, (span, _) =>
            {
                var bytes = new byte[Length];
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
        
        [Benchmark]
        public string SpanArrayPoolRandomNumberGenerator()
        {
            return String.Create(Length, String.Empty, (span, _) =>
            {
                var bytes = ArrayPool<byte>.Shared.Rent(Length);
                using (var crypto = RandomNumberGenerator.Create())
                {
                    crypto.GetBytes(bytes);
                }
                for (var i = 0; i < Length; i++)
                {
                    span[i] = AllowedChars[bytes[i] % AllowedChars.Length];
                }
                ArrayPool<byte>.Shared.Return(bytes);
            });
        }
        
        [Benchmark]
        public string SpanStackallockRandomNumberGenerator()
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