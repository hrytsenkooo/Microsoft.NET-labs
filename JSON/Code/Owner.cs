using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace laba3
{
    public class Owner
    {
        public int ownerId { get; set; }
        public string? lastName { get; set; }
        public string? firstName { get; set; }
        public string? patronymic { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string? registrationAddress { get; set; }
        public string? licenseNumber { get; set; }
        public Owner(int OwnerId, string? LastName, string? FirstName, string?
        Patronymic, DateTime DateOfBirth,
        string? RegistrationAddress, string? LicenseNumber)
        {
            ownerId = OwnerId;
            lastName = LastName;
            firstName = FirstName;
            patronymic = Patronymic;
            dateOfBirth = DateOfBirth;
            registrationAddress = RegistrationAddress;
            licenseNumber = LicenseNumber;
        }
    }
}