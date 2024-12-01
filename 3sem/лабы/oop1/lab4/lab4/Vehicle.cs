using System;
using System.Diagnostics;
namespace lab4
{
    public interface IInfo
    {
        string Name { get; set; }
        int Speed { get; set; }
        void IsMoving();
    }
    public abstract class BaseInfo
    {
        public abstract void IsMoving();
    }
    public class unknownShip : BaseInfo, IInfo
    {
        public string Name { get; set; } = "unknown";
        public int Speed { get; set; }

        void IInfo.IsMoving()
        {
            Console.WriteLine("корабль движется через интерфейс");
        }
        public override void IsMoving()
        {
            Console.WriteLine("корабль движется через переопределенный метод");
        }
    }
    public abstract class Vehicle : IInfo
    {
        private int _speed;
        public required string Name { get; set; }
        public int Speed
        {
            get { return _speed; }
            set
            {
                if (value < -1 || value > 60)
                {
                    throw new NotValidSpeed("скорость должна быть от 0 до 60");
                }
                _speed = value;
            }
        }

        public abstract void IsMoving();

        public virtual string GetDetails()
        {
            return ToString();
        }
        public override string ToString()
        {
            return $"Транспортное средство: Название:{Name}, скорость:{Speed} ";
        }
    }

    public abstract class Ship : Vehicle
    {
        private int _team;
        public int Team { get { return _team; }
            set
            {
                    if(value<0 || value >200)
                    {
                        throw new NotValidTeam("экипаж должен быть от 0 до 200");
                    }
                    _team = value;
            }
        }
        public Captain Captain { get; set; }
        public ShipType ShipType { get; set; }

        public abstract void CanShoot();
        public override string ToString()
        {
            return GetDetails();
        }
        public override string GetDetails()
        {
            return $"Тип корабля{ShipType} : Название:{Name}, скорость:{Speed},Команда: {Team}, Капитан: {Captain.Name} ";
        }

    }

    public sealed class Steamship : Ship
    {
        public Steamship()
        {
            ShipType = ShipType.Steamship;
        }
        public int Seats { get; set; }
        public override void IsMoving()
        {
            if (Speed > 0)
            {
                Console.WriteLine($"Пароход {Name} плывет со скоростью {Speed}");
            }
            else
            {
                Console.WriteLine($"Пароход {Name} не плывет");
            }
        }
        public override void CanShoot()
        {
            Console.WriteLine($"Пароход {Name} не может стрелять");
        }
        public override string ToString()
        {
            return $"Пароход: Название:{Name}, скорость:{Speed},Экипаж: {Team}, Капитан: {Captain.Name} ";
        }
    }
    public partial class Sailboat : Ship
    {
        private int _displacement;
        public int Displacement
        {
            get { return _displacement; }
            set
            {
                if(value < 0 || value > 10000)
                {
                    throw new NotValidDisplacement("водоизмещение должно быть от 0 до 10000");
                }
            }
        }
        public Sailboat()
        {
            ShipType = ShipType.Sailboat;
        }
        public override void IsMoving()
        {
            if (Speed > 0)
            {
                Console.WriteLine($"Парусник {Name} плывет со скоростью {Speed}");
            }
            else
            {
                Console.WriteLine($"Парусник {Name} не плывет");
            }
        }
        
    }
    public class Corvette : Ship
    {
        public Corvette()
        {
            ShipType = ShipType.Corvette;
        }
        public override void IsMoving()
        {
            if (Speed > 0)
            {
                Console.WriteLine($"Корвет {Name} плывет со скоростью {Speed}");
            }
            else
            {
                Console.WriteLine($"Корвет '{Name}' не плывет");
            }
        }
        public override void CanShoot()
        {
            Console.WriteLine($"Корвет '{Name}' может стрелять");
        }
        public override string ToString()
        {
            return $"Корвет: Название:{Name}, скорость:{Speed},Экипаж: {Team}, Капитан: {Captain.Name} ";
        }
    }
    public class Boat : Ship
    {
        public Boat()
        {
            ShipType = ShipType.Boat;
        }
        public override void IsMoving()
        {
            try
            {
                Debug.Assert(Speed > 40, "скорость для лодки не может быть выше 40");
                if (Speed > 0)
                {
                    Console.WriteLine($"Лодка '{Name}' плывет со скоростью {Speed}");
                }
                else
                {
                    Console.WriteLine($"Лодка '{Name}' не плывет");
                }
            }
            catch(Exception ex)
            {
                ExceptionHandle.HandleException(ex);
            }
            }
        public override void CanShoot()
        {
            Console.WriteLine($"Лодка {Name} не может стрелять");
        }
        public override string ToString()
        {
            return $"Лодка: Название:{Name}, скорость:{Speed},Экипаж: {Team},Капитан: {Captain.Name} ";
        }
    }
    public struct Captain
    {
        private string _name;
        private int _age;
        public int Age { get { return _age; }
            set
            {
              if(value < 18 ||  value >90)
                {
                    throw new NotValidAge("возраст должен быть от 18 до 90");
                }
              _age = value;
            }
        }
        
        public string Name {get { return _name;} set { _name = value; } }
        public override string ToString()
        {
            return $"Капитан: {_name}";
        }
    }
    public enum ShipType
    {
        Steamship,Sailboat,
        Corvette,Boat
    }
}