using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Lab_15_OOP
{
    class WorkWithProcess
    {
        Process[] current = Process.GetProcesses();

        public void getProcess()
        {
            foreach (Process i in current)
            {
                Console.WriteLine("Id запущенного процесса: " + i.Id);
                Console.WriteLine("Имя процесса: " + i.ProcessName);
                Console.WriteLine("/n Следующий процесс: ");
            }
        }
    }
}
