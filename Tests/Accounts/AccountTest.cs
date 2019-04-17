using System;
using Xunit;
using CoreFinance.Domain;
using CoreFinance.Domain.Accounts;
using CoreFinance.Domain.Helpers.Validation;

namespace CoreFinance.DomainTest
{
    public class AccountTest
    {
        private Owner _owner;

        public AccountTest()
        {
            _owner = new Owner("2341", "7", "Diogonc", 1);
        }

        [Fact]
        public void ShouldCreateAnAccount()
        {
            var account = new Account("2342", "name", 3, _owner);

            Assert.True(account != null);
        }

        [Fact]
        public void ShouldValidate()
        {
            var exception = Assert.Throws<DomainException<Account>>(() => new Account(null, null, 0, _owner));

            Assert.Equal("Propriedade é obrigatória\nNome é obrigatório\nPrioridade é obrigatória\n", exception.Message);
        }

        [Fact]
        public void ShouldUpdate()
        {
            var account = new Account("24234", "name", 4, _owner);

            account.Update("new name", 6, _owner);

            Assert.Equal("new name", account.Name);
            Assert.Equal(6, account.Priority);
        }
    }
}
