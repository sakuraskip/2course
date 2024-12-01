using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
#pragma warning disable SYSLIB0011
namespace lab13
{
    interface ISerialize<T>
    {
        void Serialize(string filename, T ship);
        void Deserialize(string filename);

    }

    //public class SoapSerializer1<T> : ISerialize<T>
    //{
    //    public void Serialize(string filename, T ship)
    //    {
    //        SoapFormatter sp = new SoapFormatter();
    //        using (Stream sw = new FileStream(filename, FileMode.Create))
    //        {
    //            sp.Serialize(sw, ship);
    //        }
    //    }
    //    public void Deserialize(string filename)
    //    {
    //        SoapFormatter sp = new SoapFormatter();
    //        using (Stream sw = new FileStream(filename, FileMode.Open))
    //        {
    //            var ship = (object)sp.Deserialize(sw);
    //            Console.WriteLine(ship.ToString());
    //        }
    //    }
    
        public class BinSerializer<T> : ISerialize<T>
        {

            public void Serialize(string filename, T ship)
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (Stream sw = new FileStream(filename, FileMode.Create))
                {
                    bf.Serialize(sw, ship);
                    Console.WriteLine("binserialize");
                }

            }
            public void Deserialize(string filename)
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (Stream sw = new FileStream(filename, FileMode.Open))
                {
                    var ship = (object)bf.Deserialize(sw);
                    Console.WriteLine($"{ship.ToString()}");
                }
            }
        }
        public class XmlSerializer<T> : ISerialize<T> where T : Vehicle
        {
            public void Serialize(string filename, T ship)
            {
                Type type = ship.GetType();

                XmlSerializer xmlSerializer = new XmlSerializer(type);
                using (Stream sw = new FileStream(filename, FileMode.Create))
                {
                    xmlSerializer.Serialize(sw, ship);
                    Console.WriteLine("xmlserialize");
                }
            }
            public void Deserialize(string filename)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                using (FileStream sw = new FileStream(filename, FileMode.Open))
                {
                    T? ship = xmlSerializer.Deserialize(sw) as T;
                    Console.WriteLine(ship.ToString());
                }
            }
        }
        public class JsonSerializer<T> : ISerialize<T>
        {
            public void Serialize(string filename, T ship)
            {
                using (Stream sw = new FileStream(filename, FileMode.Create))
                {
                    JsonSerializer.Serialize(sw, ship);
                    Console.WriteLine("jsonserialize");
                }

            }
            public void Deserialize(string filename)
            {
                using (Stream sw = new FileStream(filename, FileMode.Open))
                {
                    var ship = JsonSerializer.Deserialize<object>(sw);
                    Console.WriteLine(ship.ToString());
                }
            }
        }
        public class CollectionSerializer<T>
        {
            public void Serialize(string filename, List<T> ships)
            {
                string serializer = JsonSerializer.Serialize(ships, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filename, serializer);
                Console.WriteLine("collectionserializer");
            }
            public void Deserialize(string filename)
            {
                string jsontext = File.ReadAllText(filename);
                List<T> list = JsonSerializer.Deserialize<List<T>>(jsontext);
                foreach (var ship in list)
                {
                    Console.WriteLine(ship.ToString());
                }
            }
        }
    }


