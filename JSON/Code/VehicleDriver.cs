using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace laba3
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
    }
}
