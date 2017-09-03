using System;
using Xunit;
using Domain;
using Domain.Helpers.Validation;

namespace DomainTest
{
    public class AccountTest
    {
        [Fact]
        public void ShouldCreateAnAccount()
        {
            var account = new Account("2342", "name", 3);

            Assert.True(account != null);
        }

        [Fact]
        public void ShouldValidate()
        {
            var exception = Assert.Throws<DomainException<Account>>(() => new Account(null, null, 0));

            Assert.Equal("Propriedade é obrigatória\nNome é obrigatório\nPrioridade é obrigatória\n", exception.Message);
        }

        [Fact]
        public void ShouldUpdate()
        {
            var account = new Account("24234", "name", 4);

            account.Update("new name", 6);

            Assert.Equal("new name", account.Name);
            Assert.Equal(6, account.Priority);
        }
    }
}
