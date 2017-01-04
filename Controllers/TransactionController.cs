using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using financeApi.Repositories;
using System.Linq;

namespace financeApi.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        private IUserRepository _userRepository;
        
        public TransactionController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _userRepository.GetAll().Select(u => u.Username);
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
