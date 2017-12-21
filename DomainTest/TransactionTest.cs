using System;
using Xunit;
using Domain;
using Domain.Helpers.Validation;
using Domain.Categories;
using DomainTest.Builders;

namespace DomainTest
{
    public class TransactionTest
    {
        private string _propertyUuid = "1";

        [Fact]
        public void ShouldCreateATransaction()
        {
            var account = new Account(_propertyUuid, "account", 3);
            var category = new Category(_propertyUuid, "name", CategoryType.Credit, new Group(_propertyUuid, "group name",CategoryType.Credit, 3), CategoryNeed.Util, 3);

            var transaction = new Transaction(_propertyUuid, DateTime.Today, "description", 10.2m, account, category);

            Assert.True(transaction != null);
        }

        [Fact]
        public void ShouldUpdateATransaction()
        {
            var transaction = TransactionBuilder.ATransaction().Build();
            var newAccount = new Account(_propertyUuid, "new account", 3);
            var newCategory = new Category(_propertyUuid, "new category name", CategoryType.Credit, new Group(_propertyUuid, "group name",CategoryType.Credit, 3), CategoryNeed.Util, 3);
            var newDate = DateTime.Today.AddDays(2);
            var newDescription = "new description";

            transaction.Update(newDate, newDescription, 4.5m, newAccount, newCategory);

            Assert.Equal(newDate, transaction.Date);
            Assert.Equal(newDescription, transaction.Description);
            Assert.Equal(4.5m, transaction.Value);
            Assert.Equal(newAccount, transaction.Account);
            Assert.Equal(newCategory, transaction.Category);
        }

        [Fact]
        public void ShouldValidateParameters()
        {
            var exception = Assert.Throws<DomainException<Transaction>>(() => new Transaction(null, new DateTime(1800, 1, 1), null, 0, null, null));

            Assert.Equal("Data é obrigatória\nPropriedade é obrigatória\nDescrição é obrigatória\nValor deve ser maior que zero\nConta é obrigatória\nCategoria é obrigatória\n", exception.Message);
        }

        [Fact]
        public void ShouldValidateParametersOnUpdate()
        {
            var transaction = TransactionBuilder.ATransaction().Build();

            var exception = Assert.Throws<DomainException<Transaction>>(() => transaction.Update(new DateTime(1800, 1, 1), null, 0, null, null));

            Assert.Equal("Data é obrigatória\nDescrição é obrigatória\nValor deve ser maior que zero\nConta é obrigatória\nCategoria é obrigatória\n", exception.Message);
        }

        [Fact]
        public void ShouldUpdateCategory()
        {
            var transaction = TransactionBuilder.ATransaction().Build();
            var category = CategoryBuilder.ACategory().Build();

            transaction.UpdateCategory(category);

            Assert.Equal(category, transaction.Category);
        }
    }
}
