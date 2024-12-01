using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public static class FileManager
    {
        public static void GetFoldersAndFiles(string dirpath,string filename)
        {
            if(!Directory.Exists(dirpath))
            {
                Console.WriteLine("путь к папкам не найден");
                return;
            }

            DirectoryInfo dirinfo = new DirectoryInfo(dirpath);
            DirectoryInfo subDir = dirinfo.CreateSubdirectory("SAVInspect");
            string filepath = Path.Combine(subDir.FullName, "dirinfo.txt");
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                writer.WriteLine("список файлов: ");
                foreach (var file in dirinfo.GetFiles())
                {
                    writer.WriteLine(file.Name);
                }
                writer.WriteLine("список папок: ");
                foreach (var folder in dirinfo.GetDirectories())
                {
                    writer.WriteLine(folder.Name);
                }
            }
            string copyfilepath = Path.Combine(subDir.FullName, "copydirinfo.txt");
            File.Copy(filepath, copyfilepath, true);

            if(File.Exists(Path.Combine(subDir.FullName, filename)))
            {
                File.Delete(Path.Combine(subDir.FullName, filename));
            }

            File.Move(copyfilepath, Path.Combine(subDir.FullName, filename));
            File.Delete(filepath);

            Log.WriteLog(filename, filepath, "получение файлов и папок");
        }
        public static void TaskB(string destination,string source,string extension)
        {
            if(!Directory.Exists(destination))
            {
                Console.WriteLine("путь для перемещния файлов не найден(destination)");
                return;
            }
            if(!Directory.Exists (source))
            {
                Console.WriteLine("папка для перемещения не найдена(source)");
                return;
            }

            DirectoryInfo dirinfo = new DirectoryInfo(destination);
            DirectoryInfo subdir = dirinfo.CreateSubdirectory("savFiles");

            foreach (string filepath in Directory.GetFiles(source, extension))
            {
                string filename = Path.GetFileName(filepath);
                string copyTo = Path.Combine(subdir.FullName, filename);
                File.Copy(filepath, copyTo, true);
            }

            Log.WriteLog("savFiles", subdir.FullName, "Перемещение файлов");

        }
        public static void TaskC(string destination, string source, string toExtract)
        {
            if(!Directory.Exists(source))
            {
                Console.WriteLine("исходная папка не найдена!!");
                return;
            }
            if(!Directory.Exists(toExtract))
            {
                Console.WriteLine("папка для разархивирования не найдена");
                return;
            }
            if(File.Exists(destination))
            {
                File.Delete(destination);
            }

            ZipFile.CreateFromDirectory(source, destination);
            ZipFile.ExtractToDirectory(destination, toExtract);

            Log.WriteLog("test.zip", source, "создание архива");
        }

    }
}
