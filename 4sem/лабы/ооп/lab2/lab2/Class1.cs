using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace lab2
{
    public class buydateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value == null || string.IsNullOrEmpty(value.ToString()))
            {
                this.ErrorMessage = "дата покупки не должна быть пустой!";
                return false;
            }
            if(!DateTime.TryParse(value.ToString(),out DateTime datevalue))
            {
                this.ErrorMessage = "некорректный формат даты";
                return false;
            }
            return true;
        }
    }
    [Serializable]
    public class Computer
    {
        [Required(ErrorMessage = "Название компьютера обязательно")]
        public string name {  get; set; }
        [Required(ErrorMessage ="Не выбран процессор")]
        public Processor processor;
        [Required(ErrorMessage ="не выбран тип компьютера")]
        public string type { get; set; }
        [Required(ErrorMessage = "не выбрана видеокарта")]
        public string videocard { get; set; }
        [Required(ErrorMessage = "не выбран тип оперативной памяти")]

        public string ramtype { get; set; }
        [Required(ErrorMessage = "не выбран тип диска")]

        public string memorytype { get; set; }
        [Range(0,int.MaxValue,ErrorMessage ="Цена должна быть больше нуля") ]
        public int price { get; set; }
        public void calcPrice()
        {
            price = 0; 
            switch (type)
            {
                case "Сервер":
                    price += 50000; 
                    break;
                case "Персональный":
                    price += 30000; 
                    break;
                case "Ноутбук":
                    price += 40000; 
                    break;
            }
            switch (videocard)
            {
                case "IntelArc580":
                    price += 20000;
                    break;
                case "Radeon6700xt":
                    price += 15000;
                    break;
                case "Gt630":
                    price += 5000;
                    break;
            }

            switch (ramtype)
            {
                case "DDR3":
                    price += 3000 * RAM; 
                    break;
                case "DDR4":
                    price += 4000 * RAM; 
                    break;
                case "DDR5":
                    price += 5000 * RAM; 
                    break;
            }

            switch (memorytype)
            {
                case "SSD":
                    price += 10000 * Memory;
                    break;
                case "HDD":
                    price += 5000 * Memory; 
                    break;
                case "M2 SSD":
                    price += 15000 * Memory; 
                    break;
            }
        }
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
        [buydate]
        public string buydate { get; set; }
       
    }
    [Serializable]
    public class ComputerList
    {
        public List<Computer> list { get; set; } = new List<Computer>();
    }
    [Serializable]
    public class Processor
    {
        public string производитель;
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
