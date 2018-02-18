using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN.ConsoleApp.DAL
{
    // delegate <return type> <delegate-name> <parameter list>
    public class delegateExamples
    {
        public delegateExamples()
        {

        }
        public int valueOfA { get; set; } = 2;

        public double SumValue(int a) => valueOfA + a;
        public double Muliply(int a) => valueOfA * a;


    }
}
