using System;
namespace laba4.Realization
{
    public class IntegerArrayGenerator : IRangeArrayGenerator<int>
    {
        public int[] GenerateArray(int size, int minValue, int maxValue)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(minValue, maxValue + 1);
            }
            return array;
        }
    }
}