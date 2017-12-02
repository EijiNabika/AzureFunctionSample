using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Table;

namespace FunctionAppSample
{
    public static class Sample5
    {
        [FunctionName("Sample5")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")]HttpRequestMessage req, [Table("person", Connection = "")]ICollector<Person> outTable, TraceWriter log)
        {
            dynamic data = await req.Content.ReadAsAsync<object>();
            string name = data?.name;
            int age = data?.Age;

            if (name == null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name in the request body");
            }

            outTable.Add(new Person()
            {
                PartitionKey = "Functions",
                RowKey = Guid.NewGuid().ToString(),
                Name = name,
                Age = age,
            });
            return req.CreateResponse(HttpStatusCode.Created);
        }
        /*
        public class Person : TableEntity
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }*/
    }
}
