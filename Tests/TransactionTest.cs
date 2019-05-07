using System;
using Xunit;
using CoreFinance.Domain;
using CoreFinance.Domain.Helpers.Validation;
using CoreFinance.Domain.Accounts;
using CoreFinance.Domain.Categories;
using CoreFinance.DomainTest.Builders;

namespace CoreFinance.DomainTest
{
    public class TransactionTest
    {
        private string _propertyUuid = "1";

        [Fact]
        public void ShouldCreateATransaction()
        {
            var account = AccountBuilder.AnAccount().Build();
            var category = new Category(_propertyUuid, "name", CategoryType.Credit, new Group(_propertyUuid, "group name", CategoryType.Credit, 3), 3);

            var transaction = new Transaction(_propertyUuid, DateTime.Today, "description", 10.2m, account, category);

            Assert.True(transaction != null);
            Assert.NotNull(transaction.Uuid);
        }

        [Fact]
        public void ShouldCreateATransactionWithUuid()
        {
            var uuid = "24234";
            var account = AccountBuilder.AnAccount().Build();
            var category = new Category(_propertyUuid, "name", CategoryType.Credit, new Group(_propertyUuid, "group name", CategoryType.Credit, 3), 3);

            var transaction = new Transaction(_propertyUuid, DateTime.Today, "description", 10.2m, account, category, uuid);

            Assert.Equal(uuid, transaction.Uuid);
        }

        [Fact]
        public void ShouldUpdateATransaction()
        {
            var transaction = TransactionBuilder.ATransaction().Build();
            var newAccount = AccountBuilder.AnAccount().Build();
            var newCategory = new Category(_propertyUuid, "new category name", CategoryType.Credit, new Group(_propertyUuid, "group name", CategoryType.Credit, 3), 3);
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

        [Fact]
        public void ShouldUpdateAccount()
        {
            var transaction = TransactionBuilder.ATransaction().Build();
            var account = AccountBuilder.AnAccount().Build();

            transaction.UpdateAccount(account);

            Assert.Equal(account, transaction.Account);
        }
    }
}
