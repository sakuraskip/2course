using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class ShipController
    {
        private ShipContainer _container;

        public ShipController(ShipContainer container)
        {
            _container = container;
        }
        public int GetAverageDisplacement()
        {
            int result = 0;
            int sailboatAmount = 0;
            foreach (var ship in _container.Port)
            {
                if (ship is Sailboat sailboat)
                {
                    sailboatAmount++;
                    result += sailboat.Displacement;
                }
            }
            if (sailboatAmount <= 0)
            {
                return result;
            }
            return (result / sailboatAmount);
        }
        public int GetAvereageSeats()
        {
            int result = 0;
            int steamshipAmount = 0;
            foreach(var ship in _container.Port)
            {
                if(ship is Steamship steamship)
                {
                    steamshipAmount++;
                    result += steamship.Seats;
                }
            }
            return (result/steamshipAmount);
        }
        public void GetYoungCapitans()
        {
            Console.WriteLine($"Список кораблей с капитанами младше 35: ");
            foreach (var ship in _container.Port)
            {
                if(ship.Captain.Age <35)
                {
                    Console.WriteLine(ship.ToString());
                }
            }
        }
    }
   
    public class ShipContainer
    {
        public List<Ship> Port { get; set; }

        public ShipContainer()
        {
            Port = new List<Ship>();
        }
        public void AddShip(Ship ship)
        {
            Port.Add(ship);
        }
        public void RemoveShip(Ship ship)
        {
            Port.Remove(ship);
        }
        public void PrintShipList()
        {
            Console.WriteLine("список: ");
            foreach (Ship ship in Port)
            {
                Console.WriteLine(ship.ToString());
            }
        }






    }
}
