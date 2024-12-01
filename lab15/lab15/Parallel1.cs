using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab15
{
    public class Parallel1
    {
        public static void task5()
        {
            int[] array = new int[1000000000];
            Random rand = new Random();
            void fillArray(int n)
            {
                array[n] = rand.Next();
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.For(0, 1000000000, fillArray);

            Console.WriteLine($"время работы параллельного for: {stopwatch.Elapsed}");
            stopwatch.Start();

            for (int i=0;i< 1000000000;i++)
            {
                array[i] = rand.Next();
            }
            stopwatch.Stop();
            Console.WriteLine($"время работы непараллельного for: {stopwatch.Elapsed}");
        }
        public static void task6()
        {
            void PrintFirst()
            {
                Console.WriteLine("первый метод????!!!!");
            }
            void PrintSecond()
            {
                Console.WriteLine("а вы знаете что такое бипки???");
            }
            void PrintThird()
            {
                Console.WriteLine("я тону на земле..... рубикон");
            }
            Parallel.Invoke(PrintFirst, PrintSecond, PrintThird);
        }
    }
}
