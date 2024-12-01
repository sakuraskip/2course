using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab8
{
    public class User
    {
        public delegate void MoveHandle(string message);
        public delegate void CompressHandle(string message);
        private int _position;
        private float _sizeOf;


        public event MoveHandle MoveTo;
        public event CompressHandle Compress;

       
        public int Position
        {
           get => _position;
            set { _position = value; }
        }
        public float SizeOf
        {
            get => _sizeOf;
            set { _sizeOf = value; }
        }

        public User(int pos =0, float size = 1)
        {
            Position = pos;
            SizeOf = size;
        }
        public void ChangePosition(int pos)
        {
            Position += pos;
            MoveTo?.Invoke($"{this.GetType().Name} переместился на " + pos);
        }
        public void CompressSize(float compressValue)
        {
            SizeOf /= compressValue;
            Compress?.Invoke("размер данных сжат в " + compressValue + " раз");
        }
       


    }
}
