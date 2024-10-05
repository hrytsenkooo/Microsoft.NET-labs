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
    public class RegistrationXml
    {
        private readonly string _path =
        "C:\\Users\\User\\source\\repos\\laba2\\laba2\\XML\\VehicleRegistrations.xml";
        private readonly Data _data;
        public void CreateDoc(Registration registration)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            using (XmlWriter writer = XmlWriter.Create(_path, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Registrations");
                writer.WriteStartElement("Registration");
                writer.WriteElementString("VehicleId",
                registration.VehicleId.ToString());
                writer.WriteElementString("OwnerId",
                registration.OwnerId.ToString());
                writer.WriteElementString("RegistrationDate",
                registration.RegistrationDate.ToString("dd.MM.yyyy"));
                writer.WriteElementString("RegistrationLocation",
                registration.RegistrationLocation);
                writer.WriteElementString("IsRegistered",
                registration.IsRegistered.ToString());
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
            }
            Console.WriteLine("XML created");
        }
        public void AddElem(Registration registration)
        {
            XDocument xdoc = XDocument.Load(_path);
            XElement? root = xdoc.Element("VehicleRegistrations");
            if (root != null)
            {
                root.Add(new XElement("Registration",
                new XElement("VehicleId", registration.VehicleId.ToString()),
                new XElement("OwnerId", registration.OwnerId.ToString()),
                new XElement("RegistrationDate",
                registration.RegistrationDate.ToString("dd.MM.yyyy")),
                new XElement("RegistrationLocation",
                registration.RegistrationLocation),
                new XElement("IsRegistered",
                registration.IsRegistered.ToString())));
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
            xRoot.ElementName = "VehicleRegistrations";
            xRoot.IsNullable = true;
            XmlSerializer formatter = new
            XmlSerializer(typeof(List<Registration>), xRoot);
            List<Registration> existingRegistrations;
            using (System.IO.FileStream fs = new System.IO.FileStream(_path,
            System.IO.FileMode.Open))
            {
                existingRegistrations = (List<Registration>)formatter.Deserialize(fs);
            }
            foreach (var registration in existingRegistrations)
            {
                Console.WriteLine($"VehicleId: {registration.VehicleId}");
                Console.WriteLine($"OwnerId: {registration.OwnerId}");
                Console.WriteLine($"RegistrationDate: { registration.RegistrationDate:yyyy - MM - dd}");
                Console.WriteLine($"RegistrationLocation: { registration.RegistrationLocation}");
                Console.WriteLine($"IsRegistered: {registration.IsRegistered}");
                Console.WriteLine();
            }
        }
    }
}