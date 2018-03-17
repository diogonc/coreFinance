using System;
using Domain.Repositories;

namespace Domain.Accounts
{
    public class UpdateOwnerService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly UpdateAccountService _updateAccountService;

        public UpdateOwnerService(IAccountRepository accountRepository, IOwnerRepository ownerRepository, UpdateAccountService updateAccountService)
        {
            _accountRepository = accountRepository;
            _ownerRepository = ownerRepository;
            _updateAccountService = updateAccountService;
        }

        public void Update(string uuid, string propertyUuid, string userLogin,  string name, int priority)
        {
            var owner = _ownerRepository.Get(uuid, propertyUuid);

            owner.Update(name, userLogin, priority);

            var accounts = _accountRepository.GetFromOwner(propertyUuid, owner.Uuid);
            foreach (var account in accounts)
            {
                _updateAccountService.Update(account.Uuid, propertyUuid, account.Name, account.Priority, owner);
            }

            _ownerRepository.Update(owner);
        }
    }
}
