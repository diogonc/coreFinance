using System;
using Domain.Helpers.Validation;

namespace Domain.Accounts
{
    public class Owner : Model
    {
        public string Uuid { get; set; }
        public string PropertyUuid { get; set; }
        public string UserUuid { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }

        public Owner(string propertyUuid, string userUuid, string name, int priority)
        {
            Validate(propertyUuid, userUuid, name, priority);

            Uuid = Guid.NewGuid().ToString();
            PropertyUuid = propertyUuid;
            UserUuid = userUuid;
            Name = name;
            Priority = priority;
        }

        public void Update(string name, string userUuid, int priority)
        {
            Validate(PropertyUuid, userUuid, name, priority);

            Name = name;
            UserUuid = userUuid;
            Priority = priority;
        }

        private void Validate(string propertyUuid, string userUuid, string name, int priority)
        {
            Validations<Owner>.Build()
                               .When(propertyUuid == null, "Propriedade é obrigatória")
                               .When(userUuid == null, "Usuario é obrigatório")
                               .When(name == null, "Nome é obrigatório")
                               .When(priority == 0, "Prioridade é obrigatória")
                               .Thwros();
        }
    }
}