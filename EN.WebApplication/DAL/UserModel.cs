using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EN.WebApplication.DAL
{
    [Table("Users")]
    public class UserModel
    {
        [Key]
        public int UsersId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }
}