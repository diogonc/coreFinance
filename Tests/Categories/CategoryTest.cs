using System;
using Xunit;
using CoreFinance.Domain;
using CoreFinance.Domain.Helpers.Validation;
using CoreFinance.Domain.Categories;

namespace CoreFinance.DomainTest.Categories
{
    public class CategoryTest
    {
        private Group _group;
        private string _propertyUuid = "23423";

        public CategoryTest()
        {
            _group = new Group(_propertyUuid, "group name", CategoryType.Credit, 1);
        }

        [Fact]
        public void ShouldCreateACategory()
        {
            var category = new Category(_propertyUuid, "name", CategoryType.Credit, _group, 3);

            Assert.True(category != null);
            Assert.NotNull(category.Uuid);
        }

        [Fact]
        public void ShouldCreateACategoryWithUuid()
        {
            var uuid = "24234";
            var category = new Category(_propertyUuid, "name", CategoryType.Credit, _group, 3, uuid);

            Assert.Equal(uuid, category.Uuid);
        }

        [Fact]
        public void ShouldValidateParameters()
        {
            var exception = Assert.Throws<DomainException<Category>>(() => new Category(null, null, CategoryType.Credit, null, 3));

            Assert.Equal("Propriedade é obrigatória\nNome é obrigatório\n", exception.Message);
        }


        [Fact]
        public void GroupAndCategoryMustHaveTheSameType()
        {
            var exception = Assert.Throws<DomainException<Category>>(() => new Category(_propertyUuid, "category name", CategoryType.Debit, _group, 3));

            Assert.Equal("Tipo do agrupamento deve ser igual ao da categoria\n", exception.Message);
        }

        [Fact]
        public void ShouldUpdateACategory()
        {
            var category = new Category(_propertyUuid, "name", CategoryType.Credit, _group, 34);

            category.Update("new name", CategoryType.Credit, _group, 4);

            Assert.Equal("new name", category.Name);
            Assert.Equal(CategoryType.Credit, category.CategoryType);
            Assert.Equal(4, category.Priority);
        }
    }
}