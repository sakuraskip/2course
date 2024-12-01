using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Printer
    {
        public static void IAmPrinting(IInfo someobj)
        {
            Console.WriteLine($"type: {someobj.GetType()}, {someobj}");
        }
    }
}
