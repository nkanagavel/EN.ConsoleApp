using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN.ConsoleApp.DAL
{
    public class Polymorphism
    {
        public void Area(int i)
        {
            Console.WriteLine("Polymorphism-Area-Single Overload - {0}",i);
        }
        public int Area(int i,int j)
        {
            return i+j;
        }
    }
}
