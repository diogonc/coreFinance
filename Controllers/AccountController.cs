using CoreFinance.Domain.Accounts;
using CoreFinance.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CoreFinance.ViewModels;

namespace CoreFinance.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private IAccountRepository _accountRepository;
        private IOwnerRepository _ownerRepository;
        private UpdateAccountService _updateAccountService;
        private DeleteAccountService _deleteAccountService;

        public AccountController(IAccountRepository accountRepository, IOwnerRepository ownerRepository,
             UpdateAccountService updateAccountService, DeleteAccountService deleteAccountService)
        {
            _accountRepository = accountRepository;
            _ownerRepository = ownerRepository;
            _updateAccountService = updateAccountService;
            _deleteAccountService = deleteAccountService;
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
        public CreatedViewModel Post([FromBody]AccountViewModel accountViewModel)
        {
            accountViewModel.PropertyUuid = Request.Headers["propertyuuid"];
            var owner = (accountViewModel.Owner != null && string.IsNullOrWhiteSpace(accountViewModel.Owner.Uuid))
             ? _ownerRepository.Get(accountViewModel.Owner.Uuid, accountViewModel.PropertyUuid)
             : null;

            var account = new Account(accountViewModel.PropertyUuid, accountViewModel.Name, accountViewModel.Priority, owner);
            _accountRepository.Create(account);

            return new CreatedViewModel(account.Uuid);
        }

        [HttpPut("{uuid}")]
        public ActionResult Put(string uuid, [FromBody]AccountViewModel accountViewModel)
        {
            accountViewModel.PropertyUuid = Request.Headers["propertyuuid"];

            var owner = (accountViewModel.Owner != null && string.IsNullOrWhiteSpace(accountViewModel.Owner.Uuid))
                         ? _ownerRepository.Get(accountViewModel.Owner.Uuid, accountViewModel.PropertyUuid)
                         : null;
            _updateAccountService.Update(uuid, accountViewModel.PropertyUuid, accountViewModel.Name,
                                    accountViewModel.Priority, owner);

            return Ok();
        }

        [HttpDelete("{uuid}")]
        public ActionResult Delete(string uuid)
        {
            var propertyUuid = Request.Headers["propertyuuid"];

            _deleteAccountService.Delete(uuid, propertyUuid);

            return Ok();
        }
    }
}
