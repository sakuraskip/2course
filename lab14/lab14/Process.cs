using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab14
{
    public class Process1
    {
        public static void ShowProcesses()
        {
            var processlist = Process.GetProcesses();
            foreach (var process in processlist)
            {
                Console.WriteLine($"id: {process.Id}, name: {process.ProcessName}, приоритет: {process.PriorityClass}," +
                    $"время запуска: {process.StartTime}, состояние: {process.Responding}, и т.д: {process.ProcessorAffinity}");
            }
        }
        public static void ShowDomain()
        {
            AppDomain domain = AppDomain.CurrentDomain;

            Console.WriteLine($"name: {domain.FriendlyName}, config: {domain.SetupInformation}");
            var assemblies = domain.GetAssemblies();
            foreach (var item in assemblies)
            {
                Console.WriteLine(item.GetName().Name);
            }
            //AppDomain newdomain = AppDomain.CreateDomain("новый");
            // AppDomain.Unload(newdomain);
        }
    }
}
