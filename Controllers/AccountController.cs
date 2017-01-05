using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using financeApi.Repositories;
using financeApi.Models;

namespace financeApi.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private IAccountRepository _accountRepository;
        
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        // GET api/values
        [HttpGet("{propertyUuid}")]
        public IEnumerable<Account> Get(string propertyUuid)
        {
            return _accountRepository.GetAll(propertyUuid);
        }

        // GET api/values/5
        [HttpGet("{propertyUuid}/{uuid}")]
        public Account Get(string propertyUuid, string uuid)
        {
            return _accountRepository.Get(uuid);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Account account)
        {
            _accountRepository.Create(account);
        }

        // PUT api/values/5
        [HttpPut("{uuid}")]
        public void Put(int uuid, [FromBody]Account account)
        {
            _accountRepository.Update(account);
        }

        // DELETE api/values/5
        [HttpDelete("{uuid}")]
        public void Delete(string uuid)
        {
            _accountRepository.Delete(uuid);
        }
    }
}
