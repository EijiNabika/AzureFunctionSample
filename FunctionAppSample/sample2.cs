using System.Linq;
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
    public static class sample2
    {
        [FunctionName("sample2")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")]HttpRequestMessage req, [Table("person", Connection = "")]ICollector<Person> outTable, TraceWriter log)
        {
            log.Info("�J�n");
            //dynamic data = await req.Content.ReadAsAsync<object>();
            //string name = data?.name;
            // parse query parameter
            string name = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
                .Value;
            if (name == null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "���N�G�X�g�p�����[�^���Z�b�g���ׂ�");
            }

            outTable.Add(new Person()
            {
                PartitionKey = "Functions",
                RowKey = Guid.NewGuid().ToString(),
                Name = name
            });
            return req.CreateResponse(HttpStatusCode.Created);
        }
/*
        public class Person : TableEntity
        {
            public string Name { get; set; }
        }*/
    }
}
