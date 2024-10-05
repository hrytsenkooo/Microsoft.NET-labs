using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;
namespace laba2.Add
{
    public class VehicleXml
    {
        private readonly string _path =
        "C:\\Users\\User\\source\\repos\\laba2\\laba2\\XML\\Vehicle.xml";
        private readonly Data _data;
        public void CreateDoc(Vehicle vehicle)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            using (XmlWriter writer = XmlWriter.Create(_path, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Vehicles");
                writer.WriteStartElement("Vehicle");
                writer.WriteElementString("VehicleId", vehicle.VehicleId.ToString());
                writer.WriteElementString("Brand", vehicle.Brand);
                writer.WriteElementString("Manufacturer", vehicle.Manufacturer);
                writer.WriteElementString("Model", vehicle.Model);
                writer.WriteElementString("BodyType", vehicle.BodyType);
                writer.WriteElementString("YearOfManufacture",
                vehicle.YearOfManufacture.ToString());
                writer.WriteElementString("ChassisNumber",
                vehicle.ChassisNumber);
                writer.WriteElementString("Color", vehicle.Color);
                writer.WriteElementString("LicensePlate", vehicle.LicensePlate);
                writer.WriteElementString("TechnicalCondition",
                vehicle.TechnicalCondition);
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
            }
            Console.WriteLine("XML created");
        }
        public void addElem(Vehicle vehicle)
        {
            XDocument xdoc = XDocument.Load(_path);
            XElement? root = xdoc.Element("Vehicles");
            if (root != null)
            {
                root.Add(new XElement("Vehicle",
                new XElement("VehicleId", vehicle.VehicleId.ToString()),
                new XElement("Brand", vehicle.Brand),
                new XElement("Manufacturer", vehicle.Manufacturer),
                new XElement("Model", vehicle.Model),
                new XElement("BodyType", vehicle.BodyType),
                new XElement("YearOfManufacture",
                vehicle.YearOfManufacture.ToString()),
                new XElement("ChassisNumber", vehicle.ChassisNumber),
                new XElement("Color", vehicle.Color),
                new XElement("LicensePlate", vehicle.LicensePlate),
                new XElement("TechnicalCondition",
                vehicle.TechnicalCondition)));
                xdoc.Save(_path);
            }
            Console.WriteLine("XML element added");
        }
        public void returnAll()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(_path);
            XmlElement? xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        Console.WriteLine($"{childnode.Name}: { childnode.InnerText}");
                    }
                    Console.WriteLine();
                }
            }
        }
        public void ReadXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Vehicle>),
            new XmlRootAttribute("Vehicles"));
            List<Vehicle> existingVehicles;
            using (FileStream fs = new FileStream(_path, FileMode.Open))
            {
                existingVehicles = (List<Vehicle>)serializer.Deserialize(fs);
            }
            foreach (var vehicle in existingVehicles)
            {
                Console.WriteLine($"VehicleId: {vehicle.VehicleId}");
                Console.WriteLine($"Brand: {vehicle.Brand}");
                Console.WriteLine($"Manufacturer: {vehicle.Manufacturer}");
                Console.WriteLine($"Model: {vehicle.Model}");
                Console.WriteLine($"BodyType: {vehicle.BodyType}");
                Console.WriteLine($"YearOfManufacture: { vehicle.YearOfManufacture}");
                Console.WriteLine($"ChassisNumber: {vehicle.ChassisNumber}");
                Console.WriteLine($"Color: {vehicle.Color}");
                Console.WriteLine($"LicensePlate: {vehicle.LicensePlate}");
                Console.WriteLine($"TechnicalCondition: { vehicle.TechnicalCondition}");
                Console.WriteLine();
            }
        }
    }
}
