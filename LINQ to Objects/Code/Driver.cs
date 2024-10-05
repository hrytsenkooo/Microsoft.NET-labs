using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace laba1
{
    public class Driver
    {
        public int DriverId { get; init; }
        public string LastName { get; init; }
        public string FirstName { get; init; }
        public string Patronymic { get; init; }
        public DateTime DateOfBirth { get; init; }
        public string RegistrationAddress { get; init; }
        public string LicenseNumber { get; init; }
        public Driver()
        {
            DriverId = 0;
            LastName = string.Empty;
            FirstName = string.Empty;
            Patronymic = string.Empty;
            DateOfBirth = DateTime.MinValue;
            RegistrationAddress = string.Empty;
            LicenseNumber = string.Empty;
        }
        public override string ToString()
        {
            return $"\nDriver ID: {DriverId}\n" + 
            $"Прізвище: {LastName}\n" +
            $"Ім'я: {FirstName}\n" +
            $"По батькові: {Patronymic}\n" +
            $"Дата народження: {DateOfBirth.ToShortDateString()}\n" +
            $"Адреса реєстрації: {RegistrationAddress}\n" +
            $"Номер водійського посвідчення: {LicenseNumber}";
        }
    }
}
