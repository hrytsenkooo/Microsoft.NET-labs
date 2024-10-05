using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace laba5
{
    public abstract class PrescriptionDecorator : IPrescription
    {
        protected IPrescription _prescription;
        public PrescriptionDecorator(IPrescription prescription)
        {
            _prescription = prescription;
        }
        public virtual string GetPrescription()
        {
            return _prescription.GetPrescription();
        }
        public virtual DateTime GetExpirationDate()
        {
            return _prescription.GetExpirationDate();
        }
        public virtual string GetDoctorNote()
        {
            return _prescription.GetDoctorNote();
        }
        public virtual string GetDoctorName()
        {
            return _prescription.GetDoctorName();
        }
    }
    public class ExtendExpirationDecorator : PrescriptionDecorator
    {
        private int _extraDays;
        public ExtendExpirationDecorator(IPrescription prescription, int
        extraDays)
        : base(prescription)
        {
            _extraDays = extraDays;
        }
        public override DateTime GetExpirationDate()
        {
            return _prescription.GetExpirationDate().AddDays(_extraDays);
        }
    }
}
