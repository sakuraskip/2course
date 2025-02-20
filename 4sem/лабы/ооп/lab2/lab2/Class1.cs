using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    [Serializable]
    public class Computer
    {
        public Processor processor;
        public computerType type { get; set; }
        public Videocard videocard { get; set; }
        public enum computerType
        {
            Сервер,
            Персональный,
            Ноутбук
        }
        public enum Videocard
        {
            IntelArc580,
            Radeon6700xt,
            Gt630
        }
        public int RAM { get; set; }
        public enum RAMtype
        {
            DDR3,
            DDR4,
            DDR5
        }
        public int Memory { get; set; }
        public enum MemoryType
        {
           SSD,
           HDD,
           M2_SSD
        }
        public string buydate { get; set; }
       
    }
    public class Processor
    {
        public Производитель производитель;
        public enum Производитель
        {
            Intel,
            AMD,
            Байкал
        }
        public string Серия {  get; set; } 
        public string Модель {  get; set; }
        public int количество_ядер { get; set; }
        public string Frequency { get; set; }
        public int Cache {  get; set; }

        
    }
    
}
