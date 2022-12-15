using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BasicAzureFunc
{
    public static class BasicFunc
    {
        [FunctionName("BasicFunc")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];
            string Add = req.Query["Add"];

            string responseMessage = string.IsNullOrEmpty(name)
                ? "Triggered. Pass Details in the query string"
                : string.Format(@"<table >
                                    <thead>
                                        <tr>
                                            <th>Name</th>
                                            <th>Address</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>{0}</td>
                                            <td>{1}</td>
                                        </tr>
                                    </tbody>
                                  </table> <br />
                                   This HTTP triggered function executed successfully.", name, Add);
           
            return new ContentResult
            { 
                ContentType="text/html",
                Content= responseMessage
            };
        }
    }
}







































 /*string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;*/