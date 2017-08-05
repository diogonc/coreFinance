using System;
using Domain.Helpers.Validation;

namespace Domain.Categories
{
    public class Category : Model
    {
        public string Uuid { get; private set; }
        public string PropertyUuid { get; private set; }
        public CategoryType CategoryType { get; private set; }
        public string Name { get; private set; }
        public int Priority { get; private set; }
        public CategoryNeed CategoryNeed { get; private set; }

        public Category(string propertyUuid, string name, CategoryType categoryType, CategoryNeed categoryNeed, int priority, Category parent = null)
        {
            Validate(propertyUuid, name, categoryType, categoryNeed, priority);

            Uuid = Guid.NewGuid().ToString();
            PropertyUuid = propertyUuid;
            Name = name;
            CategoryType = categoryType;
            CategoryNeed = categoryNeed;
            Priority = priority;
        }

        public void Update(string name, CategoryType categoryType, CategoryNeed categoryNeed, int priority)
        {
            Validate(PropertyUuid, name, categoryType, categoryNeed, priority);
   
            Name = name;
            CategoryType = categoryType;
            CategoryNeed = categoryNeed;
            Priority = priority;         
        }

        private void Validate(string propertyUuid, string name, CategoryType categoryType, CategoryNeed categoryNeed,int priority)
        {
              Validations<Category>.Build()
                               .When(propertyUuid == null, "Propriedade é obrigatória")
                               .When(name == null, "Nome é obrigatório")
                               .Thwros();
        }
    }
}
