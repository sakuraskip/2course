using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Vector
    {
        private List<int> _elements;
        private Production _production;
        private Developer _developer;
        
        public Vector()
        {
            _elements = new List<int>();
            _production = new Production(0,"prod0");
            _developer = new Developer("андрей", 0, "киберпреступник");
            
        }
        public Vector(List<int> elements)
        {
            _elements = elements;
            _production = new Production(0, "prod0");
            _developer = new Developer("андрей", 0, "киберпреступник");

        }
        public int GetElem(int index)
        {
            return _elements[index];
        }
        public void SetElem(int index, int value)
        {
            _elements[index] = value;
        }
        public int Count()
        {
            return _elements.Count;
        }
        public void Print()
        {
            for(int i=0;i<_elements.Count; i++)
            {
                Console.Write($"{_elements[i]} ");
            }
            Console.WriteLine();
        }
        public bool IsPositive(int value)
        {
            return value > 0;
        }
        public void RemovePositive()
        {

            _elements.RemoveAll(IsPositive);
        }

        public static Vector operator +(Vector a, Vector b)
        {
            if (a.Count() != b.Count())
            {
                throw new System.ArgumentException();
            }
            Vector result = new Vector();
            for (int i = 0; i < a.Count(); i++)
            {
                result._elements.Add(a._elements[i] + b._elements[i]);
            }
            return result;
        }
        public static bool operator >(Vector a, Vector b)
        {
            if(a.Count() != b.Count())
            {
            throw new System.ArgumentException(); 
            }
            for(int i=0;i<a.Count(); i++)
            {
                if (a._elements[i] > b._elements[i])
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator <(Vector a, Vector b)
        {
            if (a.Count() != b.Count())
            {
                throw new System.ArgumentException();
            }
            for (int i = 0; i < a.Count(); i++)
            {
                if (a._elements[i] < b._elements[i])
                {
                    return true;
                }
            }
            return false;
        }
        public static Vector operator !=(Vector a, Vector b)
        {
            if (a.Count() != b.Count())
            {
                throw new System.ArgumentException();
            }
            Vector result = new Vector();
            int iterator =0;
            for (int i = 0; i < a.Count(); i++)
            {
                if (a._elements[i] != b._elements[i])
                {
                    result._elements[iterator++] = b._elements[i];
                }
            }
            return result;
        }
        public static Vector operator ==(Vector a, Vector b)
        {
            if(a.Count()!=b.Count())
            {
                throw new ArgumentException();
            }
            a._elements = b._elements;
            return b;
        }
        public static bool operator true(Vector a)
        {
            return a.Count() == 0;
        }
        public static bool operator false(Vector a)
        {
            return a.Count() != 0;
        }
        public class Production
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public Production(int id, string name)
            {
                this.Id = id;
                this.Name = name;
            }
            public void Print()
            {
                Console.WriteLine($"id: {this.Id}\nname: {this.Name}\n");
            }
        }
        public class Developer
        {
            private string fullname;
            private int id;
            private string departament;

            public Developer(string fullname, int id, string departament)
            {
                this.fullname = fullname;
                this.id = id;
                this.departament = departament;
            }
            public void Print()
            {
                Console.WriteLine($"fullname: {this.fullname}\nid: {this.id}\n departament: {this.departament}\n");
            }
        }

    }
}
