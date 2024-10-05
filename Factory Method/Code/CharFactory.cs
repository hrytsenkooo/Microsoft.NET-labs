using laba4.Factories;
using laba4.Realization;
namespace laba4.Factories
{
    public class CharacterArrayGeneratorFactory : IDataGeneratorFactory<char>
    {
        public IDataGenerator<char> Create()
        {
            return new CharacterArrayGenerator();
        }
    }
}