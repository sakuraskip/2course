using System.Diagnostics;
namespace lab4
{
    public class Program
    {
        static void Main(string[] args)
        {

            Captain boatCaptain = new Captain {Name =
                "олег",Age = 32 };
            Boat boat = new Boat {Name = "лодка1",Speed = 41,Team = 2,Captain = boatCaptain };
            boat.IsMoving(); boat.CanShoot();

            Captain steamshipCap = new Captain { Name = "серега",Age = 45 };
            Ship steamship = new Steamship { Name = "крутой пароход", Speed = 0, Team = 15, Captain = steamshipCap,Seats = 133 };
            Ship steamship1 = new Steamship { Name = "крутой пароход2", Speed = 0, Team = 15, Captain = steamshipCap, Seats = 21 };
            Ship steamship2 = new Steamship { Name = "крутой пароход3", Speed = 0, Team = 15, Captain = steamshipCap, Seats = 94 };


            Captain sailboatCap = new() { Age = 31, Name = "андрей" };
            Captain sailboatCap1 = new Captain { Age = 24, Name = "серж" };
            Sailboat sailboat = new Sailboat { Captain = sailboatCap, Name = "крутой парусник", Displacement = 34, Speed = 10, Team = 3 };
            Sailboat sailboat1 = new Sailboat { Captain = sailboatCap1, Name = "крутой парусник1", Displacement = 45, Speed = 10, Team = 3 };

            steamship.IsMoving(); steamship.CanShoot();

            Corvette corvette = new Corvette { Captain = steamshipCap,Speed=59,Team=30,Name="корабль3000" };
            Ship vehicle1 = boat;
            Console.WriteLine(vehicle1.ToString());


            var shipContainer = new ShipContainer();
            var shipController = new ShipController(shipContainer);


            shipContainer.AddShip(corvette);
            shipContainer.AddShip(steamship2);
            shipContainer.AddShip(sailboat);
            shipContainer.AddShip(steamship1);
            shipContainer.AddShip(sailboat1);

            unknownShip unkship = new() { Speed = 10 };

            unkship.IsMoving();
            ((IInfo)unkship).IsMoving();


            if(vehicle1 is Boat)
            {
                Console.WriteLine($"vehicle1 это лодка");
            }

            Console.WriteLine();

            var printerTest = new IInfo[] { boat, steamship, vehicle1, corvette };

            foreach(var printer in printerTest )
            {
                Printer.IAmPrinting(printer);
            }
            Console.WriteLine();


            int averageDisplacement = shipController.GetAverageDisplacement();
            Console.WriteLine($"среднее водоизмещение парусников: {averageDisplacement}");
            int averageSeats = shipController.GetAvereageSeats();
            Console.WriteLine($"средняя вместимость пароходов: {averageSeats}");
            shipController.GetYoungCapitans();
            Console.WriteLine();
            
            

            bool trying = true;
            try
            {
                sailboat.Speed = 1000;
            }
            catch (NotValidSpeed ex)
            {
                ExceptionHandle.HandleException(ex);
            }
            try
            {
                steamshipCap.Age = 100;
            }
            catch (NotValidAge ex)
            {
                ExceptionHandle.HandleException(ex);
            }
            try
            {
                sailboat1.Displacement = -123;
            }
            catch (NotValidDisplacement ex) 
            {
                ExceptionHandle.HandleException(ex);
            }
            try
            {
                steamship2.Team = 1313121;
            }
            catch (NotValidTeam ex)
            {
                ExceptionHandle.HandleException(ex);
            }
            try
            {
                var excptnTest = printerTest[10];
            }
            catch (Exception ex) when (ex.GetType()!=typeof(NotValidTeam))
            {
                ExceptionHandle.HandleException(ex);
            }
            finally
            {
                trying = false;
                Console.WriteLine("все обработал....");
            }


        }
    }
}
