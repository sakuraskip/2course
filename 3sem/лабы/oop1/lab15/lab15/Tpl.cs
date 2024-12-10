using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace lab15
{
    public class Tpl
    {
        static int calcSum(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += i;
            }
            return sum;
        }
        public static void task1()
        {
            int size = 1000000;

            int[] vector = new int[size];
            Random random = new Random();
            int множитель = 2;

            CancellationTokenSource зомби = new CancellationTokenSource();
            CancellationToken token = зомби.Token;

            void multiply(int start, int end, int index)
            {
                for (int i = start; i < end; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("все выключили.....");
                        return;
                    }
                    vector[i] *= множитель;
                    //Console.SetCursorPosition(0, index+1);
                    Console.WriteLine($"умножено {vector[i]} ");
                }
            }

            for (int i = 0; i < size; i++)
            {
                vector[i] = random.Next();
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Task[] tasks = new Task[4];
            int partsize = size / tasks.Length;
            for (int i = 0; i < tasks.Length; i++)
            {
                int start = i * partsize;
                int end;

                if (i == tasks.Length - 1)
                {
                    end = size;
                }
                else
                {
                    end = start + partsize;
                }

                int taskindex = i;
                // tasks[i] = new Task(() => multiply(i * partsize, partsize,taskindex));
                //if(partsize<size)
                //{
                //    partsize += partsize;
                //}
                tasks[i] = Task.Run(() => multiply(start, end, taskindex), token);
            }
           


            зомби.CancelAfter(1);
            Console.WriteLine($"статус: {tasks[0].Status}");
            зомби.Dispose();
            //Task.WaitAll(tasks);
            stopwatch.Stop();

            Console.WriteLine($"время работы: {stopwatch.Elapsed}");

        }
        public static void task3()
        {

            Task<int> task1 = Task.Run(() => calcSum(50));
            Task<int> task2 = Task.Run(() => calcSum(35));
            Task<int> task3 = Task.Run(() => calcSum(727));
            int result = task1.Result + task2.Result + task3.Result;
            Task<int> final = Task.Run(() => calcSum(result));
            Console.WriteLine(final.Result);
        }
        public static void task4_1()
        {
            Task task1 = new Task(() =>
            {
                Console.WriteLine("task1");
            });
            Task task2 = task1.ContinueWith(printsome);
            task1.Start();
            task2.Wait();
            void printsome(Task t)
            {
                Console.WriteLine($"id: {Task.CurrentId}, предыдущий id: {t.Id}");
                Thread.Sleep(1000);
                Console.WriteLine("воооот так");
            }
        }
        public static async Task task4_2(int n)
        {
            int result = await printsome(n);
            Console.WriteLine(result);
        }
        static async Task<int> printsome(int n)
        {
            var task = Task.Run(() => calcSum(n));
            var awaiter = task.GetAwaiter();

            awaiter.OnCompleted(() =>
            {
                Console.WriteLine($"сумма чисел от 0 до {n} посчитана");
            });
            return awaiter.GetResult();
        }
        
        public static void task7()
        {
            BlockingCollection<string> склад = new BlockingCollection<string>();
            string[] products = { "пылесос", "тостор", "микроволновка", "духовка", "вытяжка" };
            Random rand = new Random();
            Parallel.Invoke(
                () => printсклад(),
                () => addproduct(),
                () => buyproduct()
            );
            void addproduct()
            {
                while(склад.IsAddingCompleted == false)
                {
                    string product = products[rand.Next(products.Length)];
                    Thread.Sleep(500 + rand.Next(1000));
                    Console.WriteLine($"\n{product} добавлен на склад");
                    склад.Add(product);
                    printсклад();
                }
            }
            void buyproduct()
            {
                while(склад.IsAddingCompleted == false)
                {
                    int index = rand.Next(10);
                    string product = products[rand.Next(products.Length)];
                    Thread.Sleep(400);
                    if(склад.TryTake(out product,300))//ждет 700мс прежжде чем расстроится и уйти
                    {
                        Console.WriteLine($"покупатель {index} украл {product}");
                        printсклад();
                    }
                    else
                    {
                        Console.WriteLine($"покупатель {index} расстроился и не купил {product}");
                    }
                }
            }
            void printсклад()
            {
                foreach (string product in склад)
                {
                    if (product == null)
                    {
                        Console.Write("склад пустой(");
                    }
                    Console.Write(product + ", ");
                }
                Console.WriteLine();
            }
            Thread.Sleep(20000);
            склад.CompleteAdding();
            //Task.WaitAll(suppliers);
            //Task.WaitAll(buyers);
        }
        
        
        

    }
}
