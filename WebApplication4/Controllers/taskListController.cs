using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using Google.Apis.Tasks.v1;
using Google.Apis.Tasks.v1.Data;
using System.Web.Http;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class taskListController : ApiController
    {
        Authorization auth = new Authorization();
        
        [HttpGet]
        [Route("api/TaskListAll")]
        public List<MyTaskList> GetTaskList()

        {
            var response = auth.service.Tasklists.List();
            var result = response.Execute();
            var items = result.Items;
            if (items != null && items.Count > 0)
            {
                List<MyTaskList> myLists = new List<MyTaskList>();

                foreach (var i in items)
                {
                    MyTaskList a = new MyTaskList();
                    a.Id = i.Id;
                    a.title = i.Title;

                    myLists.Add(a);
                }


                return myLists;
            }
            else
            {
                return null;
            }


            
        }


        // the followoing function will be used as per requirement. 

         //function insert tasklist change into post 
        [HttpPost]
        [Route("api/taskList/insert")]
        public string InsertTaskList()
        {
            TaskList list = new TaskList { Title = "Qasmi" };
            var response = auth.service.Tasklists.Insert(list);
            var result = response.Execute();
            var items = result.Id;
            return "Your Task is successfull inserted ";
        }

        //  delete function will be change httpDelete 
        [HttpGet]
        [Route("api/taskList/{id}")]
        public string deletetakelist(string id)
        {

            var response = auth.service.Tasklists.Delete(id);
            var result = response.Execute();
            return "successful Deleted TaskList";
        }


        // get/show function of single tasklist 
        [HttpGet]
        [Route("api/defaultTasklist")]
        public List<MyTaskListGet> GetTaskListShow()
        {
            List<MyTaskListGet> myList = new List<MyTaskListGet>();
            var response = auth.service.Tasklists.Get("@default");
            if (response.Tasklist == "@default")
            {
                var result = response.Execute();

                MyTaskListGet a = new MyTaskListGet();
                a.id = result.Id;
                a.title = result.Title;

                myList.Add(a);
                return myList;
            }
            else
            {

                // return no deault list exit, create one 
                return null;
            }
            
        }

       


    }
}







