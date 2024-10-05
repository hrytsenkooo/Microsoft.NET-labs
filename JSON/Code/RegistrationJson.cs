using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Nodes;
namespace laba3.Methods
{
    public class RegistrationJson
    {
        private readonly string _path =
        "C:\\Users\\User\\source\\repos\\laba3\\laba3\\JSON\\Registration.json";
        public void AddRegistrationSerializer(List<Registration> registrations)
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
                        JsonSerializer.Serialize(fs, registrations, options);
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
        public void GetRegistrationDeserializer()
        {
            try
            {
                using (FileStream fs = new FileStream(_path,
                FileMode.OpenOrCreate))
                {
                    List<Registration>? registrations =
                    JsonSerializer.Deserialize<List<Registration>>(fs);
                    if (registrations != null)
                    {
                        foreach (var registration in registrations)
                        {
                            Console.WriteLine($"VehicleId: {registration.VehicleId}");
                            Console.WriteLine($"OwnerId: {registration.OwnerId}");
                            Console.WriteLine($"RegistrationDate:
                        { registration.RegistrationDate}
                            ");
                        Console.WriteLine($"RegistrationLocation:
                        { registration.RegistrationLocation}
                            ");
                        Console.WriteLine($"IsRegistered:
                        { registration.IsRegistered}
                            ");
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
        public void GetRegistrationJson()
        {
            try
            {
                string jsonString = File.ReadAllText(_path);
                if (!string.IsNullOrEmpty(jsonString))
                {
                    List<Registration> registrations = new List<Registration>();
                    using (JsonDocument document =
                    JsonDocument.Parse(jsonString))
                    {
                        JsonElement root = document.RootElement;
                        if (root.ValueKind == JsonValueKind.Array)
                        {
                            foreach (JsonElement registrationElement in
                            root.EnumerateArray())
                            {
                                Registration registration = new Registration(
                                registrationElement.GetProperty("VehicleId").GetInt32(),
                                registrationElement.GetProperty("OwnerId").GetInt32(),
                                registrationElement.GetProperty("RegistrationDate").GetDateTime(),
                                registrationElement.GetProperty("RegistrationLocation").GetString(),
                                registrationElement.GetProperty("IsRegistered").GetBoolean());
                                registrations.Add(registration);
                            }
                        }
                    }
                    foreach (var registration in registrations)
                    {
                        Console.WriteLine($"Vehicle ID: {registration.VehicleId},
                        Owner ID: { registration.OwnerId}, " + $"Registration Date: {registration.RegistrationDate},
                        Registration Location: { registration.RegistrationLocation}, " + $"Is Registered: {registration.IsRegistered}");
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
        public void GetRegistrationJsonNode()
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
                            int ownerId = int.Parse(node["OwnerId"].ToString());
                            DateTime registrationDate =
                            DateTime.Parse(node["RegistrationDate"].ToString());
                            string registrationLocation =
                            node["RegistrationLocation"].ToString();
                            bool isRegistered =
                            bool.Parse(node["IsRegistered"].ToString());
                            Console.WriteLine($"Vehicle ID: {vehicleId}, Owner ID: { ownerId}, " + $"Registration Date: {registrationDate}, Registration
                            Location: { registrationLocation}, " + $"Is Registered: {isRegistered}");
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