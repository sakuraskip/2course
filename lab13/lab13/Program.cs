using System;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;

namespace lab13
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Corvette ship1 = new Corvette { Name = "1", Speed = 15, Team = 199 };
            Corvette ship2 = new Corvette { Name = "2", Speed = 45, Team = 105 };

           

            List<Corvette> list1 = new List<Corvette> { ship1, ship2 };

            CollectionSerializer<Corvette> cs = new CollectionSerializer<Corvette>();
            cs.Serialize("list1.json", list1);
            cs.Deserialize("list1.json");
            Console.WriteLine();




            JsonSerializer<Corvette> bs = new JsonSerializer<Corvette>();
            bs.Serialize("ship1.json", ship1);
            bs.Deserialize("ship1.json");
            Console.WriteLine();


            XmlSerializer<Corvette> xs = new XmlSerializer<Corvette>();
            xs.Serialize("ship1.xml", ship1);
            xs.Serialize("ship2.xml", ship2);
            xs.Deserialize("ship1.xml");

            XmlDocument xdoc1 = new XmlDocument();
            xdoc1.Load("ship1.xml");

            XmlElement? xroot = xdoc1.DocumentElement;

            XmlNodeList? nodes = xroot?.SelectNodes("*");
            foreach(XmlNode node in nodes)
            {
                Console.WriteLine(node.OuterXml);
            }
            XmlNodeList? nodes1 = xroot?.SelectNodes("ShipType");

            foreach (XmlNode node in nodes1)
            {
                Console.WriteLine(node.OuterXml);
            }

            XDocument xdoc2 = new XDocument();
            XElement ship3 = new XElement("ship1");
            XElement name = new XElement("name");
            name.Value = "брр";
            XAttribute ship1attr = new XAttribute("type", "Type2");
            ship3.Add(ship1attr);
            ship3.Add(name);

            xdoc2.Add(ship3);

            xdoc2.Save("ships.xml");
        }
    }
}
