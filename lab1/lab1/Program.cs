
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter int: ");
            int intNum = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine($"int: {intNum}");

            Console.WriteLine("enter bool(true/false): ");
            bool boolValue = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine($"bool: {boolValue}");

            Console.WriteLine("enter byte: ");
            byte byteNum = Convert.ToByte(Console.ReadLine());
            Console.WriteLine($"byte: {byteNum} ");

            Console.WriteLine("enter sbyte: ");
            sbyte sbyteNum = Convert.ToSByte(Console.ReadLine());
            Console.WriteLine($"sbyte:{sbyteNum} ");

            Console.WriteLine("enter char: ");
            char charSymbol = Convert.ToChar(Console.ReadLine());
            Console.WriteLine($"char: {charSymbol}");

            Console.WriteLine("enter decimal: ");
            decimal decimalNum = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine($"decimal: {decimalNum}");

            Console.WriteLine("enter double: ");
            double doubleNum = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"double: {doubleNum}");

            Console.WriteLine("enter float: ");
            float floatNum = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine($"float: {floatNum}");

            Console.WriteLine("enter uint: ");
            uint uintNum = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine($"uint: {uintNum}");

            Console.WriteLine("enter nint: ");
            nint nintNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"nint: {nintNum}");

            Console.Write("enter short: ");
            short shortValue = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine($"short: {shortValue}");

            Console.Write("enter ushort: ");
            ushort ushortValue = Convert.ToUInt16(Console.ReadLine());
            Console.WriteLine($"ushort: {ushortValue}");

            Console.Write("enter long: ");
            long longValue = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine($"long: {longValue}");

            Console.Write("enter an ulong:");
            ulong ulongValue = Convert.ToUInt64(Console.ReadLine());
            Console.WriteLine($"ulong: {ulongValue}");

            //////////////////////////////////////////////////////

            //task b
            int i1 = 3;
            double d = (double)i1;
            float f = (float)d;
            long l = (long)f;
            object obj = (object)l;
            short s = (short)i1;

            l = i1;
            d = f;
            byte b = 122;
            i1 = b;
            decimal dec = i1;
            
            //task c
            int notPacked = 12;
            object packed = notPacked;
            int unpacked = (int)packed;

            //task d
            var variable = 134;
            var varString = "variable";

            //task e
            int? varInt = null;
            int nullValue = varInt ?? 127;//если varint = null - nullvalue = 127

            var taskf = 3;
            taskf = "c";


            //Task 2, a
            string str1 = "бебра";
            string str2 = "бебра";
            string str3 = "бобер";
            bool isEqual;
            if (str1.Equals(str2))
            {
                isEqual = true;
            }
            else
            {
                isEqual = false;
            }
            //task b
            string concString = str1 + str2 + str3;
            string copiedString = concString;
            string substring = concString.Substring(3, 6);
            string[] words = copiedString.Split(' ');
            string insertString = substring.Insert(3, str1);
            string removeString = insertString.Remove(1, 3);
            Console.WriteLine($"test {str1} , {str3}");
            //task c
            string nullstring = null;
            string emptystring = "";
            bool isEmpty;
            isEmpty = string.IsNullOrEmpty(emptystring);
            copiedString = nullstring + emptystring;
            Console.WriteLine(copiedString);

            //task d
            StringBuilder strb = new StringBuilder("бипки", 15);

            strb.Remove(0, 1);
            strb.Append(str1);
            strb.Insert(0, "бибера");

            // Task 3,a
            int[,] matrix1 =
            {
                {1,2,3 },
                {4,5,6 },
                {7,8,9 }

            };
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    Console.Write($"{matrix1[i, j]}, ");
                }
                Console.WriteLine();
            }
            //task b
            string[] strings = { "bebra", "bipki", "1802", "oleg" };
            for (int i = 0; i < strings.Length; i++)
            {
                Console.Write($"{strings[i]}  ");
            }
            Console.WriteLine($"длина: {strings.Length}");
            Console.WriteLine("ввод позиции для изменения(от 0 до 3): ");
            int editPos;
            editPos = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("ввод строки для замены");
            strings[editPos] = Convert.ToString(Console.ReadLine());
            //task c

            int[][] ladderArray = new int[3][];
            int max = 2;
            int counter = 0;
            Console.WriteLine("введите элементы массива(числа!!!!)");
            for(int i=0;i<3;i++)
            {
                while(counter < max)
                {
                    Convert.ToInt32(Console.ReadLine());
                    counter++;
                }
                max++;
                counter = 0;
            }
            //task d
            var varArray = ladderArray;
            var varString2 = "всем привет";

            //Task 4 a
            (int, string, char, string, ulong) t1 = (3, "орехи", 'd', "помидоры", 132131231);
            //task b
            Console.WriteLine($"вывод кортежа: {t1.Item1},{t1.Item2},{t1.Item3},{t1.Item4},{t1.Item5}");
            Console.WriteLine($"вывод 1 3 4 элементов: {t1.Item1},{t1.Item3},{t1.Item4}");
            //task c
            int iTuple1;
            string sTuple1;
            char cTuple;
            string sTuple2;
            ulong lTuple;
            (iTuple1, sTuple1, cTuple, sTuple2, lTuple) = t1;

            var vTuple = t1;

            (_, _, cTuple, sTuple2, lTuple) = t1;
            //task d
            (int h, long n) left = (13, 22);
            (long h1, int n2) right = (13, 22);
            Console.WriteLine(left == right);

            //Task 5 a
            static (int,int,int,char) localFunc(int[] array,string testString)
            {
                int min = array[0];
                int max = array[0];
                int sum = 0;
                for(int i=0;i<array.Length;i++)
                {
                    sum += array[i];
                    if (min > array[i])
                    {
                        min = array[i];
                    }
                    if(max < array[i])
                    {
                        max = array[i];
                    }
                }
                char letter = testString[0];

                (int, int, int, char) t2 = (max, min, sum, letter);
                return t2;
            }
            //Task 6
            int iMax = int.MaxValue;
            void local1()
            {
                Console.WriteLine("checked ");
                try
                {
                    checked
                    {
                        Console.WriteLine(iMax + 2);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            void local2()
            {
                Console.WriteLine("unchecked");
                unchecked
                {
                    Console.WriteLine(iMax + 2);
                }
            }
            local1();
            local2();



        }
    }
}