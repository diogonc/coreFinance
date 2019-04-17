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
    public class DeleteOwnerServiceTest
    {

        private DeleteOwnerService _deleteOwnerService;
        private Mock<IOwnerRepository> _ownerRepository;
        private Mock<IAccountRepository> _accountRepository;
        private string _uuid = "234234234";
        private string _propertyUuid = "234929999";

        public DeleteOwnerServiceTest()
        {
            _ownerRepository = new Mock<IOwnerRepository>();
            _accountRepository = new Mock<IAccountRepository>();
            _deleteOwnerService = new DeleteOwnerService(_accountRepository.Object, _ownerRepository.Object);
        }

        [Fact]
        public void ShoulDeleteOwner()
        {
            _deleteOwnerService.Delete(_uuid, _propertyUuid);

            _ownerRepository.Verify(repository => repository.Delete(_uuid, _propertyUuid), Times.Once);
        }

        [Fact]
        public void ShouldntDeleteIfThereWasAnAccount()
        {
            var accounts = new List<Account>() { AccountBuilder.AnAccount().Build() };
            _accountRepository.Setup(repository => repository.GetFromOwner(_propertyUuid, _uuid)).Returns(accounts);

            // var exception = Assert.Throws<DomainException<DeleteCategoryService>>(() => _deleteCategoryService.Delete(_uuid, _propertyUuid));
            // Assert.Equal("Categoria não pode ser excluída pois existem transações vinculadas a ela\n", exception.Message);

            _ownerRepository.Verify(repository => repository.Delete(_uuid, _propertyUuid), Times.Never);
        }
    }
}
