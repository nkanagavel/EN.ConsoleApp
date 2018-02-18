﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EN.WebApplication.DomainModel
{
    public class TestQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Answer { get; set; }
    }
}