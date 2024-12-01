using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace lab14
{
    public class Threads
    {
        public static bool thread1turn = true;
        public static DateTime newyear;

        public static void task5()
        {
            newyear = new DateTime(DateTime.Now.Year + 1, 1, 1, 0, 0, 0);
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += PrintTimer;
            timer.AutoReset = true;
            timer.Start();

            Console.ReadLine();
            timer.Stop();

        }
        public static void PrintTimer(Object s, ElapsedEventArgs e)
        {
            TimeSpan remaining = newyear - DateTime.Now;

            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"до нового года осталось: {remaining.Days} дней,{remaining.Hours} часа(-ов),{remaining.Minutes} минут," +
                $"{remaining.Seconds} секунд(-ы)");
        }
        public static void getinfo()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}, {Thread.CurrentThread.ManagedThreadId}" +
                            $"{Thread.CurrentThread.Priority}, {Thread.CurrentThread.ThreadState}");
        }
        public static void task3(int n)
        {
            Thread thread = new Thread(task3output);
            thread.Name = "task3";
            thread.Start();

            void task3output()
            {
                for(int i=0;i < n;i++)
                {
                    if(i%3 == 0)
                    {
                        Console.WriteLine("число очень простое");
                        getinfo();
                    }
                    Thread.Sleep(100);
                }
            }
        }
        public static void task4(int n)
        {
            
            StreamWriter writer = new StreamWriter("file.txt");
            Thread thread1 = new Thread(task4_1);
            Thread thread2 = new Thread(task4_2);

            thread1.Priority = ThreadPriority.Highest;
            thread1.Start();
            thread2.Start();

            void task4_1()
            {
                for(int i=0;i<=n;i+=2)
                {
                    while(!thread1turn)
                    {
                        Thread.Sleep(20);
                    }
                        Console.WriteLine(i);
                        writer.WriteLine(i);
                    
                    Thread.Sleep(100);
                    thread1turn = false;
                }
            }
            void task4_2()
            {
                //thread1.Join(); task b-1
                for (int i = 1; i <= n; i+=2)
                {
                    while(thread1turn)
                    {
                        Thread.Sleep(20);
                    }
                    
                        Console.WriteLine(i);
                        writer.WriteLine(i);
                    
                    Thread.Sleep(400);
                    thread1turn = true;
                }
            }
        }

    }
}
