using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public static class ExceptionHandle
    {
        public static void HandleException(Exception ex)
            {
            Console.WriteLine($"Исключение: {ex.Message}");
            Console.WriteLine($"место возникновения: {ex.StackTrace}");
            Console.WriteLine($"почему?: {ex.GetType().Name}");
        }
}
    public class ShipException : Exception
    {
        public ShipException()
        { }
        public ShipException(string message)
            : base(message)
        { }
    }
    public class NotValidSpeed : ShipException
    {
        public NotValidSpeed() { }

        public NotValidSpeed(string message)
            : base(message)
        { }
    }
    public class NotValidTeam : ShipException
    {
        public NotValidTeam() { }

        public NotValidTeam(string message)
            : base(message) { }
    }
    public class NotValidDisplacement : ShipException
    {
        public NotValidDisplacement() { }

        public NotValidDisplacement(string message)
            : base(message) { }
    }
    public class NotValidAge : ShipException
    {
        public NotValidAge() { }

        public NotValidAge(string message)
            : base(message) { }
    }

}
