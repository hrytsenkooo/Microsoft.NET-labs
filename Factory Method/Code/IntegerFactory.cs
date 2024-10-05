using laba4.Realization;
namespace laba4.Factories
{
    public class IntegerArrayGeneratorFactory :
    IRangeArrayGeneratorFactory<int>
    {
        public IRangeArrayGenerator<int> Create()
        {
            return new IntegerArrayGenerator();
        }
    }
}