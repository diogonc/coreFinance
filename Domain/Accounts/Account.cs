using System;
using CoreFinance.Domain.Helpers.Validation;

namespace CoreFinance.Domain.Accounts
{
    public class Account : Model
    {
        public string Uuid { get; set; }
        public string PropertyUuid { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public Owner Owner { get; set; }

        public Account(string propertyUuid, string name, int priority, Owner owner, string uuid = null)
        {
            Validate(propertyUuid, name, priority);

            Uuid = string.IsNullOrWhiteSpace(uuid) ? Guid.NewGuid().ToString() : uuid;
            PropertyUuid = propertyUuid;
            Name = name;
            Priority = priority;
            Owner = owner;
        }

        public void Update(string name, int priority, Owner owner)
        {
            Validate(PropertyUuid, name, priority);

            Name = name;
            Priority = priority;
            Owner = owner;
        }

        private void Validate(string propertyUuid, string name, int priority)
        {
            Validations<Account>.Build()
                               .When(propertyUuid == null, "Propriedade é obrigatória")
                               .When(name == null, "Nome é obrigatório")
                               .When(priority == 0, "Prioridade é obrigatória")
                               .Thwros();
        }
    }
}