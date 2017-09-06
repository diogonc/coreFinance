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
        [Fact]
        public void ShouldCreateATransaction()
        {
            var account = new Account("33", "account", 3);
            var category = new Category("2342", "name", CategoryType.Credit, new Group("234", "group name", 3), CategoryNeed.Util, 3);

            var transaction = new Transaction("232", DateTime.Today, "description", 10.2m, account, category);

            Assert.True(transaction != null);
        }

        [Fact]
        public void ShouldUpdateATransaction()
        {
            var transaction = TransactionBuilder.ATransaction().Build();
            var newAccount = new Account("2", "new account", 3);
            var newCategory = new Category("1", "new category name", CategoryType.Credit, new Group("3424", "group name", 3), CategoryNeed.Util, 3);
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
