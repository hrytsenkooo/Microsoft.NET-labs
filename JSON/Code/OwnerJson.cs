using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Nodes;
namespace laba3.Methods
{
    public class OwnerJson
    {
        private readonly string _path =
        "C:\\Users\\User\\source\\repos\\laba3\\laba3\\JSON\\Owner.json";
        public void AddOwnerSerializer(List<Owner> owners)
        {
            if (File.Exists(_path))
            {
                try
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
                        JsonSerializer.Serialize(fs, owners, options);
                        Console.WriteLine("Дані записано!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Файл не існує");
            }
        }
        public void GetOwnerDeserializer()
        {
            try
            {
                using (FileStream fs = new FileStream(_path,
                FileMode.OpenOrCreate))
                {
                    List<Owner>? owners =
                    JsonSerializer.Deserialize<List<Owner>>(fs);
                    if (owners != null)
                    {
                        foreach (var owner in owners)
                        {
                            Console.WriteLine($"OwnerId: {owner.ownerId}");
                            Console.WriteLine($"LastName: {owner.lastName}");
                            Console.WriteLine($"FirstName: {owner.firstName}");
                            Console.WriteLine($"Patronymic: {owner.patronymic}");
                            Console.WriteLine($"DateOfBirth: {owner.dateOfBirth}");
                            Console.WriteLine($"RegistrationAddress:{ owner.registrationAddress}");
                            Console.WriteLine($"LicenseNumber: { owner.licenseNumber}");
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
        public void GetOwnerJson()
        {
            try
            {
                string jsonString = File.ReadAllText(_path);
                if (!string.IsNullOrEmpty(jsonString))
                {
                    List<Owner> owners = new List<Owner>();
                    using (JsonDocument document =
                    JsonDocument.Parse(jsonString))
                    {
                        JsonElement root = document.RootElement;
                        if (root.ValueKind == JsonValueKind.Array)
                        {
                            foreach (JsonElement ownerElement in
                            root.EnumerateArray())
                            {
                                Owner owner = new Owner(
                                ownerElement.GetProperty("ownerId").GetInt32(),
                                ownerElement.GetProperty("lastName").GetString(),
                                ownerElement.GetProperty("firstName").GetString(),
                                ownerElement.GetProperty("patronymic").GetString(),
                                ownerElement.GetProperty("dateOfBirth").GetDateTime(),
                                ownerElement.GetProperty("registrationAddress").GetString(),
                                ownerElement.GetProperty("licenseNumber").GetString());
                                owners.Add(owner);
                            }
                        }
                    }
                    foreach (var owner in owners)
                    {
                        Console.WriteLine($"Owner ID: {owner.ownerId}, Last Name: { owner.lastName}, " + $"First Name: {owner.firstName}, Patronymic: { owner.patronymic}, " +
                                            $"Date of Birth: {owner.dateOfBirth}, Registration Address: { owner.registrationAddress}, " + $"License Number: {owner.licenseNumber}");
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
        public void GetOwnerJsonNode()
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
                            int ownerId = int.Parse(node["ownerId"].ToString());
                            string lastName = node["lastName"].ToString();
                            string firstName = node["firstName"].ToString();
                            string patronymic = node["patronymic"].ToString();
                            DateTime dateOfBirth =
                            DateTime.Parse(node["dateOfBirth"].ToString());
                            string registrationAddress =
                            node["registrationAddress"].ToString();
                            string licenseNumber = node["licenseNumber"].ToString();
                            Console.WriteLine($"Owner ID: {ownerId}, Last Name: { lastName}, " + $"First Name: {firstName}, Patronymic: {patronymic}, " +
                            $"Date of Birth: {dateOfBirth}, Registration Address: { registrationAddress}, " + $"License Number: {licenseNumber}");
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