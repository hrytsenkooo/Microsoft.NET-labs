using laba2.Add;
using System;
using System.Reflection.Metadata;
using System.Xml;
using System.Xml.Linq;
namespace laba2
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            string answer = "";
            Data dataLists = new Data();
            DriverXml driverXml = new DriverXml(dataLists);
            OwnerXml ownerXml = new OwnerXml();
            RegistrationXml registrationXml = new RegistrationXml();
            VehicleDriverXml vehicleDriverXml = new VehicleDriverXml();
            VehicleOwnershipXml vehicleOwnershipXml = new
            VehicleOwnershipXml();
            VehicleXml vehicleXml = new VehicleXml();
            Driver driver;
            Owner owner;
            Registration registration;
            Vehicle vehicle;
            VehicleDriver vehicleDriver;
            VehicleOwnership vehicleOwnership;
            do
            {
                Console.Clear();
                Console.WriteLine("Головне меню \n" +
                "\n1. Створити новий XML-файл Driver.xml" +
                "\n2. Створити новий XML-файл Owner.xml" +
                "\n3. Створити новий XML-файл Registration.xml" +
                "\n4. Створити новий XML-файл VehicleDriver.xml" +
                "\n5. Створити новий XML-файл VehicleOwnership.xml" +
                "\n6. Створити новий XML-файл Vehicle.xml" +
                "\n7. Додати новий об'єкт Driver до XML документу" +
                "\n8. Додати новий об'єкт Owner до XML документу" +
                "\n9. Додати новий об'єкт Registration до XML документу" +
                "\n10. Додати новий об'єкт VehicleDriver до XML документу" +
                "\n11. Додати новий об'єкт VehicleOwnership до XML документу" +
                "\n12. Додати новий об'єкт Vehicle до XML документу" +
                "\n13. Вивести список об'єктiв Driver з XML файлу" +
                "\n14. Вивести список об'єктiв Owner з XML файлу" +
                "\n15. Вивести список об'єктiв Registration з XML файлу" +
                "\n16. Вивести список об'єктiв VehicleDriver з XML файлу" +
                "\n17. Вивести список об'єктiв VehicleOwnership з XML файлу"
                +
                "\n18. Вивести список об'єктiв Vehicle з XML файлу" +
                "\n19. Запити над даними ");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        driver = Driver.CreateDriver();
                        driverXml.CreateDoc(driver);
                        break;
                    case 2:
                        Console.Clear();
                        owner = Owner.CreateOwner();
                        ownerXml.CreateDoc(owner);
                        break;
                    case 3:
                        Console.Clear();
                        registration = Registration.CreateRegistration();
                        registrationXml.CreateDoc(registration);
                        break;
                    case 4:
                        Console.Clear();
                        vehicleDriver = VehicleDriver.CreateVehicleDriver();
                        vehicleDriverXml.CreateDoc(vehicleDriver);
                        break;
                    case 5:
                        Console.Clear();
                        vehicleOwnership =
                        VehicleOwnership.CreateVehicleOwnership();
                        vehicleOwnershipXml.CreateDoc(vehicleOwnership);
                        break;
                    case 6:
                        Console.Clear();
                        vehicle = Vehicle.CreateVehicle();
                        vehicleXml.CreateDoc(vehicle);
                        break;
                    case 7:
                        Console.Clear();
                        driver = Driver.CreateDriver();
                        driverXml.AddElem(driver);
                        break;
                    case 8:
                        Console.Clear();
                        owner = Owner.CreateOwner();
                        ownerXml.AddElem(owner);
                        break;
                    case 9:
                        Console.Clear();
                        registration = Registration.CreateRegistration();
                        registrationXml.AddElem(registration);
                        break;
                    case 10:
                        Console.Clear();
                        vehicleDriver = VehicleDriver.CreateVehicleDriver();
                        vehicleDriverXml.AddElem(vehicleDriver);
                        break;
                    case 11:
                        Console.Clear();
                        vehicleOwnership =
                        VehicleOwnership.CreateVehicleOwnership();
                        vehicleOwnershipXml.AddElem(vehicleOwnership);
                        break;
                    case 12:
                        Console.Clear();
                        vehicle = Vehicle.CreateVehicle();
                        vehicleXml.addElem(vehicle);
                        break;
                    case 13:
                        Console.Clear();
                        DisplayDataChoice("driver", () => driverXml.ReturnAll(), () =>
                        driverXml.ReadXml());
                        break;
                    case 14:
                        Console.Clear();
                        DisplayDataChoice("owner", () => ownerXml.ReturnAll(), () =>
                        ownerXml.ReadXml());
                        break;
                    case 15:
                        Console.Clear();
                        DisplayDataChoice("registration", () =>
                        registrationXml.ReturnAll(), () => registrationXml.ReadXml());
                        break;
                    case 16:
                        Console.Clear();
                        DisplayDataChoice("vehicleDriver", () =>
                        vehicleDriverXml.ReturnAll(), () => vehicleDriverXml.ReadXml());
                        break;
                    case 17:
                        Console.Clear();
                        DisplayDataChoice("vehicleOwnership", () =>
                        vehicleOwnershipXml.ReturnAll(), () => vehicleOwnershipXml.ReadXml());
                        break;
                    case 18:
                        Console.Clear();
                        DisplayDataChoice("vehicle", () => vehicleXml.returnAll(), ()
                        => vehicleXml.ReadXml());
                        break;
                }
                Queries queries = new Queries();
                if (input == 19)
                {
                    Console.Clear();
                    Console.WriteLine("Оберiть запит який хочете виконати: \n" +
                    "\n1. Вивести усі машини з типом кузову SUV" +
                    "\n2. Вивести усі машини, що мають тип кузову SUV та відповідно їх власників" +
                    "\n3. Вивести перелік машин, що мають відмінні технічні показники" +
                    "\n4. Вивести перелік власників, вік яких входить у діапазон від 10 до 40 років" +
                    "\n5. Вивести водія, що має найдовше ім'я" +
                    "\n6. Вивести машину, що має найстаріший рік випуску (найбільш старенька)" +
                    "\n7. Вивести відсортований перелік водіїв за датою народження в порядку зростання(діапазон з 1990 до 2000 року народження)" +
                    "\n8. Вивести усі машини, що не є зареєстрованими" +
                    "\n9. Вивести перелік машин, випущених до 2016 року" +
                    "\n10. Вивести машини, зареєстрованих в локації \"Local Registration Office\"" +
                    "\n11. Вивести машини, що не мають водія" +
                    "\n12. Вивести перелік всіх унікальних власників машин та водіїв, об'єднавши їх імена" +
                    "\n13. Вивести перелік власників, що мають декілька машин" +
                    "\n14. Вивести перелік машин, відсортовані за роком випуску(спадання, діапазон 2000 - 2017)" +
                    "\n15. Вивести перелік водіїв без машин" +
                    "\n16. Вивести середній вік водіїв" +
                    "\n17. Вивести перелік водіїв молодше 30" +
                    "\n18. Вивести список автомобілів, що були зареєстровані у 2023 році" +
                    "\n19. Вивести список водіїв, що народилися у 1990 році" +
                    "\n20. Вивести список автомобілів, які належать власнику з ID: 1");
                    int inputQuery = Convert.ToInt32(Console.ReadLine());
                    switch (inputQuery)
                    {
                        case 1:
                            Console.Clear();
                            queries.GetSUVVehicles();
                            break;
                        case 2:
                            Console.Clear();
                            queries.GetAllSUVsWithOwners();
                            break;
                        case 3:
                            Console.Clear();
                            queries.GetMachinesInExcellentCondition();
                            break;
                        case 4:
                            Console.Clear();
                            queries.GetOwnersWithinAgeRange(10, 40);
                            break;
                        case 5:
                            Console.Clear();
                            queries.GetDriverWithLongestName(dataLists.Drivers);
                            break;
                        case 6:
                            Console.Clear();
                            queries.GetVehicleWithEarliestManufactureYear(dataLists.Vehicles);
                            break;
                        case 7:
                            Console.Clear();
                            queries.SortDriversByDateOfBirthAscendingWithBoundaries(dataLists.Drivers,
                            1990, 2000);
                            break;
                        case 8:
                            Console.Clear();
                            queries.GetUnregisteredVehicles(dataLists.Vehicles,
                            dataLists.Registrations);
                            break;
                        case 9:
                            Console.Clear();
                            queries.GetMachinesReleasedBeforeYear(dataLists.Vehicles,
                            2016);
                            break;
                        case 10:
                            Console.Clear();
                            queries.GetVehiclesRegisteredInLocalOffice(dataLists.Vehicles,
                            dataLists.Registrations);
                            break;
                        case 11:
                            Console.Clear();
                            queries.GetVehiclesNotDrivenByDrivers(dataLists.Vehicles,
                            dataLists.Drivers, dataLists.VehicleDrivers);
                            break;
                        case 12:
                            Console.Clear();
                            queries.GetUniqueOwnersAndDriversNames(dataLists.Owners,
                            dataLists.Drivers);
                            break;
                        case 13:
                            Console.Clear();
                            queries.GetOwnersWithMultipleVehicles(dataLists.Owners,
                            dataLists.VehicleOwnerships);
                            break;
                        case 14:
                            Console.Clear();
                            queries.SortVehiclesByModelYearDescendingWithBoundaries(dataLists.Vehicle
                            s, 2000, 2017);
                            break;
                        case 15:
                            Console.Clear();
                            queries.FindDriversWithoutVehicles(dataLists.Drivers,
                            dataLists.VehicleDrivers);
                            break;
                        case 16:
                            Console.Clear();
                            queries.GetAverageAgeOfDrivers(dataLists.Drivers);
                            break;
                        case 17:
                            Console.Clear();
                            queries.GetDriversYoungerThanAge(dataLists.Drivers, 30);
                            break;
                        case 18:
                            Console.Clear();
                            queries.GetVehiclesRegisteredInYear(dataLists.Vehicles,
                            dataLists.Registrations, 2023);
                            break;
                        case 19:
                            Console.Clear();
                            queries.GetDriversBornInYear(dataLists.Drivers, 1990);
                            break;
                        case 20:
                            Console.Clear();
                            queries.GetCarsOwnedByOwner(dataLists.Vehicles,
                            dataLists.Owners, dataLists.VehicleOwnerships, 1);
                            break;
                    }
                }
                Console.WriteLine("Натисніть Enter для продовження");
                answer = Console.ReadLine();
            }
            while (answer == "+");
        }
        public static void DisplayDataChoice(string dataType, Action
        usingXmlDocument, Action usingXmlSerializer)
        {
            Console.Clear();
            Console.WriteLine($"Оберіть спосіб відображення {dataType}
            даних: ");
            Console.WriteLine("1. Використовуючи XmlDocument");
            Console.WriteLine("2. Використовуючи XmlSerializer");
            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    usingXmlDocument(); // XmlDocument
                    break;
                case "2":
                    usingXmlSerializer(); // XmlSerializer
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    break;
            }
        }
    }
}