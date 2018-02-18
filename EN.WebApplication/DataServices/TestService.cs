using EN.WebApplication.DataAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EN.WebApplication.DomainModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace EN.WebApplication.DataServices
{
    public class TestService : ITest
    {
        private IDbConnection _dbconnection = new SqlConnection(ConfigurationManager.AppSettings["DapperDbConString"].ToString());

        public List<TestQuestion> GetModuleQuestion()
        {
            var employees = _dbconnection.Query<TestQuestion>("SELECT * FROM Details").ToList();          
            return employees;
        }
    }
}