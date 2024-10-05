using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace laba5
{
    public class Prescription : IPrescription
    {
        private string _doctorName;
        private DateTime _expirationDate;
        private string _doctorNote;
        public Prescription(string doctorName, DateTime expirationDate, string
        doctorNote)
        {
            _doctorName = doctorName;
            _expirationDate = expirationDate;
            _doctorNote = doctorNote;
        }
        public string GetPrescription()
        {
            return $"Prescription by Dr. {_doctorName}";
        }
        public DateTime GetExpirationDate()
        {
            return _expirationDate;
        }
        public string GetDoctorNote()
        {
            return _doctorNote;
        }
        public string GetDoctorName()
        {
            return _doctorName;
        }
    }
}
