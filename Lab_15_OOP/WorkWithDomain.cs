using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_15_OOP
{
    class WorkWithDomain
    {
        AppDomain myD = AppDomain.CurrentDomain;

        public void InfoAboutDomain()
        {
            Console.WriteLine("Имя домена: " + myD.FriendlyName);
            Console.WriteLine("Сведения о конфигурации домена: "+ myD.SetupInformation);
            Console.WriteLine("Сборки, загруженные в проект: " + myD.DynamicDirectory);
        }

        public void CreateOfNewD()
        {
            AppDomain newD = AppDomain.CreateDomain("NewDomain");
            newD.Load("LoadProject");
            AppDomain.Unload(newD);
        }
    }
}
