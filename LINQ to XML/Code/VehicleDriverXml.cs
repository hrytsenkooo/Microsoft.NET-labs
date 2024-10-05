using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace laba2.Add
{
    public class VehicleDriverXml
    {
        private readonly string _path =
        "C:\\Users\\User\\source\\repos\\laba2\\laba2\\XML\\VehicleDriver.xml";
        private readonly Data _data;
        public void CreateDoc(VehicleDriver driver)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            using (XmlWriter writer = XmlWriter.Create(_path, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("VehicleDrivers");
                writer.WriteStartElement("VehicleDriver");
                writer.WriteElementString("VehicleId", driver.VehicleId.ToString());
                writer.WriteElementString("DriverId", driver.DriverId.ToString());
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
            }
            Console.WriteLine("XML created");
        }
        public void AddElem(VehicleDriver driver)
        {
            XDocument xdoc = XDocument.Load(_path);
            XElement? root = xdoc.Element("VehicleDrivers");
            if (root != null)
            {
                root.Add(new XElement("VehicleDriver",
                new XElement("VehicleId", driver.VehicleId.ToString()),
                new XElement("DriverId", driver.DriverId.ToString())));
                xdoc.Save(_path);
            }
            Console.WriteLine("XML element added");
        }
        public void ReturnAll()
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
                        Console.WriteLine($"{childnode.Name}:
                    { childnode.InnerText}
                        ");
                    }
                    Console.WriteLine();
                }
            }
        }
        public void ReadXml()
        {
            XmlSerializer serializer = new
            XmlSerializer(typeof(List<VehicleDriver>), new
            XmlRootAttribute("VehicleDrivers"));
            List<VehicleDriver> existingVehicleDrivers;
            using (FileStream fs = new FileStream(_path, FileMode.Open))
            {
                existingVehicleDrivers =
                (List<VehicleDriver>)serializer.Deserialize(fs);
            }
            foreach (var vehicleDriver in existingVehicleDrivers)
            {
                Console.WriteLine($"VehicleId: {vehicleDriver.VehicleId}");
                Console.WriteLine($"DriverId: {vehicleDriver.DriverId}");
                Console.WriteLine();
            }
        }
    }
}
