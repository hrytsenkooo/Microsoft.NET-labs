using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace laba2
{
    public class Queries
    {
        private readonly string _driver =
        "C:\\Users\\User\\source\\repos\\laba2\\laba2\\XML\\Driver.xml";
        private readonly string _owner =
        "C:\\Users\\User\\source\\repos\\laba2\\laba2\\XML\\Owner.xml";
        private readonly string _registration =
        "C:\\Users\\User\\source\\repos\\laba2\\laba2\\XML\\VehicleRegistrations.xml";
        private readonly string _vehicle =
        "C:\\Users\\User\\source\\repos\\laba2\\laba2\\XML\\Vehicle.xml";
        private readonly string _vehicleDriver =
        "C:\\Users\\User\\source\\repos\\laba2\\laba2\\XML\\VehicleDriver.xml";
        private readonly string _vehicleOwnership =
        "C:\\Users\\User\\source\\repos\\laba2\\laba2\\XML\\VehicleOwnership.xml";

        // #1. Отримати усі машини з типом кузову SUV
        public void GetSUVVehicles()
        {
            XDocument xdoc = XDocument.Load(_vehicle);
            var suvVehicles = from vehicle in xdoc.Descendants("Vehicle")
                              where (string?)vehicle.Element("BodyType") == "SUV"
                              select vehicle;
            Console.WriteLine("Список машин типу SUV:");
            if (suvVehicles.Any())
            {
                foreach (var vehicle in suvVehicles)
                {
                    if (vehicle != null)
                    {
                        Console.WriteLine($"Машина:
                        { (string?)vehicle.Element("Brand")}
                        { (string?)vehicle.Element("Model")}, Рік
                        виробництва: { (int?)vehicle.Element("YearOfManufacture")}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Немає машин типу SUV в базі даних.");
            }
        }

        // #2. Отримати усі машини та відповідно їх власників
        public IEnumerable<(XElement vehicle, XElement owner)> GetAllSUVsWithOwners()
        {
            XDocument vehicleDoc = XDocument.Load(_vehicle);
            XDocument ownershipDoc = XDocument.Load(_vehicleOwnership);
            XDocument ownerDoc = XDocument.Load(_owner);
            var suvsWithOwners = from ownership in
            ownershipDoc.Descendants("VehicleOwnership")
                                 join vehicle in
                                 vehicleDoc.Descendants("Vehicle").Where(v =>
                                 (string)v.Element("BodyType") == "SUV")
                                 on (int)ownership.Element("VehicleId") equals
                                 (int)vehicle.Element("VehicleId")
                                 join owner in ownerDoc.Descendants("Owner")
                                 on (int)ownership.Element("OwnerId") equals
                                 (int)owner.Element("OwnerId")
                                 select (
                                 vehicle: vehicle,
                                 owner: owner
                                 );
            Console.WriteLine("List of SUVs with their respective owners:");
            foreach (var pair in suvsWithOwners)
            {
                Console.WriteLine($"Vehicle:
                { pair.vehicle.Element("Brand")?.Value}
                { pair.vehicle.Element("Model")?.Value}, Owner:
                { pair.owner.Element("FirstName")?.Value}
                { pair.owner.Element("LastName")?.Value}");
            }
            return suvsWithOwners;
        }

        // #3. Отримати перелік машин, що мають відмінні технічні показники
        public IEnumerable<XElement> GetMachinesInExcellentCondition()
        {
            XDocument vehicleDoc = XDocument.Load(_vehicle);
            var machinesInExcellentCondition = from vehicle in
            vehicleDoc.Descendants("Vehicle")
                                               where
                                               (string?)vehicle.Element("TechnicalCondition") == "Excellent"
                                               select vehicle;
            Console.WriteLine("List of vehicles in excellent condition:");
            foreach (var machine in machinesInExcellentCondition)
            {
                Console.WriteLine($"Vehicle: {machine.Element("Brand")?.Value}
                                { machine.Element("Model")?.Value}");
            }
            return machinesInExcellentCondition;
        }

        // #4. Отримати перелік людей (власників), вік яких входить у заданий діапазон
        public IEnumerable<XElement> GetOwnersWithinAgeRange(int minYear,
        int maxYear)
            {
                XDocument ownerDoc = XDocument.Load(_owner);
                var currentDate = DateTime.Now;
                var minDateOfBirth = currentDate.AddYears(-maxYear);
                var maxDateOfBirth = currentDate.AddYears(-minYear);
                var ownersWithinAgeRange = from owner in
                ownerDoc.Descendants("Owner")
                                        let dateOfBirthStr =
                                        owner.Element("DateOfBirth")?.Value
                                        where dateOfBirthStr != null &&
                                        DateTime.TryParseExact(dateOfBirthStr,
                                        "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out
                                        DateTime dateOfBirth) &&
                                        dateOfBirth >= minDateOfBirth && dateOfBirth
                                        <= maxDateOfBirth
                                        select owner;
                Console.WriteLine("Owners within the specified age range:");
                foreach (var owner in ownersWithinAgeRange)
                {
                    Console.WriteLine($"Owner: {owner.Element("FirstName")?.Value}
                    { owner.Element("LastName")?.Value}, Date of Birth:
                    { owner.Element("DateOfBirth")?.Value}
                    ");
                }
                return ownersWithinAgeRange;
            }
        // #5. Отримати водія, що має найдовше ім'я
        public void GetDriverWithLongestName(IEnumerable<Driver> drivers)
        {
            XDocument driverDoc = XDocument.Load(_driver);
            var driverWithLongestName = driverDoc.Descendants("Driver")
            .OrderByDescending(driver =>
            {
                var fullName =
                ((string?)driver.Element("FirstName") + (string?)driver.Element("LastName") +
                (string?)driver.Element("Patronymic"));
                return fullName.Length;
            })
            .FirstOrDefault();
            if (driverWithLongestName != null)
            {
                Console.WriteLine($"Driver with the longest name:
                { driverWithLongestName.Element("FirstName").Value}
                { driverWithLongestName.Element("LastName").Value}
                { driverWithLongestName.Element("Patronymic").Value}
                ");
            }
            else
            {
                Console.WriteLine("No driver found.");
            }
        }
        
        // #6. Отримати машину, що має найстаріший рік випуску
        public void GetVehicleWithEarliestManufactureYear(IEnumerable<Vehicle> vehicles)
        {
            XDocument vehicleDoc = XDocument.Load(_vehicle);
            var vehicleWithEarliestManufactureYear =
            vehicleDoc.Descendants("Vehicle")
            .OrderBy(vehicle =>
            (int)vehicle.Element("YearOfManufacture"))
            .FirstOrDefault();
            if (vehicleWithEarliestManufactureYear != null)
            {
                Console.WriteLine($"Vehicle with the earliest manufacture year:
                { vehicleWithEarliestManufactureYear.Element("Brand").Value}
                { vehicleWithEarliestManufactureYear.Element("Model").Value}, Year of Manufacture:
                { vehicleWithEarliestManufactureYear.Element("YearOfManufacture").Value}
                ");
            }
            else
            {
                Console.WriteLine("No vehicle found.");
            }
        }
        // #7. Отримати відсортований перелік водіїв за датою народження в порядку зростання
        public void SortDriversByDateOfBirthAscendingWithBoundaries(IEnumerable<Driver> drivers, int startYear, int endYear)
            {
                XDocument driverDoc = XDocument.Load(_driver);
                var sortedDrivers = driverDoc.Descendants("Driver")
                .Where(driver =>
                {
                    var dateOfBirthStr =
                    (string)driver.Element("DateOfBirth");
                    return dateOfBirthStr != null && DateTime.TryParseExact(dateOfBirthStr,
                    "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out
                    DateTime dateOfBirth) && dateOfBirth.Year >= startYear && dateOfBirth.Year <= endYear;
                })
                .OrderBy(driver =>
                    {
                        var dateOfBirthStr =
                        (string)driver.Element("DateOfBirth");
                        return DateTime.ParseExact(dateOfBirthStr,
                        "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    });
                        
                Console.WriteLine($"Sorted list of drivers by date of birth between { startYear}
                                and { endYear}:");
                foreach (var driver in sortedDrivers)
                    {
                        Console.WriteLine($"Driver: {driver.Element("FirstName").Value}
                        { driver.Element("LastName").Value}, Date of Birth:
                        { driver.Element("DateOfBirth").Value} ");
                    }
            }

        // #8. Отримати перелік машин, що не є зареєстрованими
        public void GetUnregisteredVehicles(IEnumerable<Vehicle> vehicles, IEnumerable<Registration> registrations)
        {
            XDocument vehicleDoc = XDocument.Load(_vehicle);
            XDocument registrationDoc = XDocument.Load(_registration);
            var unregisteredVehicles = from vehicle in
            vehicleDoc.Descendants("Vehicle")
                                       where !registrationDoc.Descendants("Registration")
                                       .Any(registration =>
                                       (int)registration.Element("VehicleId") == (int)vehicle.Element("VehicleId"))
                                       select vehicle;
            Console.WriteLine("List of unregistered vehicles:");
            foreach (var vehicle in unregisteredVehicles)
            {
                Console.WriteLine($"Vehicle: {vehicle.Element("Brand").Value}
                { vehicle.Element("Model").Value}, Vehicle ID:
                { vehicle.Element("VehicleId").Value} ");
            }
        }
        // #9. Отримати перелік машин, випущених до певного року (включно)
        public void GetMachinesReleasedBeforeYear(IEnumerable<Vehicle> vehicles, int year)
        {
            XDocument vehicleDoc = XDocument.Load(_vehicle);
            var machinesReleasedBeforeYear = from vehicle in
            vehicleDoc.Descendants("Vehicle")
                                             where (int)vehicle.Element("YearOfManufacture")
                                             <= year
                                             select vehicle;
            Console.WriteLine($"List of machines released before year {year}:");
            foreach (var vehicle in machinesReleasedBeforeYear)
            {
                Console.WriteLine($"Vehicle: {vehicle.Element("Brand").Value}
                { vehicle.Element("Model").Value}, Year of Manufacture:
                { vehicle.Element("YearOfManufacture").Value}");
            }
        }
        // #10. Отримати машини, зареєстрованих в локації "Local Registration Office"
        public IEnumerable<object> GetVehiclesRegisteredInLocalOffice(IEnumerable<Vehicle> vehicles, IEnumerable<Registration> registrations)
        {
            XDocument vehicleDoc = XDocument.Load(_vehicle);
            XDocument registrationDoc = XDocument.Load(_registration);
            var vehiclesRegisteredInLocalOffice = from registration in
            registrationDoc.Descendants("Registration")
                                                  where
                                                  ((string)registration.Element("RegistrationLocation")).Trim().Equals("Local
                                                  Registration Office", StringComparison.OrdinalIgnoreCase)
            join vehicle in
            vehicleDoc.Descendants("Vehicle") on (int)registration.Element("VehicleId")
            equals (int)vehicle.Element("VehicleId")
                                                  select new
                                                  {
                                                      Brand = vehicle.Element("Brand")?.Value,
                                                      Model = vehicle.Element("Model")?.Value
                                                  };
            Console.WriteLine("List of vehicles registered in the local office:");
            foreach (var vehicle in vehiclesRegisteredInLocalOffice)
            {
                Console.WriteLine($"Vehicle: {vehicle.Brand} {vehicle.Model}");
            }
            return vehiclesRegisteredInLocalOffice;
        }
        // #11. Отримати машини, які не керуються
        public IEnumerable<object> GetVehiclesNotDrivenByDrivers(IEnumerable<Vehicle> vehicles, IEnumerable<Driver> drivers, IEnumerable<VehicleDriver> vehicleDrivers)
        {
            XDocument vehicleDriverDoc = XDocument.Load(_vehicleDriver);
            var vehiclesNotDrivenByDrivers = from vehicle in vehicles
                                             where !drivers.Any(driver =>
                                             vehicleDrivers.Any(vd => vd.VehicleId ==
                                             vehicle.VehicleId && vd.DriverId == driver.DriverId))
                                             select new
                                             {
                                                 Brand = vehicle.Brand,
                                                 Model = vehicle.Model
                                             };

            Console.WriteLine("List of vehicles not driven by any drivers:");
            foreach (var vehicle in vehiclesNotDrivenByDrivers)
            {
                Console.WriteLine($"Vehicle: {vehicle.Brand} {vehicle.Model}");
            }
            return vehiclesNotDrivenByDrivers;
        }
        // #12. Отримати перелік всіх унікальних власників машин та водіїв, об'єднавши їх імена
        public IEnumerable<string> GetUniqueOwnersAndDriversNames(IEnumerable<Owner> owners, IEnumerable<Driver> drivers)
        {
            XDocument ownerDoc = XDocument.Load(_owner);
            XDocument driverDoc = XDocument.Load(_driver);

            var ownerNames = from owner in ownerDoc.Descendants("Owner")
                            select $"{owner.Element("FirstName").Value}
                            { owner.Element("LastName").Value}";
                            
            var driverNames = from driver in driverDoc.Descendants("Driver")
                            select $"{driver.Element("FirstName").Value}
                            { driver.Element("LastName").Value}";
            var uniqueNames = ownerNames.Concat(driverNames).Distinct();

            Console.WriteLine("Unique owner and driver names:");
            foreach (var name in uniqueNames)
            {
                Console.WriteLine(name);
            }
            return uniqueNames;
        }
        // #13. Отримати перелік власників, що мають декілька машин
        public IEnumerable<Owner> GetOwnersWithMultipleVehicles(IEnumerable<Owner> owners, IEnumerable<VehicleOwnership> vehicleOwnerships)
        {
            XDocument ownerDoc = XDocument.Load(_owner);
            XDocument ownershipDoc = XDocument.Load(_vehicleOwnership);
            var ownersWithMultipleVehicles = from ownership in
            ownershipDoc.Descendants("VehicleOwnership")
                                             group ownership by
                                             (int)ownership.Element("OwnerId") into ownershipGroup
                                             where ownershipGroup.Count() > 1
                                             join owner in ownerDoc.Descendants("Owner") on
                                             ownershipGroup.Key equals (int)owner.Element("OwnerId")
                                             select new Owner
                                             {
                                                 OwnerId = (int)owner.Element("OwnerId"),
                                                 FirstName =
                                             (string)owner.Element("FirstName"),
                                                 LastName = (string)owner.Element("LastName"),
                                                 DateOfBirth =
                                             (DateTime)owner.Element("DateOfBirth")
                                             };
            if (!ownersWithMultipleVehicles.Any())
            {
                Console.WriteLine("No owners with multiple vehicles found.");
            }
            else
            {
                Console.WriteLine("Owners with multiple vehicles:");
                foreach (var owner in ownersWithMultipleVehicles)
                {
                    Console.WriteLine($"Owner ID: {owner.OwnerId}, Name: { owner.FirstName}
                    { owner.LastName}, Date of Birth: { owner.DateOfBirth}
                    ");
                }
            }
            return ownersWithMultipleVehicles;
        }
        // #14. Отримати перелік машин, відсортовані за роком випуску (спадання) з діапазоном років випуску автомобілів
         public IEnumerable<Vehicle> SortVehiclesByModelYearDescendingWithBoundaries(IEnumerable<Vehicle> vehicles, int startYear, int endYear)
        {
            XDocument vehicleDoc = XDocument.Load(_vehicle);
            var sortedVehicles = from vehicle in vehicleDoc.Descendants("Vehicle")
                                 let yearOfManufacture =
                                 (int)vehicle.Element("YearOfManufacture")
                                 where yearOfManufacture >= startYear &&
                                 yearOfManufacture <= endYear
                                 orderby yearOfManufacture descending
                                 select new Vehicle
                                 {
                                     VehicleId = (int)vehicle.Element("VehicleId"),
                                     Brand = (string)vehicle.Element("Brand"),
                                     Model = (string)vehicle.Element("Model"),
                                     YearOfManufacture =
                                 (int)vehicle.Element("YearOfManufacture")
                                 };
            if (!sortedVehicles.Any())
            {
                Console.WriteLine($"No vehicles found manufactured between { startYear} and { endYear}.");
            }
            else
            {
                Console.WriteLine($"Vehicles sorted by model year (descending) between { startYear} and { endYear}:");
            foreach (var vehicle in sortedVehicles)
                {
                    Console.WriteLine($"Vehicle ID: {vehicle.VehicleId}, Brand:
                    { vehicle.Brand}, Model: { vehicle.Model}, Year of Manufacture:
                    { vehicle.YearOfManufacture}");
            }
            }
            return sortedVehicles;
        }

        // #15. Отримати перелік водіїв без машин
        public IEnumerable<Driver> FindDriversWithoutVehicles(IEnumerable<Driver> drivers, IEnumerable<VehicleDriver> vehicleDrivers)
        {
            XDocument driverDoc = XDocument.Load(_driver);
            XDocument vehicleDriverDoc = XDocument.Load(_vehicleDriver);
            var driversWithVehicles = from vd in
            vehicleDriverDoc.Descendants("VehicleDriver")
                                      select (int)vd.Element("DriverId");
            var driversWithoutVehicles = from driver in
            driverDoc.Descendants("Driver")
                                         where
                                         !driversWithVehicles.Contains((int)driver.Element("DriverId"))
                                         select new Driver
                                         {
                                             DriverId = (int)driver.Element("DriverId"),
                                             FirstName = (string)driver.Element("FirstName"),
                                             LastName = (string)driver.Element("LastName"),
                                             Patronymic = (string)driver.Element("Patronymic"),
                                         };
            Console.WriteLine("Drivers without vehicles:");
            foreach (var driver in driversWithoutVehicles)
            {
                Console.WriteLine($"Driver ID: {driver.DriverId}, Name:
                { driver.FirstName}
                { driver.LastName}
                { driver.Patronymic}");
            }
            return driversWithoutVehicles;
        }

        // #16. Отримати середній вік водіїв
        public double GetAverageAgeOfDrivers(IEnumerable<Driver> drivers)
        {
            XDocument driverDoc = XDocument.Load(_driver);
            double totalAge = drivers.Sum(driver =>
            {
                var driverElement = driverDoc.Descendants("Driver").FirstOrDefault(d =>
                                    (int)d.Element("DriverId") == driver.DriverId);
                if (driverElement != null)
                {
                    var dateOfBirthString = (string)driverElement.Element("DateOfBirth");
                    DateTime dateOfBirth;
                    if (DateTime.TryParseExact(dateOfBirthString, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth))
                    {
                        return (DateTime.Now - dateOfBirth).TotalDays / 365.25;
                    }
                }
                return 0;
            });

            double averageAge = totalAge / drivers.Count();
            Console.WriteLine($"Average age of drivers: {averageAge}");
            return averageAge;
        }
        // #17. Отримати перелік водіїв молодше певного віку
        public IEnumerable<Driver>
        GetDriversYoungerThanAge(IEnumerable<Driver> drivers, int maxAge)
        {
            XDocument driverDoc = XDocument.Load(_driver);
            var currentDate = DateTime.Now;
            var maxDateOfBirth = currentDate.AddYears(-maxAge);
            var driversYoungerThanAge = drivers.Where(driver =>
            {
                var driverElement = driverDoc.Descendants("Driver").FirstOrDefault(d =>
                                    (int)d.Element("DriverId") == driver.DriverId);
                if (driverElement != null)
                {
                    var dateOfBirthString =
                    (string)driverElement.Element("DateOfBirth");
                    DateTime dateOfBirth;
                if (DateTime.TryParseExact(dateOfBirthString, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth))
                    {
                        return dateOfBirth > maxDateOfBirth;
                    }
                }
                return false;
            });
            Console.WriteLine($"Drivers younger than {maxAge}:");
            foreach (var driver in driversYoungerThanAge)
            {
                Console.WriteLine($"Driver: {driver.FirstName} {driver.LastName},
                Date of Birth: { driver.DateOfBirth}");
            }
            return driversYoungerThanAge;
        }
        // #18. Отримати список автомобілів, що були зареєстровані у якомусь році
        public IEnumerable<string> GetVehiclesRegisteredInYear(IEnumerable<Vehicle> vehicles, IEnumerable<Registration> registrations, int registrationYear)
        {
            XDocument registrationDoc = XDocument.Load(_registration);
            XDocument vehicleDoc = XDocument.Load(_vehicle);
            var vehiclesRegisteredInYear = from registration in
            registrationDoc.Descendants("Registration")
                                           where
                                           DateTime.ParseExact(registration.Element("RegistrationDate").Value,
                                           "dd.MM.yyyy", CultureInfo.InvariantCulture).Year == registrationYear
                                           join vehicle in vehicleDoc.Descendants("Vehicle")
                                           on (int)registration.Element("VehicleId") equals
                                           (int)vehicle.Element("VehicleId")
                                           select $"{vehicle.Element("Brand").Value}
                                            { vehicle.Element("Model").Value}";

            Console.WriteLine($"Vehicles registered in {registrationYear}:");
            foreach (var vehicle in vehiclesRegisteredInYear)
            {
                Console.WriteLine($"Vehicle: {vehicle}");
            }
            return vehiclesRegisteredInYear;
        }

        // #19. Отримати список водіїв, що народилися у конкретному році
        public IEnumerable<Driver> GetDriversBornInYear(IEnumerable<Driver> drivers, int birthYear)
        {
            XDocument driverDoc = XDocument.Load(_driver);
            var driversBornInYear = from driver in
            driverDoc.Descendants("Driver")
                                    let dateOfBirth =
                                    DateTime.ParseExact((string)driver.Element("DateOfBirth"), "dd.MM.yyyy",
                                    CultureInfo.InvariantCulture)
                                    where dateOfBirth.Year == birthYear
                                    select new Driver
                                    {
                                        DriverId = (int)driver.Element("DriverId"),
                                        FirstName = (string)driver.Element("FirstName"),
                                        LastName = (string)driver.Element("LastName"),
                                        Patronymic = (string)driver.Element("Patronymic"),
                                        DateOfBirth = dateOfBirth
                                    };
            Console.WriteLine($"Drivers born in {birthYear}:");
            foreach (var driver in driversBornInYear)
            {
                Console.WriteLine($"Driver: {driver.FirstName} {driver.LastName},
                Date of Birth: { driver.DateOfBirth}");
            }
            return driversBornInYear;
        }
        // #20. Отримати список автомобілів, які належать власнику з конкретним ID
        public IEnumerable<(string Brand, string Model)> GetCarsOwnedByOwner(IEnumerable<Vehicle> vehicles,
        IEnumerable<Owner> owners, IEnumerable<VehicleOwnership>
        vehicleOwnerships, int ownerId)
            {
                XDocument vehicleDoc = XDocument.Load(_vehicle);
                XDocument ownershipDoc = XDocument.Load(_vehicleOwnership);
                var ownerCar = from ownership in
                ownershipDoc.Descendants("VehicleOwnership")
                            join vehicle in vehicleDoc.Descendants("Vehicle") on
                            (int)ownership.Element("VehicleId") equals (int)vehicle.Element("VehicleId")
                            where (int)ownership.Element("OwnerId") == ownerId
                            select (Brand: (string)vehicle.Element("Brand"), Model:
                            (string)vehicle.Element("Model"));
                Console.WriteLine($"Cars owned by Owner ID {ownerId}:");
                foreach (var car in ownerCar)
                {
                    Console.WriteLine($"Brand: {car.Brand}, Model: {car.Model}");
                }
                return ownerCar;
            }
    }
}
