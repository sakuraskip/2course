using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace lab10
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] months = {"january","february","march","april","may","june","july",
            "august","september","october","november","december"
            };

            var monthWithLength4 = from month in months
                                   where month.Length == 4
                                   select month;
            foreach (var month in monthWithLength4)
            {
                Console.WriteLine(month);
            }

            var summerOrWinter = months.Where(month => month == "january" || month == "february" ||
            month == "december" || month == "june" || month == "july" || month == "august");

            var alphabetOrder = months.OrderBy(month => month);

            var hasletterU = months.Where(month=> month.Length >= 4 && month.Contains('u'));

            Console.WriteLine();
            foreach (var month in hasletterU)
            {
                Console.WriteLine(month);
            }



            List<Set> list1 = new List<Set>();
            Set set1 = new Set(); set1.AddElement(3); set1.AddElement(5);
            Set set2 = new Set(); set2.AddElement(91); set2.AddElement(8);
            Set set3 = new Set(); set3.AddElement(-3); set3.AddElement(14);
            Set set4 = new Set(); set4.AddElement(12); set4.AddElement(0);
            Set set5 = new Set(); set5.AddElement(6); set5.AddElement(91);
            Console.WriteLine(set1);

            list1.Add(set1); list1.Add(set2); list1.Add(set3); list1.Add(set4); list1.Add(set5);

            var maxSum = list1.OrderBy(set=> set.GetSum()).Last();  
            var minSum = list1.OrderBy(set => set.GetSum()).First();

            var hasNegativeElem = from set in list1
                                  where set.HasNegative() == true
                                  select set;

            int target1 = 91;
            int containsTarget = list1.Count(set=> set._elements.Contains(target1));

            var maxSet = list1.OrderBy(set=> set._elements.Count).Last();

            var firstSet = list1.First(set => set._elements.Contains(target1));

            var orderByFirst = list1.OrderBy(set => set._elements.First());

            var request = from set in list1
                          where set.GetSum() >= 0 // ограничение
                          where set._elements.Any()
                          group set by set._elements.First() into setlist // соединение
                          orderby setlist.Key // упорядочивание
                          select new //проекция
                          {
                              key = setlist.Max(set=> set.GetSum()), // агрегация

                          };

            Console.WriteLine("але");


            HashSet<int> set7 = new HashSet<int> { 1,2,3,4,5};
            HashSet<int> set8 = new HashSet<int> { 4, 5, 6, 7, 8 };

            var commonElem = from elem in set7
                             join elem2 in set8 on elem equals elem2
                             select elem;

            Console.WriteLine();

            foreach(var elem in commonElem )
            {
                Console.WriteLine( elem );
            }




        }
    }
}
