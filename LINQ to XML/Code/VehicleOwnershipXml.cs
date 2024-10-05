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
    public class VehicleOwnershipXml
    {
        private readonly string _path =
        "C:\\Users\\User\\source\\repos\\laba2\\laba2\\XML\\VehicleOwnership.xml";
        private readonly Data _data;
        public void CreateDoc(VehicleOwnership ownership)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            using (XmlWriter writer = XmlWriter.Create(_path, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("VehicleOwnerships");
                writer.WriteStartElement("VehicleOwnership");
                writer.WriteElementString("VehicleId",
                ownership.VehicleId.ToString());
                writer.WriteElementString("OwnerId",
                ownership.OwnerId.ToString());
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
            }
            Console.WriteLine("XML created");
        }
        public void AddElem(VehicleOwnership ownership)
        {
            XDocument xdoc = XDocument.Load(_path);
            XElement? root = xdoc.Element("VehicleOwnerships");
            if (root != null)
            {
                root.Add(new XElement("VehicleOwnership",
                new XElement("VehicleId", ownership.VehicleId.ToString()),
                new XElement("OwnerId", ownership.OwnerId.ToString())));
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
            XmlSerializer(typeof(List<VehicleOwnership>), new
            XmlRootAttribute("VehicleOwnerships"));
            List<VehicleOwnership> existingVehicleOwnerships;
            using (FileStream fs = new FileStream(_path, FileMode.Open))
            {
                existingVehicleOwnerships =
                (List<VehicleOwnership>)serializer.Deserialize(fs);
            }
            foreach (var vehicleOwnership in existingVehicleOwnerships)
            {
                Console.WriteLine($"VehicleId: {vehicleOwnership.VehicleId}");
                Console.WriteLine($"OwnerId: {vehicleOwnership.OwnerId}");
                Console.WriteLine();
            }
        }
    }
}