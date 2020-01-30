using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Google.Cloud.Datastore.V1;
using Grpc.Core;
using Grpc.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Produces("application/json")]
    [Route("Products")]
    public class ProductController : Controller
    {

        string projectId = "myretail-266614";
        int[] productIDs = { 13860428 };
        HttpClient client= new HttpClient();
        string baseURL = "https://redsky.target.com/v2/pdp/tcin/";
        //string uri =     "https://redsky.target.com/v2/pdp/tcin/13860428?excludes=taxonomy,price,promotion,bulk_ship,rating_and_review_reviews,rating_and_review_statistics,question_answer_statistics";
        string exclude= "? excludes = taxonomy, promotion, bulk_ship, rating_and_review_reviews, rating_and_review_statistics, question_answer_statistics,circleoffers ";
        DatastoreClient datastoreClient = DatastoreClient.Create();
        string kind = "Product";
        // GET: api/Product
        [HttpGet]
        public async Task<IEnumerable<ProductResponseData>> GetAsync()
        {
            List<ProductResponseData> products = new List<ProductResponseData>();
            for (int i=0;i<productIDs.Length;i++) {
                ProductResponseData product = await UpsertToDB(productIDs[i]);
                if (product!=null) {
                    products.Add(product);
                }
               
            }
          
            return products;
        }
        private async Task<ProductResponseData> UpsertToDB(int productid) {
            DatastoreDb db = DatastoreDb.Create(projectId, "ProductNamespace", datastoreClient);
        
            ProductResponseData productResponseData = null;
            try
            {
                string getProductURL = baseURL + productid+exclude;
                string responseBody = await client.GetStringAsync(getProductURL);

                productResponseData = JsonConvert.DeserializeObject<ProductResponseData>(responseBody);
                Console.WriteLine(responseBody);

                string name = productid + "";
                //CurrentPrice currentPrice = new CurrentPrice();
                //currentPrice.value = productResponseData.product.price.listPrice.price;
                //currentPrice.currency_code = "USD";
                double price = productResponseData.product.price.listPrice.price;
                KeyFactory keyFactory = db.CreateKeyFactory(kind);
                Key key = keyFactory.CreateKey(name);

                var task = new Entity
                {
                    Key = key,
                    ["productid"] = name,
                    ["price"] = price,
                    ["currency_code"] = "USD"

                };
                upsert(db, task);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }



           
            return productResponseData;
        }
        private void upsert(DatastoreDb db, Entity entity)
        {
            GrpcEnvironment.SetLogger(new ConsoleLogger());

            using (DatastoreTransaction transaction = db.BeginTransaction())
            {
                transaction.Upsert(entity);
                transaction.Commit();
            }

        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult> GetAsync(int id)
        {
            ProductObject response = new ProductObject();
            try
            {

                //response.EnsureSuccessStatusCode();
                //string responseBody = await response.Content.ReadAsStringAsync();
                //Above three lines can be replaced with new helper method below
                string getProductURL = baseURL + id + exclude;
                string responseBody = await client.GetStringAsync(getProductURL);

                ProductResponseData productResponseData = JsonConvert.DeserializeObject<ProductResponseData>(responseBody);
                response.id = id;
                response.name = productResponseData.product.item.product_description.title;
                response.current_price = getCurrentPrice(id);
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                if (e is HttpRequestException)
                {
                    Console.WriteLine("\n HTTP get Product Response Error");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
            return Ok(response);
        }

        private CurrentPrice getCurrentPrice(int id)
        {
            CurrentPrice currentPriceObject = new CurrentPrice();
           
            DatastoreDb db = DatastoreDb.Create(projectId, "ProductNamespace", datastoreClient);
            KeyFactory keyFactory = db.CreateKeyFactory(kind);
            string name = id + "";
            Key key = keyFactory.CreateKey(name);
            using (DatastoreTransaction transaction = db.BeginTransaction())
            {
                Entity currentProduct = transaction.Lookup(key);
                transaction.Commit();
                Value price, currency_code;
                if (currentProduct.Properties.TryGetValue("price", out price)) {
                    
                    currentPriceObject.value = price.DoubleValue;
                }
                if (currentProduct.Properties.TryGetValue("currency_code", out currency_code))
                {
                    currentPriceObject.currency_code = currency_code.StringValue;
                }
            }
            return currentPriceObject;

        }

        // POST: api/Product
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}
        
        // PUT: api/Product/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]ProductObject product)
        {
            if (id != product.id) 
            {
                return BadRequest("PUT id is different from json body productid");
            }            //ProductObject product = JsonConvert.DeserializeObject<ProductObject>(value);
            DatastoreDb db = DatastoreDb.Create(projectId, "ProductNamespace", datastoreClient);
            string name = product.id + "";
            double price = product.current_price.value;
            string currency_code = product.current_price.currency_code;
            KeyFactory keyFactory = db.CreateKeyFactory(kind);
            Key key = keyFactory.CreateKey(name);
            using (DatastoreTransaction transaction = db.BeginTransaction())
            {
                Entity currentProduct = transaction.Lookup(key);
                transaction.Commit();
                Value productid;
                if (currentProduct ==null ||!currentProduct.Properties.TryGetValue("productid", out productid))
                {
                    return NotFound("Productid:"+name+" does not exist");
                }               
            }
            var task = new Entity
            {
                Key = key,
                ["productid"] = name,
                ["price"] = price,
                ["currency_code"] = currency_code

            };
            try
            {
                upsert(db, task);
            }
            catch (Exception e){
                if (Debugger.IsAttached)
                {
                    return Content("Productid:" + name + " might not be updated.\n" + e.StackTrace);
                }
                else {
                    return BadRequest("Productid:" + name + " might not be updated.\n");
                }
               
            }
         
            return Ok("Productid:" + name + " is updated");
        }
        
        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
