using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EN.WebApplication.Models
{

    public class AttendaceModel
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string ShiftName { get; set; }
        public List<InOutTime> Attendance { get; set; }
    }

    public class InOutTime
    {
        public int AttendanceDate { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
    }
}