using System.Diagnostics.CodeAnalysis;

namespace lab3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(new List<int> { 1,2,5,-4});
            Vector vector2 = new Vector(new List<int> { 1,4,5,-2});

            Vector vector3 = new Vector();
            vector3 = vector1 + vector2;
            vector3.Print();

            bool test1;
            test1 = vector1 < vector2;
            Console.WriteLine(test1);

            test1 = vector1 > vector2;
            Console.WriteLine(test1);

            (vector3 == vector1).Print();

            Console.WriteLine();

            if(vector1)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }

            string test3 = "абрикосы ананасы бананы";

            test3.CutString(4);
            vector3.DeletePositiveElem();
            vector3.Print();

            vector3.Sum();
        }
    }
}
