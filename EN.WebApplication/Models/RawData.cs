using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EN.WebApplication.Models
{
    public class RawData
    {
        public string EmployeeName { get; set; }
        public int Id { get; set; }
        public DateTime EntryDateTime { get; set; }
        public string Status { get; set; }
    }
}