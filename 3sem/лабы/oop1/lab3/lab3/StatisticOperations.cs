using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public static class StatisticOperations
    {
        public static int Sum(this Vector vector)
        {
            int result = 0;
            for(int i=0;i<vector.Count();i++)
            {
                result += vector.GetElem(i);
            }
            return result;
        }
        public static int DiffMinMax(Vector vector)
        {
            if(vector.Count()<2)
            {
                return 0;
            }
            int min = vector.GetElem(0);
            int max = vector.GetElem(0);
            for(int i=0;i<vector.Count(); i++)
            {
                if( vector.GetElem(i) < min )
                {
                    min = vector.GetElem(i);
                }
                if(vector.GetElem(i) > max )
                {
                    max = vector.GetElem(i);
                }
            }
            int diff = max - min;
            return diff;
            
        }
        public static int CountElements(Vector vector)
        {
        return vector.Count();
        }
        public static string CutString(this string input,int amount)
        {
            if(string.IsNullOrEmpty(input) || amount>input.Length)
            {
                return string.Empty;
            }
            string result = input.Substring(amount);
            return result;
        }
       
        public static Vector DeletePositiveElem(this Vector vector)
        {
            if(vector.Count()<0)
            {
                return vector;
            }
            Vector result = vector;
            result.RemovePositive();
            return result;

        }
    }
}
