using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Nodes;
namespace laba3.Methods
{
    public class VehicleOwnershipJson
    {
        private readonly string _path =
        "C:\\Users\\User\\source\\repos\\laba3\\laba3\\JSON\\VehicleOwnership.json";
        public void AddVehicleOwnershipSerializer(List<VehicleOwnership>
        ownerships)
        {
            try
            {
                if (File.Exists(_path))
                {
                    string json = File.ReadAllText(_path);
                    if (json != null)
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
                        JsonSerializer.Serialize(fs, ownerships, options);
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
        public void GetVehicleOwnershipDeserializer()
        {
            try
            {
                using (FileStream fs = new FileStream(_path,
                FileMode.OpenOrCreate))
                {
                    List<VehicleOwnership>? ownerships =
                    JsonSerializer.Deserialize<List<VehicleOwnership>>(fs);
                    if (ownerships != null)
                    {
                        foreach (var ownership in ownerships)
                        {
                            Console.WriteLine($"VehicleId: {ownership.VehicleId}");
                            Console.WriteLine($"OwnerId: {ownership.OwnerId}");
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
        public void GetVehicleOwnershipJson()
        {
            try
            {
                string jsonString = File.ReadAllText(_path);
                if (!string.IsNullOrEmpty(jsonString))
                {
                    List<VehicleOwnership> ownerships = new
                    List<VehicleOwnership>();
                    using (JsonDocument document =
                    JsonDocument.Parse(jsonString))
                    {
                        JsonElement root = document.RootElement;
                        if (root.ValueKind == JsonValueKind.Array)
                        {
                            foreach (JsonElement ownershipElement in
                            root.EnumerateArray())
                            {
                                VehicleOwnership ownership = new VehicleOwnership(
                                ownershipElement.GetProperty("VehicleId").GetInt32(),
                                ownershipElement.GetProperty("OwnerId").GetInt32());
                                ownerships.Add(ownership);
                            }
                        }
                    }
                    foreach (var ownership in ownerships)
                    {
                        Console.WriteLine($"Vehicle ID: {ownership.VehicleId}, Owner
                        ID: { ownership.OwnerId}
                        ");
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
        public void AddVehicleOwnershipJsonNode(List<VehicleOwnership>
        ownerships)
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
                    JsonArray jsonArray = new JsonArray();
                    foreach (var ownership in ownerships)
                    {
                        JsonNode? rootNode = JsonNode.Parse("{}");
                        if (rootNode != null)
                        {
                            rootNode["VehicleId"] = ownership.VehicleId;
                            rootNode["OwnerId"] = ownership.OwnerId;
                            jsonArray.Add(rootNode);
                        }
                    }
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        Encoder =
                    System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    };
                    string jsonString = jsonArray.ToJsonString(options);
                    File.WriteAllText(_path, jsonString);
                    Console.WriteLine($"Дані записані");
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
        public void GetVehicleOwnershipJsonNode()
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
                            Console.WriteLine($"Vehicle ID: {vehicleId}, Owner ID:{ ownerId}");
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