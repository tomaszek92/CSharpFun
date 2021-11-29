using System.Linq;

namespace CSharpFun.RemoveEvenFromArrayBenchmark
{
    public class RemoveEvenFromArrayLinq : IRemoveEvenFromArray
    {
        public int[] RemoveEvenFromArray(int[] array)
        {
            return array.Where(x => x % 2 == 1).ToArray();
        }
    }
}