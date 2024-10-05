using System;
using System.Globalization;
using System.Xml.Serialization;

namespace laba2
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Patronymic { get; set; }

        [XmlIgnore]
        public DateTime DateOfBirth { get; set; }

        [XmlElement("DateOfBirth")]
        public string DateOfBirthString
        {
            get { return DateOfBirth.ToString("dd.MM.yyyy"); }
            set { DateOfBirth = DateTime.ParseExact(value, "dd.MM.yyyy", null); }
        }

        public string? RegistrationAddress { get; set; }
        public string? LicenseNumber { get; set; }

        public Owner(int ownerId, string? lastName, string? firstName, string? patronymic, DateTime dateOfBirth, string? registrationAddress, string? licenseNumber)
        {
            OwnerId = ownerId;
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
            RegistrationAddress = registrationAddress;
            LicenseNumber = licenseNumber;
        }

        public Owner() { }

        public static Owner CreateOwner()
        {
            int ownerId;
            string? lastName, firstName, patronymic, registrationAddress, licenseNumber;
            DateTime dateOfBirth;

            Console.WriteLine("Enter Owner ID:");
            while (!int.TryParse(Console.ReadLine(), out ownerId) || ownerId <= 0)
            {
                Console.WriteLine("Invalid Owner ID. It should be a positive integer.");
                Console.WriteLine("Enter Owner ID:");
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

            return new Owner(ownerId, lastName, firstName, patronymic, dateOfBirth, registrationAddress, licenseNumber);
        }
    }
}
