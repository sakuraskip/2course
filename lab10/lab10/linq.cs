using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class Set
    {
        public HashSet<int> _elements { get; set; }
        
        public Set()
        {
            _elements = new HashSet<int>();
        }

        public Set(HashSet<int> elements = null)
        {
            if (elements == null)
            {
                _elements = new HashSet<int>();
                return;
            }
        }
        public void AddElement(int element)
        {
            _elements.Add(element);
        }
        public int GetSum()
        {
            int sum = 0;
            foreach (int element in _elements)
            {
                sum+= element;
            }
            return sum;
        }
        public bool HasNegative()
        {
            foreach(int element in _elements)
            {
                if(element <0)
                {
                    return true;
                }
            }
            return false;
        }
        public void PrintSet()
        {
            Console.WriteLine();
            foreach(int element in _elements)
            {
                Console.Write(element+ " ");
            }
        }
    }

}
