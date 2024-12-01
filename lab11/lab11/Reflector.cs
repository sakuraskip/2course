using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace lab11
{
    public static class Reflector<T>
    {
        public const string outputpath = @"C:\Users\леха\Desktop\3sem\лабы\oop\lab11\lab11\output.txt";
        public const string filepath = @"C:\Users\леха\Desktop\3sem\лабы\oop\lab11\lab11\file.txt";
        public static StreamWriter writer;
       
        public static void GetName(T classname)
        {
            Type type = classname.GetType();
            using (writer = new StreamWriter(outputpath, true))
            {
                writer.WriteLine($"имя класса: {classname}, имя сборки: {type.Assembly.FullName}");
            }
        }
        public static void HasPublicConstructor(T classname)
        {
            Type type = classname.GetType();
            using (writer = new StreamWriter(outputpath, true))
            {
                if (type.GetConstructors().Length > 0)
                {
                    writer.WriteLine($"у класса {classname} есть публичные конструкторы");
                    return;
                }
                writer.WriteLine($"у класса {classname} нет публичных конструкторов");
                writer.WriteLine("////");
            }
        }

        public static IEnumerable<string> PublicMethods(T classname)
        {
            Type type = classname.GetType();
            var  methods = type.GetMethods();
            return methods.Select(m => m.Name);
        }
        public static void PrintPublicMethods(T classname)
        {
            using (writer = new StreamWriter(outputpath, true))
            {
                writer.WriteLine($"публичные методы класса {classname}:");
                foreach (var method in PublicMethods(classname))
                {
                    writer.WriteLine(method);
                }
                writer.WriteLine("////");
            }
        }
        ////////////////////////
       
        public static IEnumerable<string> GetFieldsAndProperties(T classname)
        {
            List<string> result = new List<string>();
            Type type = classname.GetType();

            var fields = type.GetFields(BindingFlags.Public).Select(f=>f.Name);
            var properties = type.GetProperties(BindingFlags.Public).Select(p=>p.Name);

           foreach(var field in fields)
            {
                result.Add(field);
            }
           foreach(var property in properties)
            {
                result.Add(property);
            }
            return result;
        }
        public static void PrintFieldsAndProperties(T classname)
        {
            using (writer = new StreamWriter(outputpath, true))
            {
                IEnumerable<string> toPrint = new List<string>(GetFieldsAndProperties(classname));
                writer.WriteLine("поля и свойства: ");
                foreach (var field in toPrint)
                {
                    writer.WriteLine(field);
                }
                writer.WriteLine("////");
            }

        }
        public static IEnumerable<string> GetInterfaces(T classname)
        {
            Type type = classname.GetType();
            //var interfaces = type.GetInterfaces().Select(i => i.Name);
            var interfaces = new List<string>();
            foreach(var iface in type.GetInterfaces())
            {
                interfaces.Add(iface.Name);
            }
            return interfaces;
        }
        public static void PrintInterfaces(T classname)
        {
            using (writer = new StreamWriter(outputpath, true))
            {
                writer.WriteLine("реализованные интерфейсы: ");
                foreach (var iface in GetInterfaces(classname))
                {
                    writer.WriteLine(iface);
                }
                writer.WriteLine("////");
            }
        }

        public static IEnumerable<string> GetMethodsByType(T classname, Type parametertype)
        {
            Type type = classname.GetType();
            var methods = type.GetMethods();

            var result = new List<string>();

            return methods.Where(m=>m.GetParameters().Any(p=>p.ParameterType == parametertype)).Select(m=>m.Name);
        }
        public static void PrintMethodsByType(T classname, Type parametertype)
        {
            using (writer = new StreamWriter(outputpath, true))
            {
                writer.WriteLine($"методы с параметром: {parametertype} : ");
                foreach (var method in GetMethodsByType(classname, parametertype))
                {
                    writer.WriteLine(method);
                }
                writer.WriteLine("////");
            }
        }
        public static void Invoke(object obj,T classname,string methodname)
        {
            Type type = classname.GetType();
            var method = type.GetMethod(methodname);
            var fileLines = File.ReadAllLines(filepath,Encoding.UTF8);
            foreach (var line in fileLines)
            {
                method.Invoke(obj, new object[] { line });
            }    
           
           
        }
        public static object Create(T classname)
        {
            Type type = classname.GetType();
            var obj = Activator.CreateInstance(type);
            return obj;
        }
    }
}
