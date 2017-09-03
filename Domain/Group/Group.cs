using System;
using Domain.Helpers.Validation;

namespace Domain
{
    public class Group : Model
    {
        public string Uuid { get; set; }
        public string PropertyUuid { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }

        public Group(string propertyUuid, string name, int priority)
        {
            Validate(propertyUuid, name, priority);

            Uuid = Guid.NewGuid().ToString();
            PropertyUuid = propertyUuid;
            Name = name;
            Priority = priority;
        }

        public void Update(string name, int priority)
        {
            Validate(PropertyUuid, name, priority);

            Name = name;
            Priority = priority;
        }

        private void Validate(string propertyUuid, string name, int priority)
        {
            Validations<Group>.Build()
                               .When(propertyUuid == null, "Propriedade é obrigatória")
                               .When(name == null, "Nome é obrigatório")
                               .When(priority == 0, "Prioridade é obrigatória")
                               .Thwros();
        }
    }
}
