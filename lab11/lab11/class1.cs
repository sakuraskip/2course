using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    public class Растение
    {
        public string Color { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }

        public Растение(string color, string name, int height)
        {
            this.Color = color;
            this.Name = name;
            this.Height = height;
        }
        public Растение()
        {

        }
        public override string ToString()
        {
            return $"Название: {Name}, Цвет: {Color}, Высота: {Height}";
        }

    }
    public class КоллекцияРастений : IList<Растение>
    {
        private HashSet<Растение> plants = new HashSet<Растение>();

        public int Count { get { return plants.Count; } }
        public bool IsReadOnly { get { return false; } }
        public IEnumerator<Растение> GetEnumerator()
        {
            return plants.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(Растение plant)
        {
            plants.Add(plant);
            Console.WriteLine($"растение {plant} добавлено");
        }
        public void Clear()
        {
            plants.Clear();
        }
        public bool Contains(Растение plant)
        {
            return plants.Contains(plant);
        }
        public void CopyTo(Растение[] plants, int index)
        {
            plants.CopyTo(plants, index);
        }
        public bool Remove(Растение plant)
        {
            return plants.Remove(plant);
        }


        public int IndexOf(Растение plant)
        {
            throw new NotSupportedException("не поддерживается");
        }
        public void Insert(int id, Растение plant)
        {
            throw new NotSupportedException("не поддерживается");
        }
        public void RemoveAt(int id)
        {
            throw new NotSupportedException("не поддерживается");
        }
        public Растение this[int index]
        {
            get
            {
                throw new NotSupportedException("не поддерживается");
            }
            set
            {
                throw new NotSupportedException("не поддерживается");
            }
        }



    }
}
