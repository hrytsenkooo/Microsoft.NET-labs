using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace laba3.Methods
{
    public class DriverJson
    {
        private readonly string _path =
        "C:\\Users\\User\\source\\repos\\laba3\\laba3\\JSON\\Driver.json";
        public void AddDriverSerializer(List<Driver> drivers)
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
                        JsonSerializer.Serialize(fs, drivers, options);
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
        public void GetDriverDeserializer()
        {
            try
            {
                using (FileStream fs = new FileStream(_path,
                FileMode.OpenOrCreate))
                {
                    List<Driver>? drivers =
                    JsonSerializer.Deserialize<List<Driver>>(fs);
                    if (drivers != null)
                    {
                        foreach (var driver in drivers)
                        {
                            Console.WriteLine($"DriverId: {driver.driverId}");
                            Console.WriteLine($"LastName: {driver.lastName}");
                            Console.WriteLine($"FirstName: {driver.firstName}");
                            Console.WriteLine($"Patronymic: {driver.patronymic}");
                            Console.WriteLine($"DateOfBirth: {driver.dateOfBirth}");
                            Console.WriteLine($"RegistrationAddress:
                        { driver.registrationAddress}
                            ");
                        Console.WriteLine($"LicenseNumber:
                        { driver.licenseNumber}
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
        public void GetDriverJson()
        {
            try
            {
                string jsonString = File.ReadAllText(_path);
                if (!string.IsNullOrEmpty(jsonString))
                {
                    List<Driver> drivers = new List<Driver>();
                    using (JsonDocument document =
                    JsonDocument.Parse(jsonString))
                    {
                        JsonElement root = document.RootElement;
                        if (root.ValueKind == JsonValueKind.Array)
                        {
                            foreach (JsonElement driverElement in
                            root.EnumerateArray())
                            {
                                int driverId =
                                driverElement.GetProperty("driverId").GetInt32();
                                string lastName =
                                driverElement.GetProperty("lastName").GetString();
                                string firstName =
                                driverElement.GetProperty("firstName").GetString();
                                string patronymic =
                                driverElement.GetProperty("patronymic").GetString();
                                DateTime dateOfBirth =
                                driverElement.GetProperty("dateOfBirth").GetDateTime();
                                string registrationAddress =
                                driverElement.GetProperty("registrationAddress").GetString();
                                string licenseNumber =
                                driverElement.GetProperty("licenseNumber").GetString();
                                Driver driver = new Driver(driverId, lastName, firstName,
                                patronymic, dateOfBirth, registrationAddress, licenseNumber);
                                drivers.Add(driver);
                            }
                        }
                    }
                    foreach (var driver in drivers)
                    {
                        Console.WriteLine($"Driver ID: {driver.driverId}, Last Name: { driver.lastName}, " + $"First Name: {driver.firstName}, Patronymic:
                                            { driver.patronymic}, " + $"Date of Birth: {driver.dateOfBirth}, Registration Address: { driver.registrationAddress}, " +
                                            $"License Number: {driver.licenseNumber}");
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
        public void GetDriverJsonNode()
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
                            int driverId = int.Parse(node["driverId"].ToString());
                            string lastName = node["lastName"].ToString();
                            string firstName = node["firstName"].ToString();
                            string patronymic = node["patronymic"].ToString();
                            DateTime dateOfBirth =
                            DateTime.Parse(node["dateOfBirth"].ToString());
                            string registrationAddress =
                            node["registrationAddress"].ToString();
                            string licenseNumber = node["licenseNumber"].ToString();
                            Console.WriteLine($"Driver ID: {driverId}, Last Name: { lastName}, " + $"First Name: {firstName}, Patronymic: {patronymic}, " +
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