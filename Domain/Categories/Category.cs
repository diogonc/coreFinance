using System;
using CoreFinance.Domain.Helpers.Validation;

namespace CoreFinance.Domain.Categories
{
    public class Category : Model
    {
        public CategoryType CategoryType { get; private set; }
        public string Name { get; private set; }
        public int Priority { get; private set; }
        public Group Group { get; private set; }

        public Category(string propertyUuid, string name, CategoryType categoryType, Group group, int priority, string uuid = null)
        {
            Validate(propertyUuid, name, categoryType, group, priority);

            Uuid = string.IsNullOrWhiteSpace(uuid) ? Guid.NewGuid().ToString() : uuid;
            PropertyUuid = propertyUuid;
            Name = name;
            Group = group;
            CategoryType = categoryType;
            Priority = priority;
        }

        public void Update(string name, CategoryType categoryType, Group group, int priority)
        {
            Validate(PropertyUuid, name, categoryType, group, priority);

            Name = name;
            CategoryType = categoryType;
            Group = group;
            Priority = priority;
        }

        private void Validate(string propertyUuid, string name, CategoryType categoryType, Group group, int priority)
        {
            Validations<Category>.Build()
                             .When(propertyUuid == null, "Propriedade é obrigatória")
                             .When(name == null, "Nome é obrigatório")
                             .When(group != null && propertyUuid != group.PropertyUuid, "Propriedade do agrupamento deve ser igual a da categoria")
                             .When(group != null && categoryType != group.CategoryType, "Tipo do agrupamento deve ser igual ao da categoria")
                             .Thwros();
        }
    }
}
