using System;
using System.Collections.Generic;

namespace laba2
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

        public Vehicle(int vehicleId, string? brand, string? manufacturer, string? model, string? bodyType, int yearOfManufacture, string? chassisNumber, string? color, string? licensePlate, string? technicalCondition, List<Registration>? registrations)
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
            Registrations = registrations;
        }

        public Vehicle() { }

        public static Vehicle CreateVehicle()
        {
            int vehicleId, yearOfManufacture;
            string? brand, manufacturer, model, bodyType, chassisNumber, color, licensePlate, technicalCondition;

            Console.WriteLine("Enter Vehicle ID:");
            while (!int.TryParse(Console.ReadLine(), out vehicleId) || vehicleId <= 0)
            {
                Console.WriteLine("Invalid Vehicle ID. It should be a positive integer.");
                Console.WriteLine("Enter Vehicle ID:");
            }

            Console.WriteLine("Enter Brand:");
            brand = Console.ReadLine();

            Console.WriteLine("Enter Manufacturer:");
            manufacturer = Console.ReadLine();

            Console.WriteLine("Enter Model:");
            model = Console.ReadLine();

            Console.WriteLine("Enter Body Type:");
            bodyType = Console.ReadLine();

            Console.WriteLine("Enter Year of Manufacture:");
            while (!int.TryParse(Console.ReadLine(), out yearOfManufacture) || yearOfManufacture <= 0)
            {
                Console.WriteLine("Invalid Year of Manufacture. It should be a positive integer.");
                Console.WriteLine("Enter Year of Manufacture:");
            }

            Console.WriteLine("Enter Chassis Number:");
            chassisNumber = Console.ReadLine();

            Console.WriteLine("Enter Color:");
            color = Console.ReadLine();

            Console.WriteLine("Enter License Plate:");
            licensePlate = Console.ReadLine();

            Console.WriteLine("Enter Technical Condition:");
            technicalCondition = Console.ReadLine();

            List<Registration>? registrations = null;
            return new Vehicle(vehicleId, brand, manufacturer, model, bodyType, yearOfManufacture, chassisNumber, color, licensePlate, technicalCondition, registrations);
        }
    }
}
