using laba4.Factories;
using laba4.Realization;
namespace laba4.Factories
{
    public class DoubleArrayGeneratorFactory :
    IRangeArrayGeneratorFactory<double>
    {
        public IRangeArrayGenerator<double> Create()
        {
            return new DoubleArrayGenerator();
        }
    }
}