using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace laba3
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string? Brand { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? BodyType { get; set; }
        public int YearOfManufacture { get; set; }
        public string? ChassisNumber { get; set; }
        public string? Color { get; set; }
        public string? LicensePlate { get; set; }
        public string? TechnicalCondition { get; set; }
        public List<Registration>? Registrations { get; set; }
        public Vehicle(int vehicleId, string? brand, string? manufacturer, string?
        model, string? bodyType, int yearOfManufacture, string? chassisNumber,
        string? color, string? licensePlate, string? technicalCondition)
        {
            VehicleId = vehicleId;
            Brand = brand;
            Manufacturer = manufacturer;
            Model = model;
            BodyType = bodyType;
            YearOfManufacture = yearOfManufacture;
            ChassisNumber = chassisNumber;
            Color = color;
            LicensePlate = licensePlate;
            TechnicalCondition = technicalCondition;
        }
    }
}
