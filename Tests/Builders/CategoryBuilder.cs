using CoreFinance.Domain.Categories;

namespace CoreFinance.DomainTest.Builders
{
    public class CategoryBuilder
    {
        private Group _group = new Group("324", "group name", CategoryType.Debit, 4);
        private string _name = "name";

        public static CategoryBuilder ACategory()
        {
            return new CategoryBuilder();
        }

        public Category Build()
        {
            return new Category("324", _name, CategoryType.Debit, _group, 3);
        }

        public CategoryBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
    }
}