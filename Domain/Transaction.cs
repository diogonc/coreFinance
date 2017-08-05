using System;
using Domain.Categories;
using Domain.Helpers.Validation;

namespace Domain
{
    public class Transaction : Model
    {
        public string Uuid { get; set; }
        public string PropertyUuid { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public Category Category { get; set; }
        public Account Account { get; set; }

        public Transaction(string propertyUuid, DateTime date, string description, decimal value,
              Account account, Category category)
        {
            Validate(propertyUuid, description, value, account, category);

            Uuid = Guid.NewGuid().ToString();
            Date = date;
            Description = description;
            Value = value;
            PropertyUuid = propertyUuid;
            Account = account;
            Category = category;
        }

        public Transaction(string uuid, string propertyUuid, DateTime date, string description, decimal value,
                        Account account, Category category)
        {
            Validate(propertyUuid, description, value, account, category);

            Uuid = uuid;
            PropertyUuid = propertyUuid;
            Date = date;
            Description = description;
            Value = value;
            Account = account;
            Category = category;
        }

        private void Validate(string propertyUuid, string description, decimal value, Account account, Category category)
        {
            Validations<Transaction>.Build()
                                    .When(propertyUuid == null, "Propriedade é obrigatória")
                                    .When(description == null, "Descrição é obrigatória")
                                    .When(value <= 0, "Valor deve ser maior que zero")
                                    .When(account == null, "Conta é obrigatória")
                                    .When(category == null, "Categoria é obrigatória")
                                    .Thwros();
        }
    }
}
