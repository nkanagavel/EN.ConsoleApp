using EN.WebApplication.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN.WebApplication.DataAbstraction
{
    public interface IUser
    {
        int RegisterUser(User user);

        List<User> GetUsers();

        User GetUserById(int userId);
        int UpdateUser(User user);

    }
}
