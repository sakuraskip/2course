using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lab4
{
    public struct ActionItem
    {
        public string Action { get; set; }
        public ShipModel Ship { get; set; }

        public ActionItem(string action, ShipModel ship)
        {
            Action = action;
            Ship = ship;
        }
    }
    public class Request:INotifyPropertyChanged
    {
        private int _id;
        private int _shipId;
        private int _userId;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _status;
        private int _cost;

        public Request(int id, int shipId, int userId, DateTime startDate, DateTime endDate, string status, int cost)
        {
            Id = id;
            ShipId = shipId;
            UserId = userId;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            Cost = cost;
         
        }

        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public int ShipId
        {
            get => _shipId;
            set
            {
                if (_shipId != value)
                {
                    _shipId = value;
                    OnPropertyChanged(nameof(ShipId));
                }
            }
        }

        public int UserId
        {
            get => _userId;
            set
            {
                if (_userId != value)
                {
                    _userId = value;
                    OnPropertyChanged(nameof(UserId));
                }
            }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged(nameof(StartDate));
                }
            }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged(nameof(EndDate));
                }
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public int Cost
        {
            get => _cost;
            set
            {
                if (_cost != value)
                {
                    _cost = value;
                    OnPropertyChanged(nameof(Cost));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class ShipModel:INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _description;
        private string _imagePath;
        private string _shipType;
        private int _price;
        private string _availability;

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(); }
        }

        public string ImagePath
        {
            get => _imagePath;
            set { _imagePath = value; OnPropertyChanged(); }
        }

        public string ShipType
        {
            get => _shipType;
            set { _shipType = value; OnPropertyChanged(); }
        }

        public int Price
        {
            get => _price;
            set { _price = value; OnPropertyChanged(); }
        }

        public string Availability
        {
            get => _availability;
            set { _availability = value; OnPropertyChanged(); }
        }

        public ShipModel(int id, string name, string description, int price,
                        string availability, string imagePath, string shipType)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Availability = availability;
            ImagePath = imagePath;
            ShipType = shipType;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    [JsonObject]
    public class ShipListModel : List<ShipModel>
    {
       public static string _filepath = "C:\\Users\\леха\\Desktop\\2 курс\\4sem\\лабы\\ооп\\lab4\\lab4\\ships.json";
        [JsonProperty("ship")]
        public List<ShipModel> Ships { get; set; }  =new List<ShipModel>();
        
        public static List<ShipModel> LoadFromJson(string filepath)
        {
            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);
                if (string.IsNullOrEmpty(json))
                {
                    return new ShipListModel();
                }
                var res =  JsonConvert.DeserializeObject<ShipListModel>(json);
                return res.Ships;
            }
            return new ShipListModel();
        }
        public static void SaveToJson(List<ShipModel> ships, string filePath = null)
        {
            var path = filePath ?? _filepath;
            var list = new ShipListModel { Ships = ships };
            var json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(path, json);
        }
        public static void AddShip(ShipModel ship, string filePath = null)
        {
            var ships = LoadFromJson(filePath);
            ships.Add(ship);
            //SaveToJson(ships, filePath);
        }

        public static void RemoveShip(int shipId, string filePath = null)
        {
            var ships = LoadFromJson(filePath);
            ships.RemoveAll(s => s.Id == shipId);
            //SaveToJson(ships, filePath);
        }

    }
   
}
