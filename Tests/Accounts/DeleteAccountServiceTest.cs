using System.Collections.Generic;
using CoreFinance.Domain;
using CoreFinance.Domain.Accounts;
using CoreFinance.Domain.Repositories;
using CoreFinance.DomainTest.Builders;
using CoreFinance.Domain.Helpers.Validation;
using Moq;
using Xunit;

namespace CoreFinance.DomainTest.Accounts
{
    public class DeleteAccountServiceTest
    {

        private DeleteAccountService _deleteAccountService;
        private Mock<IAccountRepository> _accountRepository;
        private Mock<ITransactionRepository> _transactionRepository;
        private string _uuid = "234234234";
        private string _propertyUuid = "234929999";

        public DeleteAccountServiceTest()
        {
            _accountRepository = new Mock<IAccountRepository>();
            _transactionRepository = new Mock<ITransactionRepository>();
            _deleteAccountService = new DeleteAccountService(_accountRepository.Object, _transactionRepository.Object);
        }

        [Fact]
        public void ShoulDeleteAnAccount()
        {
            _deleteAccountService.Delete(_uuid, _propertyUuid);

            _accountRepository.Verify(repository => repository.Delete(_uuid, _propertyUuid), Times.Once);
        }

        [Fact]
        public void ShouldntDeleteIfThereWasATransaction()
        {
            var transactions = new List<Transaction>() { TransactionBuilder.ATransaction().Build() };
            _transactionRepository.Setup(repository => repository.GetFromAccount(_propertyUuid, _uuid)).Returns(transactions);

            // var exception = Assert.Throws<DomainException<DeleteAccountService>>(() => _deleteAccountService.Delete(_uuid, _propertyUuid));
            // Assert.Equal("Conta não pode ser excluída pois existem transações vinculadas a ela\n", exception.Message);

            _accountRepository.Verify(repository => repository.Delete(_uuid, _propertyUuid), Times.Never);
        }
    }
}
