using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace Lab_15_OOP
{
    class Program
    {
        static bool flag = false;
        static int n;
        static int[] mas = new int[1000];
        private static object lockOn = new object();
        static void Main(string[] args)
        {
            WorkWithProcess process = new WorkWithProcess();
            process.getProcess();
            WorkWithDomain domain = new WorkWithDomain();
            domain.InfoAboutDomain();
            domain.CreateOfNewD();
            WorkWithThread thread = new WorkWithThread();
            WorkWithThread.th.Start();
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Исходный массив");
            for (int i = 0; i < n; i++)
                mas[i] = i;
            Thread ch = new Thread(Counter);
            ch.Start();
            ch.Join();
            Thread nech = new Thread(Counter);
            nech.Start();
            nech.Join();
            int num = 0;
            TimerCallback tm = new TimerCallback(Count);
            Timer timer = new Timer(tm, num, 0, 2000);
           
        }

        static StreamWriter sw = new StreamWriter("Log.txt", true, System.Text.Encoding.Default);

        public static void Print(int i)
        {
            sw.WriteLine(i);
        }

        public static void Counter()
        {
            Thread.Sleep(1000);
            if (!flag)
            {
                Console.WriteLine("Чётные значения: ");
            }
            if (flag)
            {
                Console.WriteLine("Нечётные значения: ");
            }
            for (int i = 0; i < n; i++)
            {
                if (!flag)
                {
                    if (mas[i] % 2 == 0)
                    {
                        Console.WriteLine(i);
                        Print(i);
                    }
                }
                else
                {
                    if (mas[i] % 2 == 1)
                    {
                        Console.WriteLine(i);
                        Print(i);
                    }
                }
            }
            Thread.Sleep(1000);
            flag = true;
        }
        public static void Del()
        {
            lock (lockOn)
            {

                for (int i = 0; i < n; i++)
                {
                    Monitor.Wait(lockOn);
                    if (mas[i] % 2 == 0)
                    {
                        Console.WriteLine(i);
                    }
                    else
                    {
                        Monitor.Pulse(lockOn);
                        Monitor.Wait(lockOn);
                        return;
                    }


                }
            }
        }

        public static void DontDel()
        {
            lock (lockOn)
            {

                for (int i = 0; i < n; i++)
                {
                    Monitor.Wait(lockOn);
                    if (mas[i] % 2 == 1)
                    {
                        Console.WriteLine(i);
                    }
                    else
                    {
                        Monitor.Pulse(lockOn);
                        Monitor.Wait(lockOn);
                        return;
                    }
                }

            }
        }

        public static void Count(object obj)
        {
            int x = (int)obj;
            for (int i = 1; i < 9; i++, x++)
            {
                Console.WriteLine("{0}", x * i);
            }
        }
    }
}

    
