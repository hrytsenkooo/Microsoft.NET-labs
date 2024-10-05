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
    public class OwnerXml
    {
        private readonly string _path =
        "C:\\Users\\User\\source\\repos\\laba2\\laba2\\XML\\Owner.xml";
        private readonly Data _data;
        public void CreateDoc(Owner owner)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            using (XmlWriter writer = XmlWriter.Create(_path, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Owners");
                writer.WriteStartElement("Owner");
                writer.WriteElementString("OwnerId", owner.OwnerId.ToString());
                writer.WriteElementString("LastName", owner.LastName);
                writer.WriteElementString("FirstName", owner.FirstName);
                writer.WriteElementString("Patronymic", owner.Patronymic);
                writer.WriteElementString("DateOfBirth",
                owner.DateOfBirth.ToString("dd.MM.yyyy"));
                writer.WriteElementString("RegistrationAddress",
                owner.RegistrationAddress);
                writer.WriteElementString("LicenseNumber",
                owner.LicenseNumber);
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
            }
            Console.WriteLine("XML created");
        }
        public void AddElem(Owner owner)
        {
            XDocument xdoc = XDocument.Load(_path);
            XElement? root = xdoc.Element("Owners");
            if (root != null)
            {
                root.Add(new XElement("Owner",
                new XElement("OwnerId", owner.OwnerId.ToString()),
                new XElement("LastName", owner.LastName),
                new XElement("FirstName", owner.FirstName),
                new XElement("Patronymic", owner.Patronymic),
                new XElement("DateOfBirth",
                owner.DateOfBirth.ToString("dd.MM.yyyy")),
                new XElement("RegistrationAddress",
                owner.RegistrationAddress),
                new XElement("LicenseNumber", owner.LicenseNumber)));
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
            xRoot.ElementName = "Owners";
            xRoot.IsNullable = true;
            XmlSerializer formatter = new XmlSerializer(typeof(List<Owner>), xRoot);
            List<Owner> existingOwners;
            using (System.IO.FileStream fs = new System.IO.FileStream(_path, System.IO.FileMode.Open))
            {
                try
                {
                    existingOwners = (List<Owner>)formatter.Deserialize(fs);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Error deserializing XML: " + ex.Message);
                    return;
                }
            }
            foreach (var owner in existingOwners)
            {
                Console.WriteLine($"OwnerId: {owner.OwnerId}");
                Console.WriteLine($"LastName: {owner.LastName}");
                Console.WriteLine($"FirstName: {owner.FirstName}");
                Console.WriteLine($"Patronymic: {owner.Patronymic}");
                Console.WriteLine($"DateOfBirth: {owner.DateOfBirthString}");
                Console.WriteLine($"RegistrationAddress: { owner.RegistrationAddress}");
                Console.WriteLine($"LicenseNumber: {owner.LicenseNumber}");
                Console.WriteLine();
            }
        }
    }
}
