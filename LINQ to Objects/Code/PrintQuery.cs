using System;
using System.Collections.Generic;
using System.Linq;

namespace laba1
{
    public class PrintAndQueriesConnector
    {
        private Queries _qryExecutor;
        private ConsolePrint _printer;
        private Data _dataLists;

        public PrintAndQueriesConnector(Queries qryExecutor, ConsolePrint printer, Data dataLists)
        {
            this._qryExecutor = qryExecutor;
            this._printer = printer;
            this._dataLists = dataLists;
        }

        public void PrintAllVehicles()
        {
            _printer.Print("всі машини типу кузову SUV", 
                _qryExecutor.GetSedanVehicles(_dataLists.Vehicles));
        }

        public void PrintAllVehiclesWithOwners()
        {
            _printer.Print("машини типу кузову SUV та ім'я власників", 
                _qryExecutor.GetAllSUVsWithOwners(_dataLists.Vehicles, 
                _dataLists.Owners, _dataLists.VehicleOwnerships));
        }

        public void PrintMachinesInExcellentCondition()
        {
            _printer.Print("машини з жахливим технічним станом", 
                _qryExecutor.GetMachinesInExcellentCondition(_dataLists.Vehicles));
        }

        public void PrintOwnersWithinAgeRange(int minYear, int maxYear)
        {
            _printer.Print($"власники з віком від {minYear} до {maxYear}", 
                _qryExecutor.GetOwnersWithinAgeRange(_dataLists.Owners, minYear, maxYear));
        }

        public void PrintDriverWithLongestName()
        {
            var driverWithLongestName = 
                _qryExecutor.GetDriverWithLongestName(_dataLists.Drivers);
            _printer.Print("водій з найдовшим ім'ям", new List<Driver> { driverWithLongestName });
        }

        public void PrintVehicleWithEarliestManufactureYear()
        {
            var vehicleWithEarliestYear = 
                _qryExecutor.GetVehicleWithEarliestManufactureYear(_dataLists.Vehicles);
            _printer.Print("найстаріша машина (за роком випуску):", 
                new List<Vehicle> { vehicleWithEarliestYear });
        }

        public void PrintDriversSortedByDateOfBirthAscendingWithBoundaries(int startYear, int endYear)
        {
            _printer.Print($"відсортовані водії за датою народження в порядку зростання з роками народження від {startYear} до {endYear}", 
                _qryExecutor.SortDriversByDateOfBirthAscendingWithBoundaries(_dataLists.Drivers, startYear, endYear));
        }

        public void PrintUnregisteredVehicles()
        {
            var unregisteredVehiclesQuery = from vehicle in _dataLists.Vehicles
                                            where !_dataLists.Registrations.Any(registration => 
                                                registration.VehicleId == vehicle.VehicleId)
                                            select vehicle;
            var unregisteredVehicles = unregisteredVehiclesQuery.ToList();
            _printer.Print("незареєстровані автомобілі:", unregisteredVehicles);
        }

        public void PrintMachinesReleasedBeforeYear(int year)
        {
            _printer.Print($"машини, випущені до {year} року включно", 
                _qryExecutor.GetMachinesReleasedBeforeYear(_dataLists.Vehicles, year));
        }

        public void PrintAllVehiclesRegisteredInLocalOffice()
        {
            var vehiclesRegisteredInLocalOffice = 
                _qryExecutor.GetVehiclesRegisteredInLocalOffice(_dataLists.Vehicles, _dataLists.Registrations);
            _printer.Print("машини, зареєстровані в місцевому реєстраційному офісі:", vehiclesRegisteredInLocalOffice);
        }

        public void PrintAllVehiclesNotDrivenByDrivers()
        {
            var vehiclesNotDrivenByDrivers = 
                _qryExecutor.GetVehiclesNotDrivenByDrivers(_dataLists.Vehicles, _dataLists.Drivers, _dataLists.VehicleDrivers);
            _printer.Print("машини, які не керуються жодним водієм:", vehiclesNotDrivenByDrivers);
        }

        public void PrintUniqueOwnersAndDriversNames()
        {
            _printer.Print("унікальні власники машин та водії, об'єднані за іменами", 
                _qryExecutor.GetUniqueOwnersAndDriversNames(_dataLists.Owners, _dataLists.Drivers));
        }

        public void PrintOwnersWithMultipleVehicles()
        {
            _printer.Print("власники, що мають декілька машин", 
                _qryExecutor.GetOwnersWithMultipleVehicles(_dataLists.Owners, _dataLists.VehicleOwnerships));
        }

        public void PrintVehiclesSortedByModelYearDescendingWithBoundaries(int startYear, int endYear)
        {
            _printer.Print($"машини, відсортовані за роком випуску у спадаючому порядку з роками випуску від {startYear} до {endYear}", 
                _qryExecutor.SortVehiclesByModelYearDescendingWithBoundaries(_dataLists.Vehicles, startYear, endYear));
        }

        public void PrintDriversWithoutVehicles()
        {
            _printer.Print("водії без машин", 
                _qryExecutor.FindDriversWithoutVehicles(_dataLists.Drivers, _dataLists.VehicleDrivers));
        }

        public void PrintAverageAgeOfDrivers()
        {
            double averageAge = _qryExecutor.GetAverageAgeOfDrivers(_dataLists.Drivers);
            _printer.Print("середній вік водіїв", new List<double> { averageAge });
        }

        public void PrintDriversYoungerThanAge(int maxAge)
        {
            _printer.Print($"водії молодше {maxAge} років", 
                _qryExecutor.GetDriversYoungerThanAge(_dataLists.Drivers, maxAge));
        }

        public void PrintVehiclesRegisteredInYear(int registrationYear)
        {
            var vehiclesRegisteredInYear = 
                _qryExecutor.GetVehiclesRegisteredInYear(_dataLists.Vehicles, _dataLists.Registrations, registrationYear);
            _printer.Print($"автомобілі, зареєстровані у {registrationYear} році:", vehiclesRegisteredInYear);
        }

        public void PrintDriversBornInYear(int birthYear)
        {
            _printer.Print($"водії, народжені у {birthYear} році", 
                _qryExecutor.GetDriversBornInYear(_dataLists.Drivers, birthYear));
        }

        public void PrintCarsOwnedByOwner(int ownerId)
        {
            var carsOwnedByOwner = 
                _qryExecutor.GetCarsOwnedByOwner(_dataLists.Vehicles, _dataLists.Owners, _dataLists.VehicleOwnerships, ownerId);
            _printer.Print($"автомобілі, що належать власнику з ID {ownerId}:", carsOwnedByOwner);
        }
    }
}
