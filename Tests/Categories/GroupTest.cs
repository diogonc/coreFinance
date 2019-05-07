using System;
using Xunit;
using CoreFinance.Domain;
using CoreFinance.Domain.Helpers.Validation;
using CoreFinance.Domain.Categories;

namespace CoreFinance.DomainTest.Categories
{
    public class GroupTest
    {
        [Fact]
        public void ShouldCreateAGroup()
        {
            var group = new Group("2342", "name", CategoryType.Credit, 3);

            Assert.True(group != null);
            Assert.NotNull(group.Uuid);
        }

        [Fact]
        public void ShouldCreateAGroupWithUuid()
        {
            var uuid = "24234";
            var group = new Group("2342", "name", CategoryType.Credit, 3, uuid);

            Assert.Equal(uuid, group.Uuid);
        }

        [Fact]
        public void ShouldValidate()
        {
            var exception = Assert.Throws<DomainException<Group>>(() => new Group(null, null, CategoryType.Credit, 0));

            Assert.Equal("Propriedade é obrigatória\nNome é obrigatório\nPrioridade é obrigatória\n", exception.Message);
        }

        [Fact]
        public void ShouldUpdateAGroup()
        {
            var group = new Group("234234", "name", CategoryType.Credit, 4);

            group.Update("new name", 5);

            Assert.Equal("new name", group.Name);
            Assert.Equal(5, group.Priority);
        }
    }
}
