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
    public class DriverXml
    {
        private readonly string _path =
        "C:\\Users\\User\\source\\repos\\laba2\\laba2\\XML\\Driver.xml";
        private readonly Data _data;
        public DriverXml(Data data)
        {
            _data = data;
        }
        public void CreateDoc(Driver driver)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            using (XmlWriter writer = XmlWriter.Create(_path, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Drivers");
                writer.WriteStartElement("Driver");
                writer.WriteElementString("DriverId", driver.DriverId.ToString());
                writer.WriteElementString("LastName", driver.LastName);
                writer.WriteElementString("FirstName", driver.FirstName);
                writer.WriteElementString("Patronymic", driver.Patronymic);
                writer.WriteElementString("DateOfBirth",
                driver.DateOfBirth.ToString("dd.MM.yyyy"));
                writer.WriteElementString("RegistrationAddress",
                driver.RegistrationAddress);
                writer.WriteElementString("LicenseNumber", driver.LicenseNumber);
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
            }
            Console.WriteLine("XML created");
        }
        public void AddElem(Driver driver)
        {
            XDocument xdoc = XDocument.Load(_path);
            XElement? root = xdoc.Element("Drivers");
            if (root != null)
            {
                root.Add(new XElement("Driver",
                new XElement("DriverId", driver.DriverId.ToString()),
                new XElement("LastName", driver.LastName),
                new XElement("FirstName", driver.FirstName),
                new XElement("Patronymic", driver.Patronymic),
                new XElement("DateOfBirth", driver.DateOfBirth.ToString("dd.MM.yyyy")),
                new XElement("RegistrationAddress", driver.RegistrationAddress),
                new XElement("LicenseNumber", driver.LicenseNumber)));
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
                        Console.WriteLine($"{childnode.Name}: { childnode.InnerText}");
                    }
                    Console.WriteLine();
                }
            }
        }
        public void ReadXml()
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Drivers";
            xRoot.IsNullable = true;
            XmlSerializer formatter = new XmlSerializer(typeof(List<Driver>), xRoot);
            List<Driver> existingDrivers;
            using (System.IO.FileStream fs = new System.IO.FileStream(_path,
            System.IO.FileMode.Open))
            {
                existingDrivers = (List<Driver>)formatter.Deserialize(fs);
            }
            foreach (var driver in existingDrivers)
            {
                Console.WriteLine($"DriverId: {driver.DriverId}");
                Console.WriteLine($"LastName: {driver.LastName}");
                Console.WriteLine($"FirstName: {driver.FirstName}");
                Console.WriteLine($"Patronymic: {driver.Patronymic}");
                Console.WriteLine($"DateOfBirth: {driver.DateOfBirth}");
                Console.WriteLine($"RegistrationAddress: { driver.RegistrationAddress}");
                Console.WriteLine($"LicenseNumber: {driver.LicenseNumber}");
                Console.WriteLine();
            }
        }
    }
}