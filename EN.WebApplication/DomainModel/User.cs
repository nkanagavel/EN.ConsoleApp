using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EN.WebApplication.DomainModel
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IcNumber { get; set; }
        public string MailId { get; set; }
        public string Phonenumber { get; set; }
    }
}