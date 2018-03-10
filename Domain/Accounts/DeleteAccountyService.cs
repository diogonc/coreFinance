using System.Linq;
using Domain.Helpers.Validation;
using Domain.Repositories;

namespace Domain.Accounts
{
    public class DeleteAccountService
    {
        private IAccountRepository _accountRepository;
        private ITransactionRepository _transactionRepository;


        public DeleteAccountService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }

        public void Delete(string uuid, string propertyUuid)
        {
            var transactions = _transactionRepository.GetFromAccount(propertyUuid, uuid);
            Validations<DeleteAccountService>.Build()
                            .When(transactions.Any(), "Conta não pode ser excluída pois existem transações vinculadas a ela")
                            .Thwros();

            _accountRepository.Delete(uuid, propertyUuid);
        }
    }
}
