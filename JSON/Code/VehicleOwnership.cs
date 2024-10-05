using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace laba3
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
    }
}