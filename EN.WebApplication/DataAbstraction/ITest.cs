using EN.WebApplication.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EN.WebApplication.DataAbstraction
{
    public interface ITest
    {
        List<TestQuestion> GetModuleQuestion();


    }
}