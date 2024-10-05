using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace laba5
{
    public interface IPrescription
    {
        string GetDoctorName();
        string GetPrescription();
        DateTime GetExpirationDate();
        string GetDoctorNote();
    }
}