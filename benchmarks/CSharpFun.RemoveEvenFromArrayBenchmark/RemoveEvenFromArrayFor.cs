namespace CSharpFun.RemoveEvenFromArrayBenchmark
{
    public class RemoveEvenFromArrayFor : IRemoveEvenFromArray
    {
        public int[] RemoveEvenFromArray(int[] array)
        {
            var j = 0;
            var result = new int[array.Length];
            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 1)
                {
                    result[j++] = array[i];
                }
            }

            return result[..j];
        }
    }
}