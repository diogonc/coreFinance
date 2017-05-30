using Domain;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CoreFinance.ViewModels;

namespace CoreFinance.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet("")]
        public IEnumerable<Account> Get()
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            return _accountRepository.GetAll(propertyUuid);
        }

        [HttpGet("{uuid}")]
        public Account Get(string uuid)
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            return _accountRepository.Get(uuid, propertyUuid);
        }

        [HttpPost]
        public string Post([FromBody]AccountViewModel accountViewModel)
        {
            accountViewModel.PropertyUuid = Request.Headers["propertyuuid"];
            var account = new Account(accountViewModel.PropertyUuid, accountViewModel.Name, accountViewModel.Priority);
            _accountRepository.Create(account);
            return account.Uuid;
        }

        [HttpPut("{uuid}")]
        public void Put(string uuid, [FromBody]AccountViewModel accountViewModel)
        {
            accountViewModel.PropertyUuid = Request.Headers["propertyuuid"];
            var account = new Account(uuid, accountViewModel.PropertyUuid, accountViewModel.Name, accountViewModel.Priority);
            _accountRepository.Update(account);
        }

        [HttpDelete("{uuid}")]
        public void Delete(string uuid)
        {
            var propertyUuid = Request.Headers["propertyuuid"];
            _accountRepository.Delete(uuid, propertyUuid);
        }
    }
}
