using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Datastore.V1;
using Grpc.Core;
using Grpc.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Produces("application/json")]
    [Route("Products")]
    public class ProductController : Controller
    {
        // GET: api/Product
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Environment.SetEnvironmentVariable(
    "GOOGLE_APPLICATION_CREDENTIALS",
    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "my-credentials-file.json"));

            GrpcEnvironment.SetLogger(new ConsoleLogger());

            // Your Google Cloud Platform project ID
            string projectId = "myretail-266614";

            DatastoreClient datastoreClient = DatastoreClient.Create();

            DatastoreDb db = DatastoreDb.Create(projectId, "TestNamespace", datastoreClient);

            string kind = "MyTest";

            string name = "newentitytest3";
            KeyFactory keyFactory = db.CreateKeyFactory(kind);
            Key key = keyFactory.CreateKey(name);

            var task = new Entity
            {
                Key = key,
                ["test1"] = "Hello, World",
                ["test2"] = "Goodbye, World",
                ["new field"] = "test"
            };

            using (DatastoreTransaction transaction = db.BeginTransaction())
            {
                transaction.Upsert(task);
                transaction.Commit();
            }

            return new string[] { "value1", "value2" };
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value:"+id;
        }
        
        // POST: api/Product
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
