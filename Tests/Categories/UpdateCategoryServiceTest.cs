using CoreFinance.Domain.Categories;
using CoreFinance.DomainTest.Builders;
using Xunit;
using Moq;
using CoreFinance.Domain.Repositories;
using System.Collections.Generic;
using CoreFinance.Domain;
using System.Linq;

namespace CoreFinance.DomainTest.Categories
{
    public class UpdateCategoryServiceTest
    {
        private Mock<ICategoryRepository> _categoryRepository;
        private Mock<ITransactionRepository> _transactionRepository;
        private UpdateCategoryService _updateCategoryService;
        private Category _category;
        private Group _group;

        public UpdateCategoryServiceTest()
        {
            _categoryRepository = new Mock<ICategoryRepository>();
            _transactionRepository = new Mock<ITransactionRepository>();

            _updateCategoryService = new UpdateCategoryService(_categoryRepository.Object, _transactionRepository.Object);

            _category = CategoryBuilder.ACategory().Build();
            _group = new Group(_category.PropertyUuid, "gname", CategoryType.Debit, 9);
            _categoryRepository.Setup(repository => repository.Get(_category.Uuid, _category.PropertyUuid)).Returns(_category);

        }

        [Fact]
        public void ShouldUpdateACategory()
        {
            _updateCategoryService.Update(_category.Uuid, _category.PropertyUuid, "new name", CategoryType.Debit, _group, 2);

            Assert.Equal("new name", _category.Name);
            _categoryRepository.Verify(repository => repository.Update(_category), Times.Once);
        }

        [Fact]
        public void ShouldUpdateAllTransactions()
        {
            var transactions = new List<Transaction> { TransactionBuilder.ATransaction().Build(), TransactionBuilder.ATransaction().Build() };
            _transactionRepository.Setup(repository => repository.GetFromCategory(_category.PropertyUuid, _category.Uuid))
                                  .Returns(transactions);

            _updateCategoryService.Update(_category.Uuid, _category.PropertyUuid, "new name", CategoryType.Debit, _group, 2);

            _transactionRepository.Verify(repository => repository.Update(transactions.FirstOrDefault()), Times.Once);
            _transactionRepository.Verify(repository => repository.Update(transactions.LastOrDefault()), Times.Once);
        }
    }
}
