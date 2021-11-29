using System;

namespace CSharpFun.RemoveEvenFromArrayBenchmark
{
    public class RemoveEvenFromArraySpan : IRemoveEvenFromArray
    {
        public int[] RemoveEvenFromArray(int[] array)
        {
            var input = array.AsSpan();
            Span<int> output = stackalloc int[array.Length];
            var j = 0;
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 == 1)
                {
                    output[j++] = input[i];
                }
            }

            output = output[..j];

            return output.ToArray();
        }
    }
}