using System;
namespace laba4.Realization
{
    public class DoubleArrayGenerator : IRangeArrayGenerator<double>
    {
        public double[] GenerateArray(int size, double minValue, double
        maxValue)
        {
            Random random = new Random();
            double[] array = new double[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = minValue + (random.NextDouble() * (maxValue -
                minValue));
            }
            return array;
        }
    }
}