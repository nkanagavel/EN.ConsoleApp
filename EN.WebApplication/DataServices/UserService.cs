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
    public class UserService : IUser
    {
        private IDbConnection _dbconnection = new SqlConnection(ConfigurationManager.AppSettings["DapperDbConString"].ToString());
        public User GetUserById(int userId)
        {
            var user = _dbconnection.Query<User>("SELECT * FROM UsersRegister Where Id=@Id", new { Id = userId }).FirstOrDefault();
            return user;
        }

        public List<User> GetUsers()
        {
            var users = _dbconnection.Query<User>("SELECT * FROM UsersRegister").ToList();
            return users;
        }

        public int RegisterUser(User user)
        {
            string query = "INSERT INTO UsersRegister(Name,IcNumber,MailId,Phonenumber) VALUES(@Name,@IcNumber,@MailId,@Phonenumber)";
            var rowaffected = _dbconnection.Execute(query, new { Name = user.Name, IcNumber = user.IcNumber, MailId = user.MailId, Phonenumber = user.Phonenumber }, commandType: CommandType.Text);
            return rowaffected;
        }

        public int UpdateUser(User user)
        {
            try
            {
                string query = "UPDATE UsersRegister SET Name = @Name,IcNumber=@IcNumber,MailId=@MailId,Phonenumber=@Phonenumber WHERE Id =@Id";
                var rowaffected = _dbconnection.Execute(query, new { Id = user.Id, Name = user.Name, IcNumber = user.IcNumber, MailId = user.MailId, Phonenumber = user.Phonenumber }, commandType: CommandType.Text);
                return rowaffected;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}