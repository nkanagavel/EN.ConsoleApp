using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN.ConsoleApp.DAL
{
    public class AbstractInterface :  abstract1,IInterface1
    {
        public override void AbstractFun()
        {
            Console.WriteLine("Oops Class - AbstarctFun implemented.");
        }

        public override void AbstractFun2()
        {
            Console.WriteLine("Oops Class - AbstarctFun2 implemented.");
        }
            
        public new void InterfaceFun1()
        {
            Console.WriteLine("Oops Class - InterfaceFun implemented.");
        }
    }

    public abstract class abstract1 : abstract2
    {
        public abstract1()
        {
            Console.WriteLine("abstract1 Constructor.");
        }

        public abstract void AbstractFun();
        
        public void NonAbstarctFun()
        {
            Console.WriteLine("abstract1 - NonAbstarctFun.");
        }
    }

    public abstract class abstract2 : IInterface2
    {
        public abstract2()
        {
            Console.WriteLine("abstract2 Constructor.");
        }

        public abstract void AbstractFun2();

        public void NonAbstarctFun2()
        {
            Console.WriteLine("abstract2 - NonAbstarctFun.");
        }

        public void InterfaceFun2()
        {
            Console.WriteLine("abstract2 - InterfaceFun2 funtion inplemented in abstract2.");
        }

        public void InterfaceFun1()
        {
            Console.WriteLine("abstract2 - InterfaceFun1 funtion inplemented in abstract2.- This is in Interface 1 and interface2 inherited this.");
        }
    }

    interface IInterface1 {

        void InterfaceFun1();
    }

    interface IInterface2 : IInterface1
    {
        void InterfaceFun2();
    }

}
