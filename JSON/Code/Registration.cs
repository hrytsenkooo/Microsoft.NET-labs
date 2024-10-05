using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace laba3
{
    public class Registration
    {
        public int VehicleId { get; init; }
        public int OwnerId { get; init; }
        public DateTime RegistrationDate { get; set; }
        public string? RegistrationLocation { get; init; }
        public bool IsRegistered { get; set; }
        public Registration(int vehicleId, int ownerId, DateTime registrationDate,
        string? registrationLocation, bool isRegistered)
        {
            VehicleId = vehicleId;
            OwnerId = ownerId;
            RegistrationDate = registrationDate;
            RegistrationLocation = registrationLocation;
            IsRegistered = isRegistered;
        }
    }
}