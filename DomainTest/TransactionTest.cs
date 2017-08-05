using System;
using Xunit;
using Domain;
using Domain.Helpers.Validation;
using Domain.Categories;

namespace DomainTest
{
    public class TransactionTest
    {
        [Fact]
        public void ShouldCreateATransaction()
        {
            var account = new Account("123", "33", "account", 3);
            var category = new Category("2342", "name", CategoryType.Credit, CategoryNeed.Util, 3);

            var transaction = new Transaction("232", DateTime.Today, "description", 10.2m, account, category);

            Assert.True(transaction != null);
        }

        [Fact]
        public void ShouldCreateATransactionWithUuid()
        {
            var account = new Account("123", "33", "account", 3);
            var category = new Category("2342", "name", CategoryType.Credit, CategoryNeed.Util, 3);

            var transaction = new Transaction("2342", "232", DateTime.Today, "description", 10.2m, account, category);

            Assert.True(transaction != null);
        }

        [Fact]
        public void ShouldValidateParameters()
        {
            var exception = Assert.Throws<DomainException<Transaction>>(() => new Transaction(null, DateTime.Today, null, 0, null, null));

            Assert.Equal("Propriedade é obrigatória\nDescrição é obrigatória\nValor deve ser maior que zero\nConta é obrigatória\nCategoria é obrigatória\n", exception.Message);
        }

        [Fact]
        public void ShouldValidateParametersWithUuid()
        {
            var exception = Assert.Throws<DomainException<Transaction>>(() => new Transaction(null, null, DateTime.Today, null, 0, null, null));

            Assert.Equal("Propriedade é obrigatória\nDescrição é obrigatória\nValor deve ser maior que zero\nConta é obrigatória\nCategoria é obrigatória\n", exception.Message);
        }
    }
}
