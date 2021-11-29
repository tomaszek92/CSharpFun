namespace CSharpFun.RemoveEvenFromArrayBenchmark
{
    public class RemoveEvenFromArrayForeach : IRemoveEvenFromArray
    {
        public int[] RemoveEvenFromArray(int[] array)
        {
            var j = 0;
            var result = new int[array.Length];
            foreach (var item in array)
            {
                if (item % 2 == 1)
                {
                    result[j++] = item;
                }
            }

            return result[..j];
        }
    }
}