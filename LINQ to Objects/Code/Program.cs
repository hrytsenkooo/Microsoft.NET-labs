using laba1;
using System;

namespace laba1
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Queries qryExecutor = new();
            ConsolePrint printer = new();
            Data dataLists = new();
            PrintAndQueriesConnector printQryCon = new(qryExecutor, printer, dataLists);
            Menu menu = new();

            menu.Items = new()
            {
                new MenuItem("1. Вивести усі машини з типом кузову SUV", 
                    printQryCon.PrintAllVehicles),
                new MenuItem("2. Вивести усі машини, що мають тип кузову SUV та відповідно їх власників", 
                    printQryCon.PrintAllVehiclesWithOwners),
                new MenuItem("3. Вивести перелік машин, що мають жахливі технічні показники", 
                    printQryCon.PrintMachinesInExcellentCondition),
                new MenuItem("4. Вивести перелік власників, вік яких входить у діапазон від 10 до 40 років", 
                    () => printQryCon.PrintOwnersWithinAgeRange(10, 40)),
                new MenuItem("5. Вивести водія, що має найдовше ім'я", 
                    printQryCon.PrintDriverWithLongestName),
                new MenuItem("6. Вивести машину, що має найстаріший рік випуску (найбільш старенька)", 
                    printQryCon.PrintVehicleWithEarliestManufactureYear),
                new MenuItem("7. Вивести відсортований перелік водіїв за датою народження в порядку зростання (діапазон з 1990 до 2000 року народження)", 
                    () => printQryCon.PrintDriversSortedByDateOfBirthAscendingWithBoundaries(1990, 2000)),
                new MenuItem("8. Вивести усі машини, що не є зареєстрованими", 
                    printQryCon.PrintUnregisteredVehicles),
                new MenuItem("9. Вивести перелік машин, випущених до 2016 року", 
                    () => printQryCon.PrintMachinesReleasedBeforeYear(2016)),
                new MenuItem("10. Вивести машини, зареєстровані в локації \"Local Registration Office\"", 
                    printQryCon.PrintAllVehiclesRegisteredInLocalOffice),
                new MenuItem("11. Вивести машини, що не мають водія", 
                    printQryCon.PrintAllVehiclesNotDrivenByDrivers),
                new MenuItem("12. Вивести перелік всіх унікальних власників машин та водіїв, об'єднавши їх імена", 
                    printQryCon.PrintUniqueOwnersAndDriversNames),
                new MenuItem("13. Вивести перелік власників, що мають декілька машин", 
                    printQryCon.PrintOwnersWithMultipleVehicles),
                new MenuItem("14. Вивести перелік машин, відсортовані за роком випуску (спадання, діапазон 2000-2017)", 
                    () => printQryCon.PrintVehiclesSortedByModelYearDescendingWithBoundaries(2000, 2017)),
                new MenuItem("15. Вивести перелік водіїв без машин", 
                    printQryCon.PrintDriversWithoutVehicles),
                new MenuItem("16. Вивести середній вік водіїв", 
                    printQryCon.PrintAverageAgeOfDrivers),
                new MenuItem("17. Вивести перелік водіїв молодше 30", 
                    () => printQryCon.PrintDriversYoungerThanAge(30)),
                new MenuItem("18. Вивести список автомобілів, що були зареєстровані у 2023 році", 
                    () => printQryCon.PrintVehiclesRegisteredInYear(2023)),
                new MenuItem("19. Вивести список водіїв, що народилися у 1990 році", 
                    () => printQryCon.PrintDriversBornInYear(1990)),
                new MenuItem("20. Вивести список автомобілів, які належать власнику з ID: 1", 
                    () => printQryCon.PrintCarsOwnedByOwner(1)),
                new MenuItem("\n21. Вихід", 
                    () => menu.IsExitWanted = true)
            };

            MenuItemSelector selector = new(1, menu.ItemsCount);

            while (!menu.IsExitWanted)
            {
                menu.PrintMenu();
                menu.ExecuteSelectedItem(selector.SelectItem());
                Console.WriteLine("\nДля продовження натисніть будь-яку клавішу");
                Console.ReadKey();
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.Clear();
            }
        }
    }
}
