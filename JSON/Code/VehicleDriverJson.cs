using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Nodes;
namespace laba3.Methods
{
    public class VehicleDriverJson
    {
        private readonly string _path =
        "C:\\Users\\User\\source\\repos\\laba3\\laba3\\JSON\\VehicleDriver.json";
        public void AddVehicleDriverSerializer(List<VehicleDriver>
        vehicleDrivers)
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
                        JsonSerializer.Serialize(fs, vehicleDrivers, options);
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
        public void GetVehicleDriverDeserializer()
        {
            try
            {
                using (FileStream fs = new FileStream(_path,
                FileMode.OpenOrCreate))
                {
                    List<VehicleDriver>? vehicleDrivers =
                    JsonSerializer.Deserialize<List<VehicleDriver>>(fs);
                    if (vehicleDrivers != null)
                    {
                        foreach (var vehicleDriver in vehicleDrivers)
                        {
                            Console.WriteLine($"VehicleId: {vehicleDriver.VehicleId}");
                            Console.WriteLine($"DriverId: {vehicleDriver.DriverId}");
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
        public void GetVehicleDriverJson()
        {
            try
            {
                string jsonString = File.ReadAllText(_path);
                if (!string.IsNullOrEmpty(jsonString))
                {
                    List<VehicleDriver> vehicleDrivers = new List<VehicleDriver>();
                    using (JsonDocument document =
                    JsonDocument.Parse(jsonString))
                    {
                        JsonElement root = document.RootElement;
                        if (root.ValueKind == JsonValueKind.Array)
                        {
                            foreach (JsonElement vehicleDriverElement in
                            root.EnumerateArray())
                            {
                                VehicleDriver vehicleDriver = new VehicleDriver(
                                vehicleDriverElement.GetProperty("VehicleId").GetInt32(),
                                vehicleDriverElement.GetProperty("DriverId").GetInt32());
                                vehicleDrivers.Add(vehicleDriver);
                            }
                        }
                    }
                    foreach (var vehicleDriver in vehicleDrivers)
                    {
                        Console.WriteLine($"Vehicle ID: {vehicleDriver.VehicleId}, Driver ID: { vehicleDriver.DriverId}");
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
        public void GetVehicleDriverJsonNode()
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
                            int driverId = int.Parse(node["DriverId"].ToString());
                            Console.WriteLine($"Vehicle ID: {vehicleId}, Driver ID: { driverId}");
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