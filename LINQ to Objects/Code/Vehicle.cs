Vehicle.cs:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace laba1
{
    public class Vehicle
    {
        public int VehicleId { get; init; }
        public string Brand { get; init; }
        public string Manufacturer { get; init; }
        public string Model { get; init; }
        public string BodyType { get; init; }
        public int YearOfManufacture { get; init; }
        public string ChassisNumber { get; init; }
        public string Color { get; init; }
        public string LicensePlate { get; init; }
        public string TechnicalCondition { get; init; }
        public List<Owner> Owners { get; init; }
        public List<Driver> Drivers { get; init; }
        public object Registrations { get; internal set; }
        public Vehicle()
        {
            VehicleId = 0;
            Brand = string.Empty;
            Manufacturer = string.Empty;
            Model = string.Empty;
            BodyType = string.Empty;
            YearOfManufacture = 0;
            ChassisNumber = string.Empty;
            Color = string.Empty;
            LicensePlate = string.Empty;
            TechnicalCondition = string.Empty;
            Owners = new();
            Drivers = new();
        }
        public override string ToString()
        {
            StringBuilder infoAsStringBuilder = new StringBuilder();
            infoAsStringBuilder.AppendLine($"\nID транспортного засобу: {VehicleId}");
            infoAsStringBuilder.AppendLine($"Марка: {Brand}");
            infoAsStringBuilder.AppendLine($"Виробник: {Manufacturer}");
            infoAsStringBuilder.AppendLine($"Модель: {Model}");
            infoAsStringBuilder.AppendLine($"Тип кузова: {BodyType}");
            infoAsStringBuilder.AppendLine($"Рік виробництва: {YearOfManufacture}");
            infoAsStringBuilder.AppendLine($"Номер шасі: {ChassisNumber}");
            infoAsStringBuilder.AppendLine($"Колір: {Color}");
            infoAsStringBuilder.AppendLine($"Номерний знак: {LicensePlate}");
            infoAsStringBuilder.AppendLine($"Технічний стан: {TechnicalCondition}");
            infoAsStringBuilder.Append("\n~Власники та водії~\n");
            foreach (Owner owner in Owners)
            {
            infoAsStringBuilder.AppendLine(owner.ToString());
            }
            foreach (Driver driver in Drivers)
            {
            infoAsStringBuilder.AppendLine(driver.ToString());
            }
            return infoAsStringBuilder.ToString();
        }
    }
}
