using Domain.Accounts;
using DomainTest.Builders;
using Xunit;
using Moq;
using Domain.Repositories;
using System.Collections.Generic;
using Domain;
using System.Linq;

namespace DomainTest.Accounts
{
    public class UpdateAccountServiceTest
    {
        private Mock<IAccountRepository> _accountRepository;
        private Mock<ITransactionRepository> _transactionRepository;
        private UpdateAccountService _updateAccountService;
        private Account _account;
        private Owner _owner;

        public UpdateAccountServiceTest()
        {
            _accountRepository = new Mock<IAccountRepository>();
            _transactionRepository = new Mock<ITransactionRepository>();

            _updateAccountService = new UpdateAccountService(_accountRepository.Object, _transactionRepository.Object);

            _account = AccountBuilder.AnAccount().Build();
            _owner = new Owner(_account.PropertyUuid, "7", "luis", 9);
            _accountRepository.Setup(repository => repository.Get(_account.Uuid, _account.PropertyUuid)).Returns(_account);

        }

        [Fact]
        public void ShouldUpdateAnAccount()
        {
            _updateAccountService.Update(_account.Uuid, _account.PropertyUuid, "new name", 2, _owner);

            Assert.Equal("new name", _account.Name);
            _accountRepository.Verify(repository => repository.Update(_account), Times.Once);
        }

        [Fact]
        public void ShouldUpdateAllTransactions()
        {
            var transactions = new List<Transaction> { TransactionBuilder.ATransaction().Build(), TransactionBuilder.ATransaction().Build() };
            _transactionRepository.Setup(repository => repository.GetFromAccount(_account.PropertyUuid, _account.Uuid))
                                  .Returns(transactions);

            _updateAccountService.Update(_account.Uuid, _account.PropertyUuid, "new name", 2, _owner);

            _transactionRepository.Verify(repository => repository.Update(transactions.FirstOrDefault()), Times.Once);
            _transactionRepository.Verify(repository => repository.Update(transactions.LastOrDefault()), Times.Once);
        }
    }
}
