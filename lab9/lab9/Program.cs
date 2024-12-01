using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;

namespace lab9
{
    public class Program
    {

        static void Main(string[] args)
        {
            КоллекцияРастений collection = new КоллекцияРастений();

            Растение grass = new Растение("зеленый", "трава", 30);
            Растение rose = new Растение("белый", "роза", 50);
            Растение dandelion = new Растение("белый", "одуванчик", 20);
            collection.Add(grass);
            collection.Add(rose);
            collection.Add(dandelion);
            Console.WriteLine(collection.Count);


            HashSet<int> set1 = new HashSet<int> {3,5,19,22,0,1 };
            HashSet<int> set2 = new HashSet<int> { 41, 22, -13, -2 };
            
            int n = 3;

            List<int> set1list = new List<int>(set1);

            for(int i =0;i<n && set1.Count>0;i++)
            {
                set1.Remove(set1list[i]);
            }
            set1.Add(13);
            set1.UnionWith(set2);
            foreach (int i in set1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            foreach (int i in set1list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n"+set1list.Contains(19));

            ObservableCollection<Растение> plants12 = new ObservableCollection<Растение>();

            plants12.CollectionChanged += CollectionChanged;
            plants12.Add(rose);
            plants12.Add(grass);
            plants12.Add(new Растение("зеленый", "дуб", 1000));
            plants12.Remove(rose);
            plants12.Add(rose);

        }

       

        private static void CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        foreach (var plant in e.NewItems)
                        {
                            Console.WriteLine("новое растение: " + plant);
                        }
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        foreach (Растение plant in e.OldItems)
                        {
                            Console.WriteLine("удаленные растения: " + plant);
                        }
                        break;
                    }
            }
        }
    }
}
