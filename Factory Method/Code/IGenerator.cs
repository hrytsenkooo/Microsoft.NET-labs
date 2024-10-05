namespace laba4.Realization
{
    // with a range parameter
    public interface IRangeArrayGenerator<T>
    {
        T[] GenerateArray(int size, T minValue, T maxValue);
    }
    // with a single size parameter
    public interface IDataGenerator<T>
    {
        T[] GenerateArray(int size);
    }
}