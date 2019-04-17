using System;
using CoreFinance.Domain.Repositories;

namespace CoreFinance.Domain.Accounts
{
    public class UpdateAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public UpdateAccountService() { }

        public UpdateAccountService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public virtual void Update(string uuid, string propertyUuid, string name, int priority, Owner owner)
        {
            var account = _accountRepository.Get(uuid, propertyUuid);

            account.Update(name, priority, owner);

            UpdateTransactions(account);

            _accountRepository.Update(account);
        }

        private void UpdateTransactions(Account account)
        {
            var transactions = _transactionRepository.GetFromAccount(account.PropertyUuid, account.Uuid);

            foreach (var transaction in transactions)
            {
                transaction.UpdateAccount(account);
                _transactionRepository.Update(transaction);
            }
        }
    }
}
