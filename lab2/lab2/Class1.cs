using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public partial class Set
    {
        public int Id
        {
            get { return _id; }
        }
        public string Name
        {
            set { _name = value;}
        }
        public string Type
        {
            get { return type; }
        }

        public void AddElement(int element)
        {
            _elements.Add(element);
        }
    }
}
