using System;
using System.Collections.Generic;
using System.Linq;

namespace laba1
{
    public class Queries
    {
        // #1. Отримати усі машини та відповідно їх власників
        public IEnumerable<Vehicle> GetSedanVehicles(IEnumerable<Vehicle> vehicles)
        {
            var sedanVehicles = vehicles.Where(vehicle => vehicle.BodyType == "SUV");
            return sedanVehicles;
        }

        // #2. Отримати усі машини та відповідно їх власників
        public IEnumerable<(Vehicle vehicle, Owner owner)> GetAllSUVsWithOwners(
            IEnumerable<Vehicle> vehicles,
            IEnumerable<Owner> owners,
            IEnumerable<VehicleOwnership> vehicleOwnerships)
        {
            var suvsWithOwners = from ownership in vehicleOwnerships
                                 join vehicle in vehicles.Where(v => v.BodyType == "SUV")
                                 on ownership.VehicleId equals vehicle.VehicleId
                                 join owner in owners
                                 on ownership.OwnerId equals owner.OwnerId
                                 select (vehicle, owner);
            return suvsWithOwners;
        }

        // #3. Отримати перелік машин, що мають відмінні технічні показники
        public IEnumerable<Vehicle> GetMachinesInExcellentCondition(IEnumerable<Vehicle> vehicles)
        {
            var machinesInExcellentCondition = vehicles
                .Where(vehicle => vehicle.TechnicalCondition.Equals("Awful", StringComparison.OrdinalIgnoreCase));
            return machinesInExcellentCondition;
        }

        // #4. Отримати перелік людей (власників), вік яких входить у заданий діапазон
        public IEnumerable<Owner> GetOwnersWithinAgeRange(IEnumerable<Owner> owners, int minYear, int maxYear)
        {
            var currentDate = DateTime.Now;
            var minDateOfBirth = currentDate.AddYears(-maxYear);
            var maxDateOfBirth = currentDate.AddYears(-minYear);
            return owners.Where(owner => owner.DateOfBirth >= minDateOfBirth && owner.DateOfBirth <= maxDateOfBirth);
        }

        // #5. Отримати водія, що має найдовше ім'я
        public Driver GetDriverWithLongestName(IEnumerable<Driver> drivers)
        {
            var query = from driver in drivers
                        let nameLength = driver.FirstName.Length + driver.LastName.Length + driver.Patronymic.Length
                        orderby nameLength descending
                        select driver;
            return query.FirstOrDefault();
        }

        // #6. Отримати машину, що має найстаріший рік випуску (manufacture)
        public Vehicle GetVehicleWithEarliestManufactureYear(IEnumerable<Vehicle> vehicles)
        {
            var query = from vehicle in vehicles
                        orderby vehicle.YearOfManufacture
                        select vehicle;
            return query.FirstOrDefault();
        }

        // #7. Отримати відсортований перелік водіїв за датою народження в порядку зростання
        public IEnumerable<Driver> SortDriversByDateOfBirthAscendingWithBoundaries(
            IEnumerable<Driver> drivers, int startYear, int endYear)
        {
            return drivers.Where(driver => driver.DateOfBirth.Year >= startYear && driver.DateOfBirth.Year <= endYear)
                          .OrderBy(driver => driver.DateOfBirth);
        }

        // #8. Отримати перелік машин, що не є зареєстрованими
        public IEnumerable<Vehicle> GetUnregisteredVehicles(
            IEnumerable<Vehicle> vehicles, IEnumerable<Registration> registrations)
        {
            var unregisteredVehiclesQuery = from vehicle in vehicles
                                            where !registrations.Any(registration => registration.VehicleId == vehicle.VehicleId)
                                            select vehicle;
            return unregisteredVehiclesQuery.ToList();
        }

        // #9. Отримати перелік машин, випущених до певного року (включно)
        public IEnumerable<Vehicle> GetMachinesReleasedBeforeYear(IEnumerable<Vehicle> vehicles, int year)
        {
            return vehicles.Where(vehicle => vehicle.YearOfManufacture <= year);
        }

        // #10. Отримати машини, зареєстрованих в локації "Local Registration Office"
        public IEnumerable<(string Brand, string Model)> GetVehiclesRegisteredInLocalOffice(
            IEnumerable<Vehicle> vehicles, IEnumerable<Registration> registrations)
        {
            var vehiclesRegisteredInLocalOffice = from registration in registrations
                                                  where registration.RegistrationLocation == "Local Registration Office"
                                                  join vehicle in vehicles on registration.VehicleId equals vehicle.VehicleId
                                                  select (vehicle.Brand, vehicle.Model);
            return vehiclesRegisteredInLocalOffice;
        }

        // #11. Отримати машини, які не керуються
        public IEnumerable<(string Brand, string Model)> GetVehiclesNotDrivenByDrivers(
            IEnumerable<Vehicle> vehicles, IEnumerable<Driver> drivers, IEnumerable<VehicleDriver> vehicleDrivers)
        {
            var vehiclesNotDrivenByDrivers = from vehicle in vehicles
                                             where !drivers.Any(driver => vehicleDrivers.Any(vd => vd.VehicleId == vehicle.VehicleId && vd.DriverId == driver.DriverId))
                                             select (vehicle.Brand, vehicle.Model);
            return vehiclesNotDrivenByDrivers;
        }

