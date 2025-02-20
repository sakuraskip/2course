using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab15
{
    public class Parallel1
    {
        public static async Task task8_1()
        {
            Console.WriteLine("начало асинхронного движа");
            await task8async();
            Console.WriteLine("асинхронный движ закончился");
        }
         public static async Task task8async()
        {
            await Task.Delay(3000);
            Console.WriteLine("симуляция долгой подгрузки");
        }
        public static void task5()
        {
            int size = 100000000;
            int[] array = new int[size];
            Random rand = new Random();
            void fillArray(int n)
            {
                array[n] = rand.Next();
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.For(0, size, fillArray);

            Console.WriteLine($"время работы параллельного for: {stopwatch.Elapsed}");
            stopwatch.Start();

            for (int i=0;i< size;i++)
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
            Parallel.Invoke(PrintFirst, PrintThird, PrintSecond);
        }
    }
   
}
