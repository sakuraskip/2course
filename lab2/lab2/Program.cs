using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.Linq;
namespace lab2
{
    public partial class Set
    {
        private HashSet<int> _elements;
        private readonly int _id;
        private const string type = "set";
        private static int _count = 0;
        private string _name = "default";
        public Set()
        {
            _elements = new HashSet<int>();
        }

        public Set(HashSet<int> elements = null)
        {
            if (elements == null)
            {
                _elements = new HashSet<int>();
                _count++;
                return;
            }
        }
        static Set()
        {
            Console.WriteLine("static Set");
        }
        private Set(HashSet<int> elements, int id)
        {
            _elements = elements;
            _id = id;
            _count++;
        }
        public static Set GetPrivateSet(HashSet<int> elem, int id)
        {
            return new Set(elem,id);
        }
        static void GetInfo()
        {
            Console.WriteLine($"name: {nameof(Set)}");
            Console.WriteLine($"count: {_count}");
            Console.WriteLine($"type: {type}");
        }
        
        public void RemoveElement(ref int element)
        {
            _elements.Remove(element);
        }
        public int HashSetSize()
        {
            return _elements.Count;
        }
        public bool Equals(Set other)
        {
            if (other == null)
            {
                return false;
            }
            return _elements.SetEquals(other._elements);
        }
        public override int GetHashCode()
        {
            int hash = 4;
            foreach( int element in _elements)
            {
                hash = hash * 31 + element;
            }
            return hash;
        }
        public override string ToString()
        {
            return $"set name: {_name}, id: {_id},type: {type}";
        }
        public bool IfCanGetLastElement(out int lastelem)
        {
            if(_elements.Count > 0 )
            {
                lastelem = _elements.Last();
                return true;
                
            }
            else
            {
                lastelem = default;
                return false;
            }
        }
        public int GetSum()
        {
            int sum = 0;
            foreach (int elem in _elements)
            {
                sum += elem;
            }
            return sum;
        }
        public bool HasNegativeElem()
        {
            foreach (int elem in _elements)
            {
                if (elem < 0)
                {
                    return true;
                }
            }
            return false;
        }
        public void PrintElements()
        {
            foreach (int elem in _elements)
            {
                Console.Write($"{elem} ");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Set[] sets = new Set[3];
            sets[0] = new Set();
            sets[0].AddElement(1);
            sets[0].AddElement(21);
            sets[0].AddElement(4);

            sets[1] = new Set();
            sets[1].AddElement(-5);
            sets[1].AddElement(4);
            sets[1].AddElement(11);

            sets[2] = new Set();
            sets[2].AddElement(4);
            sets[2].AddElement(-2);
            sets[2].AddElement(9);

            Set minSet = sets[0];
            Set maxSet = sets[0];
            int minSum = minSet.GetSum();
            int maxSun = maxSet.GetSum();

            foreach (var set in sets)
            {
                int elemSum = set.GetSum();
                if (elemSum < minSum)
                {
                    minSet = set;
                    minSum = elemSum;
                }
                if (elemSum > maxSun)
                {
                    maxSet = set;
                    maxSun = elemSum;
                }
            }
            Console.WriteLine($"множество с минимальной суммой: ");
            minSet.PrintElements();
            Console.WriteLine($"множество с макс. суммой:");
            maxSet.PrintElements();

            Console.WriteLine("множества содержащие отрицательные элементы: ");

            foreach (var set in sets)
            {
                if (set.HasNegativeElem())
                {
                    set.PrintElements();
                }
            }
            int bpik = 0;
            bool dsf = maxSet.IfCanGetLastElement(out bpik);
            Console.WriteLine(bpik);
            
            var anonSet = new {Name = "anonset", Id = 2131, Type = "set", count = 5, elements = new[] { 3, 25, 7, 9, 11 } };
            Console.Write($"set name: {anonSet.Name}, id: {anonSet.Id},type: {anonSet.Type}");
        }

    }
}
    