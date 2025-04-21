using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace lab4
{
    public struct ActionItem
    {
        public string Action { get; set; }
        public Ship Ship { get; set; }

        public ActionItem(string action, Ship ship)
        {
            Action = action;
            Ship = ship;
        }
    }
    public class Request
    {

    }
    public class Ship
    {
        public int id {  get; set; }
        public string Name {  get; set; }
        public string Description { get; set; }
        public string ?Photopath { get; set; }
        public string ShipType { get; set; }
        public int Price { get; set; }
        public string avaliable { get; set; }

        public Ship(int id,string name, string description, int price,string avaliable, string? photopath, string shipType)
        {
            this.id = id; 
            Name = name;
            Description = description;
            Photopath = photopath;
            ShipType = shipType;
            Price = price;
            this.avaliable = avaliable;
        }
       
    }
    [JsonObject]
    public class ShipList : List<Ship>
    {
        static string _filepath = "C:\\Users\\леха\\Desktop\\2 курс\\4sem\\лабы\\ооп\\lab4\\lab4\\ships.json";
        [JsonProperty("ship")]
        public List<Ship> ships  = new List<Ship>();
        
        public static List<Ship> LoadFromJson(string filepath)
        {
            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);
                if (string.IsNullOrEmpty(json))
                {
                    return new ShipList();
                }
                var res =  JsonConvert.DeserializeObject<ShipList>(json);
                return res.ships;
            }
            return new ShipList();
        }
        private static void SaveToJson(Ship ship)
        {
            ShipList list = new ShipList();
            list.ships = LoadFromJson(_filepath);
            list.ships.Add(ship);

            string json = JsonConvert.SerializeObject(list.ships,Formatting.Indented);
            File.WriteAllText(_filepath, json);
        }
      
    }
   
}
