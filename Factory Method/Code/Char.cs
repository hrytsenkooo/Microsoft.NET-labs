using System;
namespace laba4.Realization
{
    public class CharacterArrayGenerator : IDataGenerator<char>
    {
        public char[] GenerateArray(int size)
        {
            Random random = new Random();
            char[] array = new char[size];
            for (int i = 0; i < size; i++)
            {
                // (ASCII value between 65 and 126)
                array[i] = (char)random.Next(65, 122);
            }
            return array;
        }
    }
}
