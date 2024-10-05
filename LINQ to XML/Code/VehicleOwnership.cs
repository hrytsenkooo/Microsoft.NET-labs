using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    public class VehicleOwnership
    {
        public int VehicleId { get; set; }
        public int OwnerId { get; set; }

        public VehicleOwnership(int vehicleId, int ownerId)
        {
            VehicleId = vehicleId;
            OwnerId = ownerId;
        }

        public VehicleOwnership()
        {
        }

        public static VehicleOwnership CreateVehicleOwnership()
        {
            int vehicleId, ownerId;
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
            return new VehicleOwnership(vehicleId, ownerId);
        }
    }
}
