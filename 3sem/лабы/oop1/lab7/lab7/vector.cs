using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    interface IVector<T>
    {
        T id { get; }
        void Add(T value);
        void Delete(T value);
        T Check(int index);
    }
    public class Vector<T> : IVector<T> where T : class
    {
        public T id { get; set; }
        private List<T> _elements;
        private Production _production;
        private Developer _developer;

        public Vector(T id)
        {
            this.id = id;
            _elements = new List<T>();
            _production = new Production(0, "prod0");
            _developer = new Developer("андрей", 0, "киберпреступник");
        }
        public Vector(List<T> elements, T id)
        {
            this.id = id;
            _elements = elements;
            _production = new Production(0, "prod0");
            _developer = new Developer("андрей", 0, "киберпреступник");

        }
        public void Add(T value)
        {
            try
            {
                _elements.Add(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("void Add отработал");
            }
        }
        public void SaveToFile(string path)
        {
            try
            {
                using var writer = new StreamWriter(path);
                foreach (var element in _elements)
                {
                    writer.Write(element.ToString() + " ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ReadFromFile(string path)
        {
            using var reader = new StreamReader(path);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] elements = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach(var item in elements)
                {
                    var value = (T)Convert.ChangeType(item, typeof(T));
                 
                    _elements.Add(value);
                }
            }
        }
        public void Delete(T value)
        {
            try
            {
                _elements.Remove(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("void delete отработал");
            }
        }
        public T Check(int index)
        {
            return _elements[index];
        }
        public void SetElem(int index, T value)
        {
            _elements[index] = value;
        }
        public int Count()
        {
            return _elements.Count;
        }
        public void Print()
        {
            foreach (var element in _elements)
            {
                Console.WriteLine(element.ToString());
            }
        }
        public bool IsInteger(T value)
        {
            return value is int;
        }
        public void RemovePositive()
        {

            _elements.RemoveAll(IsInteger);
        }
        public static Vector<T> operator +(Vector<T> a, Vector<T> b)
        {
            if (a.Count() != b.Count())
            {
                throw new System.ArgumentException();
            }
            Vector<T> result = new Vector<T>(a.id);
            for (int i = 0; i < a.Count(); i++)
            {
                result._elements.Add((dynamic)a._elements[i] + (dynamic)b._elements[i]);
            }
            return result;
        }
        public static bool operator >(Vector<T> a, Vector<T> b)
        {
            if (a.Count() != b.Count())
            {
                throw new System.ArgumentException();
            }
            for (int i = 0; i < a.Count(); i++)
            {
                if ((dynamic)a._elements[i] > (dynamic)b._elements[i])
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator <(Vector<T> a, Vector<T> b)
        {
            if (a.Count() != b.Count())
            {
                throw new System.ArgumentException();
            }
            for (int i = 0; i < a.Count(); i++)
            {
                if ((dynamic)a._elements[i] < (dynamic)b._elements[i])
                {
                    return true;
                }
            }
            return false;
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
