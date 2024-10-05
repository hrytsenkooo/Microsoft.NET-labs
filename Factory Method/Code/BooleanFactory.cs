using laba4.Factories;
using laba4.Realization;
namespace laba4.Factories
{
    public class BooleanArrayGeneratorFactory : IDataGeneratorFactory<bool>
    {
        public IDataGenerator<bool> Create()
        {
            return new BooleanArrayGenerator();
        }
    }
}
