using System;
using Domain.Helpers.Validation;

namespace Domain.Accounts
{
    public class Owner : Model
    {
        public string Uuid { get; set; }
        public string PropertyUuid { get; set; }
        public string UserLogin { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }

        public Owner(string propertyUuid, string userLogin, string name, int priority)
        {
            Validate(propertyUuid, userLogin, name, priority);

            Uuid = Guid.NewGuid().ToString();
            PropertyUuid = propertyUuid;
            UserLogin = userLogin;
            Name = name;
            Priority = priority;
        }

        public void Update(string name, string userLogin, int priority)
        {
            Validate(PropertyUuid, userLogin, name, priority);

            Name = name;
            UserLogin = userLogin;
            Priority = priority;
        }

        private void Validate(string propertyUuid, string userLogin, string name, int priority)
        {
            Validations<Owner>.Build()
                               .When(propertyUuid == null, "Propriedade é obrigatória")
                               .When(userLogin == null, "Usuario é obrigatório")
                               .When(name == null, "Nome é obrigatório")
                               .When(priority == 0, "Prioridade é obrigatória")
                               .Thwros();
        }
    }
}