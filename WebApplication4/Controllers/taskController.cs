
using System.Web.Http;

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
    public class TaskController : ApiController
    {
        // authorization object
        Authorization auth = new Authorization();


        /// <summary>
        /// show/all the Task of default tasklist 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/task/TaskListall")]
        public List<MyTask> GetTask()
        {
            List<MyTask> myList = new List<MyTask>();

            var response = auth.service.Tasks.List("@default");
            var result = response.Execute();
            var tasks = result.Items;

            if (tasks != null && tasks.Count > 0)
            {
                foreach (Task task in tasks)
                {
                    MyTask a = new MyTask();
                    a.id = task.Id;
                    a.title = task.Title;
                    myList.Add(a);
                }
               
            }
            else
            {
               //return prompt about NO Tasks 
            }
            return myList;
        }


        // insert task into default tasklist 
        // function 
        [HttpPost]
        [Route("api/task/defaultTasklist/insertTask")]

        public string taskInsert()
        {

            Task task = new Task { Title = "New Task"};
            task.Notes = "Please testing me ";
            task.Due = System.DateTime.Today;

            var response  =auth.service.Tasks.Insert(task, "@default");
            var result = response.Execute();
            return "successfull inserted task";
        }
        
        // Clear All the task into Default Task list 

        [HttpDelete]
        [Route("api/task/clearallTasks")]
        public string clearTask()
        {
            var response = auth.service.Tasklists.Get("@default");
            if (response.Tasklist == "@default")
            {    // condition that all the the task are completed or selected for clear 
                var result = response.Execute();
                var responses = auth.service.Tasks.Clear(result.Id);
                var resultes = responses.Execute();
               
                return "Successful Clear all the completed tasks of the default Tasklsit";
            }
           else
            {
                return "No default Tasklist is exist and there are no Tasks ";
            }
        }

        //delete the Specific task
        [HttpDelete]
        [Route("api/task/DeletedTask")]
        public string deleteTask(string taskid)
        { // condition that deleted task is selected or not 
            var response = auth.service.Tasks.Delete("@default",taskid);
            var result = response.Execute();
            return "successful deleted selected task ";
        }

    

        //get specifically selected task
        [HttpGet]
        [Route("api/task/showtask")]
        public List<GetTask> GetTask(string taskid)
        {
            List<GetTask> mytask = new List<GetTask>();
            var response = auth.service.Tasks.Get("@default",taskid);
            var result = response.Execute();
            GetTask a = new GetTask();
           
            a.title = result.Title;
            a.note = result.Notes;

            mytask.Add(a);

            return mytask;

        }




    }
}
