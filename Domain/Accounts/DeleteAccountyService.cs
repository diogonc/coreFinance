using System.Linq;
using CoreFinance.Domain.Helpers.Validation;
using CoreFinance.Domain.Repositories;

namespace CoreFinance.Domain.Accounts
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
            if (transactions.Any())
                return;

            Validations<DeleteAccountService>.Build()
                            .When(transactions.Any(), "Conta não pode ser excluída pois existem transações vinculadas a ela")
                            .Thwros();

            _accountRepository.Delete(uuid, propertyUuid);
        }
    }
}
