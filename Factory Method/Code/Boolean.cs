using System;
namespace laba4.Realization
{
    public class BooleanArrayGenerator : IDataGenerator<bool>
    {
        public bool[] GenerateArray(int size)
        {
            Random random = new Random();
            bool[] array = new bool[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(0, 2) == 1;
            }
            return array;
        }
    }
}