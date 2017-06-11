using System;
using Xunit;
using Domain;
using Domain.Helpers.Validation;
using Domain.Categories;

namespace DomainTest.Categories
{
    public class CategoryTest
    {
        [Fact]
        public void ShouldCreateACategory()
        {
            var category = new Category("2342", "name", CategoryType.Credit, CategoryNeed.Util, 3);

            Assert.True(category != null);
        }

        [Fact]
        public void ShouldValidateParameters()
        {
            var exception = Assert.Throws<DomainException<Category>>(() => new Category(null, null, CategoryType.Credit, CategoryNeed.Util, 3));
            Assert.Equal("Propriedade é obrigatória\nNome é obrigatório\n", exception.Message);
        }

        [Fact]
        public void ShouldUpdateACategory()
        {
            var category = new Category("234", "name", CategoryType.Credit, CategoryNeed.Util, 34);

            category.Update("new name", CategoryType.Debit, CategoryNeed.Necessary, 4);

            Assert.Equal("new name", category.Name);
            Assert.Equal(CategoryType.Debit, category.CategoryType);
            Assert.Equal(CategoryNeed.Necessary, category.CategoryNeed);
            Assert.Equal(4, category.Priority);
        }
    }
}
