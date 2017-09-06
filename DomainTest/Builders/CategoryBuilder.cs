using Domain.Categories;

namespace DomainTest.Builders
{
    public class CategoryBuilder
    {
        private Group _group = new Group("23423", "group name", 4);

        public static CategoryBuilder ACategory()
        {
            return new CategoryBuilder();
        }

        public Category Build()
        {
            return new Category("324","name", CategoryType.Debit, _group, CategoryNeed.Necessary, 3);
        }
    }
}