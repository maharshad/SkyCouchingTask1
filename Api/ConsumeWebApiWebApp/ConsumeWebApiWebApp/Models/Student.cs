using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeWebApiWebApp.Models
{
    public class Student
    {

        public int rollno { get; set; }
        public string fullname { get; set; }
        public Nullable<int> @class { get; set; }
        public Nullable<int> year { get; set; }
        public string gender { get; set; }
        public Nullable<bool> job { get; set; }

    } 
}