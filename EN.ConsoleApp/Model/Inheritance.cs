using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN.ConsoleApp.Model
{
    public class Baseclass
    {
        int i;
        private int j;
        public Baseclass(int ii)
        {
            i = ii;
            j = ii;
            Console.WriteLine("Base WriteLine");
            Console.Write("Base {0}", i.ToString());

            string[] array = new string[10];
            array[0] = "Kanagavel";
            array[1] = "A";
            array[2] = "R";
            array[3] = "B";
        }
    }
    public class Derived : Baseclass
    {
        public Derived(int ii) : base(ii)
        {
            try
            {
                Console.Write(" Derived ");
                if (!System.IO.File.Exists("d:/abc.txt"))
                    System.IO.File.Create("d:/abc.txt");

            }
            catch (Exception ex)
            {

            }

        }

    }

    interface IBaseClass
    {
        void CreateFile();
    }
}
