using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Nodes;
namespace laba3.Methods
{
    public class VehicleJson
    {
        private readonly string _path =
        "C:\\Users\\User\\source\\repos\\laba3\\laba3\\JSON\\Vehicle.json";
        public void AddVehicleSerializer(List<Vehicle> vehicles)
        {
            try
            {
                if (File.Exists(_path))
                {
                    string json = File.ReadAllText(_path);
                    if (!string.IsNullOrEmpty(json))
                    {
                        File.WriteAllText(_path, string.Empty);
                    }
                    JsonSerializerOptions options = new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true,
                        DefaultIgnoreCondition =
                    JsonIgnoreCondition.WhenWritingNull
                    };
                    using (FileStream fs = new FileStream(_path,
                    FileMode.OpenOrCreate))
                    {
                        JsonSerializer.Serialize(fs, vehicles, options);
                        Console.WriteLine("Дані записано!");
                    }
                }
                else
                {
                    Console.WriteLine("Файл не існує");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
        public void GetVehicleDeserializer()
        {
            try
            {
                using (FileStream fs = new FileStream(_path,
                FileMode.OpenOrCreate))
                {
                    List<Vehicle>? vehicles =
                    JsonSerializer.Deserialize<List<Vehicle>>(fs);
                    if (vehicles != null)
                    {
                        foreach (var vehicle in vehicles)
                        {
                            Console.WriteLine($"VehicleId: {vehicle.VehicleId}");
                            Console.WriteLine($"Brand: {vehicle.Brand}");
                            Console.WriteLine($"Manufacturer: { vehicle.Manufacturer}");
                            Console.WriteLine($"Model: {vehicle.Model}");
                            Console.WriteLine($"BodyType: {vehicle.BodyType}");
                            Console.WriteLine($"YearOfManufacture: { vehicle.YearOfManufacture}");
                            Console.WriteLine($"ChassisNumber: { vehicle.ChassisNumber}");
                            Console.WriteLine($"Color: {vehicle.Color}");
                            Console.WriteLine($"LicensePlate: {vehicle.LicensePlate}");
                            Console.WriteLine($"TechnicalCondition: { vehicle.TechnicalCondition}");
                        if (vehicle.Registrations != null)
                            {
                                Console.WriteLine("Registrations:");
                                foreach (var registration in vehicle.Registrations)
                                {
                                    Console.WriteLine($"RegistrationDate: { registration.RegistrationDate}");
                                    Console.WriteLine($"RegistrationLocation: { registration.RegistrationLocation}");
                                    Console.WriteLine($"IsRegistered: { registration.IsRegistered}");
                                }
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Файл пустий.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
        public void GetVehicleJson()
        {
            try
            {
                string jsonString = File.ReadAllText(_path);
                if (!string.IsNullOrEmpty(jsonString))
                {
                    List<Vehicle> vehicles = new List<Vehicle>();
                    using (JsonDocument document =
                    JsonDocument.Parse(jsonString))
                    {
                        JsonElement root = document.RootElement;
                        if (root.ValueKind == JsonValueKind.Array)
                        {
                            foreach (JsonElement vehicleElement in
                            root.EnumerateArray())
                            {
                                Vehicle vehicle = new Vehicle(
                                vehicleElement.GetProperty("VehicleId").GetInt32(),
                                vehicleElement.GetProperty("Brand").GetString(),
                                vehicleElement.GetProperty("Manufacturer").GetString(),
                                vehicleElement.GetProperty("Model").GetString(),
                                vehicleElement.GetProperty("BodyType").GetString(),
                                vehicleElement.GetProperty("YearOfManufacture").GetInt32(),
                                vehicleElement.GetProperty("ChassisNumber").GetString(),
                                vehicleElement.GetProperty("Color").GetString(),
                                vehicleElement.GetProperty("LicensePlate").GetString(),
                                vehicleElement.GetProperty("TechnicalCondition").GetString());
                                // Parse Registrations if present
                                if (vehicleElement.TryGetProperty("Registrations", out
                                JsonElement registrationsElement))
                                {
                                    List<Registration> registrations = new
                                    List<Registration>();
                                    foreach (JsonElement registrationElement in
                                    registrationsElement.EnumerateArray())
                                    {
                                        Registration registration = new Registration(
                                        registrationElement.GetProperty("VehicleId").GetInt32(),
                                        registrationElement.GetProperty("OwnerId").GetInt32(),
                                        registrationElement.GetProperty("RegistrationDate").GetDateTime(),
                                        registrationElement.GetProperty("RegistrationLocation").GetString(),
                                        registrationElement.GetProperty("IsRegistered").GetBoolean());
                                        registrations.Add(registration);
                                    }
                                    vehicle.Registrations = registrations;
                                }
                                vehicles.Add(vehicle);
                            }
                        }
                    }
                    foreach (var vehicle in vehicles)
                    {
                        Console.WriteLine($"Vehicle ID: {vehicle.VehicleId}, Brand:
                    { vehicle.Brand}, " +
                    $"Manufacturer: {vehicle.Manufacturer}, Model:
                    { vehicle.Model}, " +
                    $"Body Type: {vehicle.BodyType}, Year of Manufacture:
                    { vehicle.YearOfManufacture}, " +
                    $"Chassis Number: {vehicle.ChassisNumber}, Color:
                    { vehicle.Color}, " +
                    $"License Plate: {vehicle.LicensePlate}, Technical Condition:
                    { vehicle.TechnicalCondition}
                        ");
                    // Print Registrations if present
                    if (vehicle.Registrations != null && vehicle.Registrations.Any())
                        {
                            Console.WriteLine("Registrations:");
                            foreach (var registration in vehicle.Registrations)
                            {
                                Console.WriteLine($" Vehicle ID:
                            { registration.VehicleId}, Owner ID: { registration.OwnerId}, " +
                            $"Registration Date: {registration.RegistrationDate}, " +
                            $"Registration Location:
                            { registration.RegistrationLocation}, " +
                            $"Is Registered: {registration.IsRegistered}");
                            }
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Файл пустий");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
        public void GetVehicleJsonNode()
        {
            try
            {
                string jsonString = File.ReadAllText(_path);
                if (!string.IsNullOrEmpty(jsonString))
                {
                    JsonNode? rootNode = JsonNode.Parse(jsonString);
                    if (rootNode is JsonArray rootArray)
                    {
                        foreach (var node in rootArray)
                        {
                            int vehicleId = int.Parse(node["VehicleId"].ToString());
                            string brand = node["Brand"].ToString();
                            string manufacturer = node["Manufacturer"].ToString();
                            string model = node["Model"].ToString();
                            string bodyType = node["BodyType"].ToString();
                            int yearOfManufacture =
                            int.Parse(node["YearOfManufacture"].ToString());
                            string chassisNumber = node["ChassisNumber"].ToString();
                            string color = node["Color"].ToString();
                            string licensePlate = node["LicensePlate"].ToString();
                            string technicalCondition = node["TechnicalCondition"].ToString();
                            Console.WriteLine($"Vehicle ID: {vehicleId}, Brand: { brand}, " + $"Manufacturer: {manufacturer}, Model: {model}, " +
                            $"Body Type: {bodyType}, Year of Manufacture: { yearOfManufacture}, " + $"Chassis Number: {chassisNumber}, Color: {color}, " +
                            $"License Plate: {licensePlate}, Technical Condition: { technicalCondition}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Кореневий вузол не є масивом");
                    }
                }
                else
                {
                    Console.WriteLine("Файл пустий");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}
