using System;
using System.Globalization;
using System.Xml.Serialization;

namespace laba2
{
    public class Registration
    {
        public int VehicleId { get; init; }
        public int OwnerId { get; init; }

        [XmlIgnore]
        public DateTime RegistrationDate { get; set; }

        [XmlElement("RegistrationDate")]
        public string RegistrationDateString
        {
            get { return RegistrationDate.ToString("dd.MM.yyyy"); }
            set { RegistrationDate = DateTime.ParseExact(value, "dd.MM.yyyy", null); }
        }

        public string? RegistrationLocation { get; init; }
        public bool IsRegistered { get; set; }

        public Registration(int vehicleId, int ownerId, DateTime registrationDate, string? registrationLocation, bool isRegistered)
        {
            VehicleId = vehicleId;
            OwnerId = ownerId;
            RegistrationDate = registrationDate;
            RegistrationLocation = registrationLocation;
            IsRegistered = isRegistered;
        }

        public Registration() { }

        public static Registration CreateRegistration()
        {
            int vehicleId, ownerId;
            DateTime registrationDate;
            string? registrationLocation;
            bool isRegistered;

            Console.WriteLine("Enter Vehicle ID:");
            while (!int.TryParse(Console.ReadLine(), out vehicleId) || vehicleId <= 0)
            {
                Console.WriteLine("Invalid Vehicle ID. It should be a positive integer.");
                Console.WriteLine("Enter Vehicle ID:");
            }

            Console.WriteLine("Enter Owner ID:");
            while (!int.TryParse(Console.ReadLine(), out ownerId) || ownerId <= 0)
            {
                Console.WriteLine("Invalid Owner ID. It should be a positive integer.");
                Console.WriteLine("Enter Owner ID:");
            }

            Console.WriteLine("Enter Registration Date (dd.MM.yyyy):");
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out registrationDate))
            {
                Console.WriteLine("Invalid Date. Please enter in dd.MM.yyyy format:");
            }

            Console.WriteLine("Enter Registration Location:");
            registrationLocation = Console.ReadLine();

            Console.WriteLine("Is Registered? (true/false):");
            while (!bool.TryParse(Console.ReadLine(), out isRegistered))
            {
                Console.WriteLine("Invalid input. Please enter 'true' or 'false':");
            }

            return new Registration(vehicleId, ownerId, registrationDate, registrationLocation, isRegistered);
        }
    }
}
