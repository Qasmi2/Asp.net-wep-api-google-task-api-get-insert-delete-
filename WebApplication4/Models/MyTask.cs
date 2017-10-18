using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class MyTask
    {
        public string id { get; set; }
        public string title { get; set; }
        
    }

    public class MyTaskInsert
    {
        public string title { get; set; }
        public string note { get; set; }

    }
}