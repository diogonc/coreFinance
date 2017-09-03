using System;
using Xunit;
using Domain;
using Domain.Helpers.Validation;

namespace DomainTest
{
    public class GroupTest
    {
        [Fact]
        public void ShouldCreateAGroup()
        {
            var group = new Group("2342", "name", 3);

            Assert.True(group != null);
        }

        [Fact]
        public void ShouldValidate()
        {
            var exception = Assert.Throws<DomainException<Group>>(() => new Group(null, null, 0));

            Assert.Equal("Propriedade é obrigatória\nNome é obrigatório\nPrioridade é obrigatória\n", exception.Message);
        }

        [Fact]
        public void ShouldUpdateAGroup()
        {
            var group = new Group ("234234", "name", 4);

            group.Update("new name", 5);

            Assert.Equal("new name", group.Name);
            Assert.Equal(5, group.Priority);
        }
    }
}
