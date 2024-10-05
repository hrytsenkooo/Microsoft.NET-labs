using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace laba2
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Patronymic { get; set; }
        public string? RegistrationAddress { get; set; }
        public string? LicenseNumber { get; set; }

        [XmlIgnore]
        public DateTime DateOfBirth { get; set; }

        [XmlElement("DateOfBirth")]
        public string DateOfBirthString
        {
            get { return DateOfBirth.ToString("dd.MM.yyyy"); }
            set { DateOfBirth = DateTime.ParseExact(value, "dd.MM.yyyy", null); }
        }

        public Driver(int driverId, string? lastName, string? firstName, string? patronymic, DateTime dateOfBirth, string? registrationAddress, string? licenseNumber)
        {
            DriverId = driverId;
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
            RegistrationAddress = registrationAddress;
            LicenseNumber = licenseNumber;
        }

        public Driver() { }

        public static Driver CreateDriver()
        {
            int driverId;
            string? lastName, firstName, patronymic, registrationAddress, licenseNumber;
            DateTime dateOfBirth;

            Console.WriteLine("Enter Driver ID:");
            while (!int.TryParse(Console.ReadLine(), out driverId) || driverId <= 0)
            {
                Console.WriteLine("Invalid Driver ID. It should be a positive integer.");
                Console.WriteLine("Enter Driver ID:");
            }

            Console.WriteLine("Enter Last Name:");
            lastName = Console.ReadLine();

            Console.WriteLine("Enter First Name:");
            firstName = Console.ReadLine();

            Console.WriteLine("Enter Patronymic:");
            patronymic = Console.ReadLine();

            Console.WriteLine("Enter Date of Birth (dd.MM.yyyy):");
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth))
            {
                Console.WriteLine("Invalid Date. Please enter in dd.MM.yyyy format:");
            }

            Console.WriteLine("Enter Registration Address:");
            registrationAddress = Console.ReadLine();

            Console.WriteLine("Enter License Number:");
            licenseNumber = Console.ReadLine();

            return new Driver(driverId, lastName, firstName, patronymic, dateOfBirth, registrationAddress, licenseNumber);
        }
    }
}
