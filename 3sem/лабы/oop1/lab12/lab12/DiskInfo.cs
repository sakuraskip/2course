using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    static class DiskInfo
    {
        public static void GetDiskInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"свободное место на диске: {drive.AvailableFreeSpace}");
                Console.WriteLine($"файловая система: {drive.DriveFormat}");
            if(drive.IsReady)
                {
                    Console.WriteLine(drive.Name);
                    Console.WriteLine(drive.TotalSize);
                    Console.WriteLine(drive.AvailableFreeSpace);
                    Console.WriteLine(drive.VolumeLabel);
                    Log.WriteLog(drive.Name, drive.Name, "информация о диске");

                }
            }
            Console.WriteLine();



        }

    }
}
