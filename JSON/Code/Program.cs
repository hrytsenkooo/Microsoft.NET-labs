using laba3.Methods;
namespace laba3
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            string answer = "";
            var data = new Data();
            var driverJson = new DriverJson();
            var ownerJson = new OwnerJson();
            var registrationJson = new RegistrationJson();
            var vehicleJson = new VehicleJson();
            var vehicleDriverJson = new VehicleDriverJson();
            var vehicleOwnershipJson = new VehicleOwnershipJson();
            int input;
            do
            {
                Console.Clear();
                Console.WriteLine("Головне меню \n" +
                "\n1. Серіалізація списку об'єктів Driver" +
                "\n2. Десеріалізація списку об'єктів Driver" +
                "\n3. Отримати список об'єктів Driver за домогою JsonDocument" +
                "\n4. Отримати список об'єктів Driver за допомогою JsonNode" +
                "\n5. Серіалізація списку об'єктів Owner" +
                "\n6. Десеріалізація списку об'єктів Owner" +
                "\n7. Отримати список об'єктів Owner за допомогою JsonDocument" +
                "\n8. Отримати список об'єктів Owner за допомогою JsonNode" +
                "\n9. Серіалізація списку об'єктів Registration" +
                "\n10. Десеріалізація списку об'єктів Registration" +
                "\n11. Отримати список об'єктів Registration за допомогою JsonDocument" +
                "\n12. Отримати список об'єктів Registration за допомогою JsonNode" +
                "\n13. Серіалізація списку об'єктів Vehicle" +
                "\n14. Десеріалізація списку об'єктів Vehicle" +
                "\n15. Отримати список об'єктів Vehicle за допомогою JsonDocument" +
                "\n16. Отримати список об'єктів за допомогою Vehicle JsonNode" +
                "\n17. Серіалізація списоку об'єктів VehicleDriver" +
                "\n18. Десеріалізація списку об'єктів VehicleDriver" +
                "\n19. Отримати список об'єктів VehicleDriver за допомогою JsonDocument" +
                "\n20. Отримати список об'єктів VehicleDriver за допомогою JsonNode" +
                "\n21. Серіалізація списку об'єктів VehicleOwnership" +
                "\n22. Десеріалізація списку об'єктів VehicleOwnership" +
                "\n23. Отримати список об'єктів VehicleOwnership за допомогою JsonDocument" +
                "\n24. Отримати список об'єктів VehicleOwnership за допомогою JsonNode" +
                "\n\nВаш вибір:");
                input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        driverJson.AddDriverSerializer(data.Drivers);
                        break;
                    case 2:
                        Console.Clear();
                        driverJson.GetDriverDeserializer();
                        break;
                    case 3:
                        Console.Clear();
                        driverJson.GetDriverJson();
                        break;
                    case 4:
                        Console.Clear();
                        driverJson.GetDriverJsonNode();
                        break;
                    case 5:
                        Console.Clear();
                        ownerJson.AddOwnerSerializer(data.Owners);
                        break;
                    case 6:
                        Console.Clear();
                        ownerJson.GetOwnerDeserializer();
                        break;
                    case 7:
                        Console.Clear();
                        ownerJson.GetOwnerJson();
                        break;
                    case 8:
                        Console.Clear();
                        ownerJson.GetOwnerJsonNode();
                        break;
                    case 9:
                        Console.Clear();
                        registrationJson.AddRegistrationSerializer(data.Registrations);
                        break;
                    case 10:
                        Console.Clear();
                        registrationJson.GetRegistrationDeserializer();
                        break;
                    case 11:
                        Console.Clear();
                        registrationJson.GetRegistrationJson();
                        break;
                    case 12:
                        Console.Clear();
                        registrationJson.GetRegistrationJsonNode();
                        break;
                    case 13:
                        Console.Clear();
                        vehicleJson.AddVehicleSerializer(data.Vehicles);
                        break;
                    case 14:
                        Console.Clear();
                        vehicleJson.GetVehicleDeserializer();
                        break;
                    case 15:
                        Console.Clear();
                        vehicleJson.GetVehicleJson();
                        break;
                    case 16:
                        Console.Clear();
                        vehicleJson.GetVehicleJsonNode();
                        break;
                    case 17:
                        Console.Clear();
                        vehicleDriverJson.AddVehicleDriverSerializer(data.VehicleDrivers);
                        break;
                    case 18:
                        Console.Clear();
                        vehicleDriverJson.GetVehicleDriverDeserializer();
                        break;
                    case 19:
                        Console.Clear();
                        vehicleDriverJson.GetVehicleDriverJson();
                        break;
                    case 20:
                        Console.Clear();
                        vehicleDriverJson.GetVehicleDriverJsonNode();
                        break;
                    case 21:
                        Console.Clear();
                        vehicleOwnershipJson.AddVehicleOwnershipSerializer(data.VehicleOwnership
                        s);
                        break;
                    case 22:
                        Console.Clear();
                        vehicleOwnershipJson.GetVehicleOwnershipDeserializer();
                        break;
                    case 23:
                        Console.Clear();
                        vehicleOwnershipJson.GetVehicleOwnershipJson();
                        break;
                    case 24:
                        Console.Clear();
                        vehicleOwnershipJson.GetVehicleOwnershipJsonNode();
                        break;
                    default:
                        Console.WriteLine("Неправильний вибір");
                        break;
                }
                Console.WriteLine("Натисніть + для продовження");
                answer = Console.ReadLine();
            } while (answer == "+");
        }
    }
}