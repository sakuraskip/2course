using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public static class DirInfo
    {
        public static void GetDirectoryInfo(string dirpath)
        {
            DirectoryInfo info = new DirectoryInfo(dirpath);
            if (info.Exists)
            {
                Console.WriteLine("кол-во файлов: "+ info.GetFiles().Length);
                Console.WriteLine("время создания: " + info.CreationTime);
                Console.WriteLine("кол-во поддиректориев: "+info.GetDirectories().Length);
                Console.WriteLine("список родительских директореив: " + info.Parent);
                Console.WriteLine();
            }
            Log.WriteLog("", dirpath, "информация о директории");
        }
    }
}
