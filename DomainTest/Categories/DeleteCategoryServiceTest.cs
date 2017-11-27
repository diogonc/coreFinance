using System.Collections.Generic;
using Domain;
using Domain.Categories;
using Domain.Repositories;
using DomainTest.Builders;
using Domain.Helpers.Validation;
using Moq;
using Xunit;

namespace DomainTest.Categories
{
    public class DeleteCategoryServiceTest{
        
        private DeleteCategoryService _deleteCategoryService;
        private Mock<ICategoryRepository> _categoryRepository;
        private Mock<ITransactionRepository> _transactionRepository;
        private string _uuid = "234234234";
        private string _propertyUuid = "234929999";

        public DeleteCategoryServiceTest()
        {
            _categoryRepository = new Mock<ICategoryRepository>();
            _transactionRepository = new Mock<ITransactionRepository>();
            _deleteCategoryService = new DeleteCategoryService(_categoryRepository.Object, _transactionRepository.Object);
        }

        [Fact]
        public void ShoulDeleteCategory()
        {
            _deleteCategoryService.Delete(_uuid, _propertyUuid);

            _categoryRepository.Verify(repository => repository.Delete(_uuid, _propertyUuid), Times.Once);
        }

        [Fact]
        public void ShouldntDeleteIfThereWasATransaction()
        {
            var transactions = new List<Transaction>(){ TransactionBuilder.ATransaction().Build()};
            _transactionRepository.Setup(repository => repository.GetFromCategory(_propertyUuid, _uuid)).Returns(transactions);

            var exception = Assert.Throws<DomainException<DeleteCategoryService>>(() => _deleteCategoryService.Delete(_uuid, _propertyUuid));

            Assert.Equal("Categoria não pode ser excluída pois existem transações vinculadas a ela\n", exception.Message);
            _categoryRepository.Verify(repository => repository.Delete(_uuid, _propertyUuid), Times.Never);
        }
    }
}