        // #12. Отримати перелік всіх унікальних власників машин та водіїв, об'єднавши їх імена
        public IEnumerable<string> GetUniqueOwnersAndDriversNames(IEnumerable<Owner> owners, IEnumerable<Driver> drivers)
        {
            var ownerNames = owners.Select(owner => $"{owner.FirstName} {owner.LastName}");
            var driverNames = drivers.Select(driver => $"{driver.FirstName} {driver.LastName}");
            var uniqueNames = ownerNames.Concat(driverNames).Distinct();
            return uniqueNames;
        }

        // #13. Отримати перелік власників, що мають декілька машин
        public IEnumerable<Owner> GetOwnersWithMultipleVehicles(
            IEnumerable<Owner> owners, IEnumerable<VehicleOwnership> vehicleOwnerships)
        {
            var ownersWithMultipleVehicles = vehicleOwnerships.GroupBy(vo => vo.OwnerId)
                                                              .Where(group => group.Count() > 1)
                                                              .Select(group => owners.FirstOrDefault(owner => owner.OwnerId == group.Key));
            return ownersWithMultipleVehicles;
        }

        // #14. Отримати перелік машин, відсортовані за роком випуску (спадання) з діапазоном років випуску автомобілів
        public IEnumerable<Vehicle> SortVehiclesByModelYearDescendingWithBoundaries(
            IEnumerable<Vehicle> vehicles, int startYear, int endYear)
        {
            var sortedVehicles = vehicles.Where(vehicle => vehicle.YearOfManufacture >= startYear && vehicle.YearOfManufacture <= endYear)
                                         .OrderByDescending(vehicle => vehicle.YearOfManufacture);
            return sortedVehicles;
        }

        // #15. Отримати перелік водіїв без машин
        public IEnumerable<Driver> FindDriversWithoutVehicles(
            IEnumerable<Driver> drivers, IEnumerable<VehicleDriver> vehicleDrivers)
        {
            var driversWithVehicles = vehicleDrivers.Select(vd => vd.DriverId).Distinct();
            var driversWithoutVehicles = drivers.Where(driver => !driversWithVehicles.Contains(driver.DriverId));
            return driversWithoutVehicles;
        }

        // #16. Отримати середній вік водіїв
        public double GetAverageAgeOfDrivers(IEnumerable<Driver> drivers)
        {
            double totalAge = drivers.Sum(driver => (DateTime.Now - driver.DateOfBirth).TotalDays / 365.25);
            double averageAge = totalAge / drivers.Count();
            return averageAge;
        }

        // #17. Отримати перелік водіїв молодше певного віку
        public IEnumerable<Driver> GetDriversYoungerThanAge(IEnumerable<Driver> drivers, int maxAge)
        {
            var currentDate = DateTime.Now;
            var maxDateOfBirth = currentDate.AddYears(-maxAge);
            var driversYoungerThanAge = drivers.OrderBy(driver => driver.DateOfBirth)
                                               .SkipWhile(driver => driver.DateOfBirth <= maxDateOfBirth)
                                               .TakeWhile(driver => driver.DateOfBirth > maxDateOfBirth);
            return driversYoungerThanAge;
        }

        // #18. Отримати список автомобілів, що були зареєстровані у якомусь році
        public IEnumerable<(string Brand, string Model)> GetVehiclesRegisteredInYear(
            IEnumerable<Vehicle> vehicles, IEnumerable<Registration> registrations, int registrationYear)
        {
            var vehiclesRegisteredInYear = from registration in registrations
                                           where registration.RegistrationDate.Year == registrationYear
                                           join vehicle in vehicles on registration.VehicleId equals vehicle.VehicleId
                                           select (vehicle.Brand, vehicle.Model);
            return vehiclesRegisteredInYear;
        }

        // #19. Отримати список водіїв, що народилися у конкретному році
        public IEnumerable<Driver> GetDriversBornInYear(IEnumerable<Driver> drivers, int birthYear)
        {
            var driversBornInYear = drivers.Where(driver => driver.DateOfBirth.Year == birthYear);
            return driversBornInYear;
        }

        // #20. Отримати список автомобілів, які належать власнику з конкретним ID
        public IEnumerable<(string Brand, string Model)> GetCarsOwnedByOwner(
            IEnumerable<Vehicle> vehicles, IEnumerable<Owner> owners, IEnumerable<VehicleOwnership> vehicleOwnerships, int ownerId)
        {
            var ownerCar = from ownership in vehicleOwnerships
                           join vehicle in vehicles on ownership.VehicleId equals vehicle.VehicleId
                           where ownership.OwnerId == ownerId
                           select (vehicle.Brand, vehicle.Model);
            return ownerCar;
        }
    }
}
