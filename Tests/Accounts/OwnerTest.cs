using System;
using Xunit;
using CoreFinance.Domain.Accounts;
using CoreFinance.Domain.Helpers.Validation;

namespace CoreFinance.DomainTest
{
    public class OwnerTest
    {
        [Fact]
        public void ShouldCreateAnOwner()
        {
            var owner = new Owner("2342", "7", "name", 3);

            Assert.True(owner != null);
        }

        [Fact]
        public void ShouldValidate()
        {
            var exception = Assert.Throws<DomainException<Owner>>(() => new Owner(null, null, null, 0));

            Assert.Equal("Propriedade é obrigatória\nUsuario é obrigatório\nNome é obrigatório\nPrioridade é obrigatória\n", exception.Message);
        }

        [Fact]
        public void ShouldUpdate()
        {
            var owner = new Owner("24234", "7", "name", 4);

            owner.Update("new name", "8", 6);

            Assert.Equal("new name", owner.Name);
            Assert.Equal("8", owner.UserLogin);
            Assert.Equal(6, owner.Priority);
        }
    }
}
