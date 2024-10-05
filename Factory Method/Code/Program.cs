using System;
namespace laba4
{
    class Program
    {
        static void Main(string[] args)
        {
            char repeat;
            do
            {
                Console.WriteLine("\nWelcome to the Random Array Generator!\n");
                Console.WriteLine("Please select the data type for the array:");
                Console.WriteLine("1. Integer");
                Console.WriteLine("2. Double");
                Console.WriteLine("3. Boolean");
                Console.WriteLine("4. Character");
                Console.Write("Enter your choice: ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 ||
                choice > 4)
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    Console.Write("Enter your choice: ");
                }
                Console.Write("\nEnter the size of the array: ");
                int size;
                while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
                {
                    Console.WriteLine("Invalid size. Please enter a positive integer.");
                    Console.Write("Enter the size of the array: ");
                }
                int minValue = 0;
                int maxValue = 100;
                if (choice == 1 || choice == 2)
                {
                    Console.Write("\nEnter the minimum value for the range: ");
                    while (!int.TryParse(Console.ReadLine(), out minValue))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                        Console.Write("Enter the minimum value for the range: ");
                    }
                    Console.Write("Enter the maximum value for the range: ");
                    while (!int.TryParse(Console.ReadLine(), out maxValue))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                        Console.Write("Enter the maximum value for the range: ");
                    }
                }
                Factories.IRangeArrayGeneratorFactory<int> intFactory = null;
                Factories.IRangeArrayGeneratorFactory<double> doubleFactory =
                null;
                Factories.IDataGeneratorFactory<bool> boolFactory = null;
                Factories.IDataGeneratorFactory<char> charFactory = null;
                switch (choice)
                {
                    case 1:
                        intFactory = new Factories.IntegerArrayGeneratorFactory();
                        break;
                    case 2:
                        doubleFactory = new Factories.DoubleArrayGeneratorFactory();
                        break;
                    case 3:
                        boolFactory = new Factories.BooleanArrayGeneratorFactory();
                        break;
                    case 4:
                        charFactory = new Factories.CharacterArrayGeneratorFactory();
                        break;
                }
                Console.WriteLine("\nGenerated array:");
                PrintGeneratedArray(intFactory, doubleFactory, boolFactory,
                charFactory, size, minValue, maxValue);
                Console.WriteLine("\nDo you want to repeat the process? \nEnter '+'
                to continue, any other key to exit.");
            repeat = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (repeat == '+');
        }
        static void PrintGeneratedArray(
        Factories.IRangeArrayGeneratorFactory<int> intFactory,
        Factories.IRangeArrayGeneratorFactory<double> doubleFactory,
        Factories.IDataGeneratorFactory<bool> boolFactory,
        Factories.IDataGeneratorFactory<char> charFactory,
        int size, int minValue, int maxValue)
        {
            if (intFactory != null)
            {
                PrintArray(intFactory.Create().GenerateArray(size, minValue,
                maxValue));
            }
            else if (doubleFactory != null)
            {
                PrintArray(doubleFactory.Create().GenerateArray(size, minValue,
                maxValue));
            }
            else if (boolFactory != null)
            {
                PrintArray(boolFactory.Create().GenerateArray(size));
            }
            else if (charFactory != null)
            {
                PrintArray(charFactory.Create().GenerateArray(size));
            }
        }
        static void PrintArray<T>(T[] array)
        {
            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                    Console.Write(", ");
            }
            Console.WriteLine("]");
        }
    }
}