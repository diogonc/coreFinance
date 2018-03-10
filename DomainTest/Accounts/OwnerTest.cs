using System;
using Xunit;
using Domain.Accounts;
using Domain.Helpers.Validation;

namespace DomainTest
{
    public class OwnerTest
    {
        [Fact]
        public void ShouldCreateAnOwner()
        {
            var owner = new Owner("2342", "name", 3);

            Assert.True(owner != null);
        }

        [Fact]
        public void ShouldValidate()
        {
            var exception = Assert.Throws<DomainException<Owner>>(() => new Owner(null, null, 0));

            Assert.Equal("Propriedade é obrigatória\nNome é obrigatório\nPrioridade é obrigatória\n", exception.Message);
        }

        [Fact]
        public void ShouldUpdate()
        {
            var owner = new Owner("24234", "name", 4);

            owner.Update("new name", 6);

            Assert.Equal("new name", owner.Name);
            Assert.Equal(6, owner.Priority);
        }
    }
}
