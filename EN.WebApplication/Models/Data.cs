using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EN.WebApplication.Models
{
    public class Data
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }

        public int ShiftType { get; set; }
    }
}