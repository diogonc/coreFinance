using CoreFinance.Domain.Accounts;
using CoreFinance.DomainTest.Builders;
using Xunit;
using Moq;
using CoreFinance.Domain.Repositories;
using System.Collections.Generic;
using CoreFinance.Domain;
using System.Linq;

namespace CoreFinance.DomainTest.Categories
{
    public class UpdateOwnerServiceTest
    {
        private Mock<IAccountRepository> _accountRepository;
        private Mock<IOwnerRepository> _ownerRepository;
        private Mock<UpdateAccountService> _updateAccountService;
        private UpdateOwnerService _updateOwnerService;
        private Account _account;
        private Owner _owner;

        public UpdateOwnerServiceTest()
        {
            _accountRepository = new Mock<IAccountRepository>();
            _ownerRepository = new Mock<IOwnerRepository>();
            _updateAccountService = new Mock<UpdateAccountService>();

            _updateOwnerService = new UpdateOwnerService(_accountRepository.Object, _ownerRepository.Object, _updateAccountService.Object);

            _account = AccountBuilder.AnAccount().Build();
            _owner = new Owner(_account.PropertyUuid, "7", "gname", 9);
            _ownerRepository.Setup(repository => repository.Get(_owner.Uuid, _owner.PropertyUuid)).Returns(_owner);

        }

        [Fact]
        public void ShouldUpdateAnOwner()
        {
            _updateOwnerService.Update(_owner.Uuid, _owner.PropertyUuid, _owner.UserLogin, "new name", 2);

            Assert.Equal("new name", _owner.Name);
            _ownerRepository.Verify(repository => repository.Update(_owner), Times.Once);
        }

        [Fact]
        public void ShouldUpdateAllAccounts()
        {
            var firstAccount = AccountBuilder.AnAccount().WithName("teste").Build();
            var secondCategory = AccountBuilder.AnAccount().WithName("outro").Build();

            var accounts = new List<Account>() {
                firstAccount, secondCategory
            };
            _accountRepository.Setup(repository => repository.GetFromOwner(_owner.PropertyUuid, _owner.Uuid))
                                  .Returns(accounts);

            _updateOwnerService.Update(_owner.Uuid, _owner.PropertyUuid, _owner.UserLogin, "new name", 2);

            _updateAccountService.Verify(service => service.Update(firstAccount.Uuid, firstAccount.PropertyUuid, firstAccount.Name
                     , firstAccount.Priority, It.Is<Owner>(owner => owner.Name == "new name"))
                                 , Times.Once);
            _updateAccountService.Verify(service => service.Update(secondCategory.Uuid, secondCategory.PropertyUuid, secondCategory.Name
                    , firstAccount.Priority, It.Is<Owner>(owner => owner.Name == "new name"))
                                 , Times.Once);
        }
    }
}
