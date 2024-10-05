using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace laba1
{
    public class VehicleOwnership
    {
        public int VehicleId { get; init; }
        public int OwnerId { get; init; }
        public VehicleOwnership()
        {
            VehicleId = 0;
            OwnerId = 0;
        }
    }
}