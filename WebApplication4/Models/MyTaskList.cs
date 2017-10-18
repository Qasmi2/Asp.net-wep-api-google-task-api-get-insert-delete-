using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class MyTaskList
    {
        public string Id { get; set; }
        public string title { get; set; }
    }


    public class MyTaskListGet
    {
        public string id { get; set; }
        public string title { get; set; }
    }

   
}