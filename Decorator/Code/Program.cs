using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace laba5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IPrescription> prescriptions = new List<IPrescription>
            {
            new Prescription("Smith", DateTime.Now.AddDays(30), "Take one pill daily"),
            new Prescription("Johnson", DateTime.Now.AddDays(45), "Apply ointment twice daily"),
            new Prescription("William", DateTime.Now.AddDays(60), "Rest and drink plenty of fluids"),
            new Prescription("Brown", DateTime.Now.AddDays(25), "Inhale medication once a day"),
            new Prescription("Jones", DateTime.Now.AddDays(40), "Take two tablets after meals"),
            };
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. View prescriptions");
                Console.WriteLine("2. Extend prescription expiration");
                Console.WriteLine("3. Add new prescription");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewPrescriptions(prescriptions);
                        break;
                    case "2":
                        ExtendPrescription(prescriptions);
                        break;
                    case "3":
                        AddNewPrescription(prescriptions);
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        static void ViewPrescriptions(List<IPrescription> prescriptions)
        {
            Console.WriteLine("\nAvailable prescriptions:");
            for (int i = 0; i < prescriptions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {prescriptions[i].GetPrescription()} \t\t| Expiration date: { prescriptions[i].GetExpirationDate()} \t\t | Note: { prescriptions[i].GetDoctorNote()}");
            }
        }
        static void ExtendPrescription(List<IPrescription> prescriptions)
        {
            Console.WriteLine("\nEnter the number of the prescription you want to extend: ");
            if (int.TryParse(Console.ReadLine(), out int prescriptionNumber) && prescriptionNumber > 0 && prescriptionNumber <= prescriptions.Count)
            {
                Console.WriteLine("Enter the number of days to extend the expiration: ");
            if (int.TryParse(Console.ReadLine(), out int extraDays))
                {
                    IPrescription selectedPrescription =
                    prescriptions[prescriptionNumber - 1];
                    IPrescription extendedPrescription = new
                    ExtendExpirationDecorator(selectedPrescription, extraDays);
                    prescriptions[prescriptionNumber - 1] = extendedPrescription; 
                    // Update the list with the extended prescription
                    Console.WriteLine("\n--------------------------------------------");
                    Console.WriteLine($"Previous expiration date: { selectedPrescription.GetExpirationDate()});
                    Console.WriteLine($"New expiration date: { extendedPrescription.GetExpirationDate()}");
                    Console.WriteLine($"Doctor name: { selectedPrescription.GetDoctorName()}");
                    Console.WriteLine($"Doctor's note: { extendedPrescription.GetDoctorNote()}");
                    Console.WriteLine("--------------------------------------------");
                }
                else
                {
                    Console.WriteLine("Invalid number of days.");
                }
            }
            else
            {
                Console.WriteLine("Invalid prescription number.");
            }
        }
        static void AddNewPrescription(List<IPrescription> prescriptions)
        {
            Console.Write("\nEnter the doctor's name: ");
            string doctorName = Console.ReadLine();
            Console.Write("Enter the expiration date and time (yyyy-MM-dd HH: mm): ");
            if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH: mm", null, System.Globalization.DateTimeStyles.None, out DateTime expirationDate))
            {
                Console.Write("Enter the doctor's note: ");
                string doctorNote = Console.ReadLine();
                IPrescription newPrescription = new Prescription(doctorName,
                expirationDate, doctorNote);
                prescriptions.Add(newPrescription);
                Console.WriteLine("New prescription added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid date and time format.");
            }
        }
    }
}