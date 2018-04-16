using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Lab_15_OOP
{
  class WorkWithThread
    {

    public static Thread th = new Thread(Counter);

    public static void Counter()
    {
        StreamWriter sw = new StreamWriter("infoabouthread_1.txt");
        Console.WriteLine("Введите количество элементов: ");
        int count = 0;
        bool flag = false;
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Простые числа до " + n);
        sw.Write("Простые числа до " + n);
        for (int i = 2; i < n; i++)
        {
            for (int j = 2; j <= i; j++)
            {
                if (i % j == 0)
                {
                    if (i == j)
                        flag = true;
                    else
                        count++;
                }
            }
            if (flag == true && count == 0)
            {
                Console.WriteLine(i);
                sw.Write(i);
            }
            count = 0;
            flag = false;
        }
        Console.WriteLine("Поток имеет следующее состояние: " + th.ThreadState);
        Console.WriteLine("Имя потока: " + th.Name);
        Console.WriteLine("Приоритет потока: " + th.Priority);
        Console.WriteLine("Идентификатор потока" + th.ManagedThreadId);
    }
}
}
