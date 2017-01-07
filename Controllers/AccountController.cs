using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using financeApi.Repositories;
using financeApi.Models;
using System;

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

        // GET api/account
        [HttpGet("")]
        public IEnumerable<Account> Get()
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            return _accountRepository.GetAll(propertyUuid);
        }

        // GET api/values/5
        [HttpGet("{uuid}")]
        public Account Get(string uuid)
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            return _accountRepository.Get(uuid, propertyUuid);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string Name)
        {
            var guid = Guid.NewGuid();
            //_accountRepository.Create(account);
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
            var propertyUuid = Request.Headers["propertyuuid"];
            _accountRepository.Delete(uuid, propertyUuid);
        }
    }
}
