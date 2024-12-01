using System.Numerics;

namespace lab7
{
    public class Program
    {
        static void Main(string[] args)
        {
            Vector<object> vector = new Vector<object>(123);

            Vector<unknownShip> vector1 = new Vector<unknownShip>(new unknownShip(0,"пустой корабль",0));

            vector1.Add(new unknownShip(13, "кораблик2", 100));
            vector1.Add(new unknownShip(14, "кораблик3", 10));
            vector1.Print();

            vector.Add("орешк dsfdsfsddsfsfи");
            vector.Add(12313);
            vector.Add(3.14);
            int test2 = 13;
            object obj1 = (object)test2;
            vector.Add(obj1);
            vector.Print();

            string filepath = "C:\\Users\\леха\\Desktop\\3sem\\лабы\\oop\\lab7\\lab7\\File.txt";

            vector.SaveToFile(filepath);

            Vector<object> vector3 = new Vector<object>(456);
            Console.WriteLine("из файла прочитано: ");
            vector3.ReadFromFile(filepath);
            vector3.Print();
        }
    }
}
