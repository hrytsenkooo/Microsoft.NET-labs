using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace laba1
{
    public class Registration
    {
        public int VehicleId { get; init; }
        public int OwnerId { get; init; }
        public DateTime RegistrationDate { get; init; }
        public string RegistrationLocation { get; init; }
        public bool IsRegistered { get; set; }
        public Registration()
        {
            VehicleId = 0;
            OwnerId = 0;
            RegistrationDate = DateTime.MinValue;
            RegistrationLocation = string.Empty;
            IsRegistered = false;
        }
        public override string ToString()
        {
            return $"Vehicle ID: {VehicleId}\n" +
            $"Owner ID: {OwnerId}\n" + 
            $"Registration Date: {RegistrationDate}\n" +
            $"Registration Location: {RegistrationLocation}\n" +
            $"Is Registered: {(IsRegistered ? "Yes" : "No")}";
        }
    }
}
