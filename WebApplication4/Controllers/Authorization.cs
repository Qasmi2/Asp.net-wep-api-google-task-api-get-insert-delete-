using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Tasks.v1;
using Google.Apis.Tasks.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

using System.IO;
using System.Threading;
using System.Threading.Tasks;


namespace WebApplication4.Controllers
{
    public class Authorization
    {


        public TasksService service;

        public Authorization()
        {
            System.Threading.Tasks.Task<TasksService> task = System.Threading.Tasks.Task.Run<TasksService>(async () => await RunAsync());
            service = task.Result;
        }



        public async Task<TasksService> RunAsync()
        {
            var clientId = "792098940629-ocdlmose3reo78in6c61mpfaoj9htblp.apps.googleusercontent.com";
            var clientSecret = "_9CVAqCDxfa-MX_0Hexd92Ge";

            UserCredential credential;
            credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
        new ClientSecrets
        {
            ClientId = clientId,
            ClientSecret = clientSecret
        },
    new[] { TasksService.Scope.Tasks, TasksService.Scope.TasksReadonly },
    "user",
    CancellationToken.None,
    new FileDataStore("account.users"));

            // Create the service.
            var _service = new TasksService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Google Tasks Application",
            });

            return _service;
        }
        
    }
}