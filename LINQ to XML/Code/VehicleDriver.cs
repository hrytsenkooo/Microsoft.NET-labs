using System;

namespace laba2
{
    public class VehicleDriver
    {
        public int VehicleId { get; set; }
        public int DriverId { get; set; }

        public VehicleDriver(int vehicleId, int driverId)
        {
            VehicleId = vehicleId;
            DriverId = driverId;
        }

        public VehicleDriver() { }

        public static VehicleDriver CreateVehicleDriver()
        {
            int vehicleId, driverId;

            Console.WriteLine("Enter Vehicle ID:");
            while (!int.TryParse(Console.ReadLine(), out vehicleId) || vehicleId <= 0)
            {
                Console.WriteLine("Invalid Vehicle ID. It should be a positive integer.");
                Console.WriteLine("Enter Vehicle ID:");
            }

            Console.WriteLine("Enter Driver ID:");
            while (!int.TryParse(Console.ReadLine(), out driverId) || driverId <= 0)
            {
                Console.WriteLine("Invalid Driver ID. It should be a positive integer.");
                Console.WriteLine("Enter Driver ID:");
            }

            return new VehicleDriver(vehicleId, driverId);
        }
    }
}
