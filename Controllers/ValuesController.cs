using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using financeApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;


namespace financeApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IMongoCollection<User> user;

        public ValuesController(MongoClient client)
        {
            var database = client.GetDatabase("finance");
            user = database.GetCollection<User>(nameof(user));
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            var allUserCursor = user.Find(FilterDefinition<User>.Empty).ToListAsync();
            allUserCursor.Wait();
            return allUserCursor.Result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
