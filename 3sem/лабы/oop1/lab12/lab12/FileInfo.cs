using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public static class SAVFileInfo
    {
       public static void GetFileInfo(string filepath)
        {
            FileInfo info = new FileInfo(filepath);
            if (info.Exists)
            {
                Console.WriteLine("полный путь: " + info.DirectoryName);
                Console.WriteLine("размер: " + info.Length + "\nрасширение: " +
                    info.Extension + "\nимя: " + info.Name);
                Console.WriteLine("дата создания: " + info.CreationTime +
                    "\nдата изменения: "+info.LastWriteTime);
            }
            Console.WriteLine();

            Log.WriteLog(info.Name, filepath, "информация о файле");
        }
    }
}
