using laba4.Realization;
namespace laba4.Factories
{
    public interface IRangeArrayGeneratorFactory<T>
    {
        IRangeArrayGenerator<T> Create();
    }
    // without specifying a range
    public interface IDataGeneratorFactory<T>
    {
        IDataGenerator<T> Create();
    }
}