using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public partial class Sailboat : Ship
    {
        public override void CanShoot()
        {
            Console.WriteLine($"Парусник {Name} не может стрелять");
        }
        public override string ToString()
        {
            return $"Парусник: Название:{Name}, скорость:{Speed},Экипаж: {Team}, Капитан: {Captain.Name} ";
        }
    }
}
