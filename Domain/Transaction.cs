using System;
using CoreFinance.Domain.Accounts;
using CoreFinance.Domain.Categories;
using CoreFinance.Domain.Helpers.Validation;

namespace CoreFinance.Domain
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
            Validate(propertyUuid, date, description, value, account, category);

            Uuid = Guid.NewGuid().ToString();
            Date = date;
            Description = description;
            Value = value;
            PropertyUuid = propertyUuid;
            Account = account;
            Category = category;
        }

        public void Update(DateTime date, string description, decimal value, Account account, Category category)
        {
            Validate(PropertyUuid, date, description, value, account, category);

            Date = date;
            Description = description;
            Value = value;
            Account = account;
            Category = category;
        }

        public void UpdateCategory(Category category)
        {
            Validations<Transaction>.Build()
                                    .When(category == null, "Categoria é obrigatória")
                                    .Thwros();

            Category = category;
        }

        public void UpdateAccount(Account account)
        {
            Validations<Transaction>.Build()
                                    .When(account == null, "Conta é obrigatória")
                                    .Thwros();

            Account = account;
        }

        private void Validate(string propertyUuid, DateTime date, string description, decimal value, Account account, Category category)
        {
            Validations<Transaction>.Build()
                                    .When(date <= new DateTime(1900, 01, 01), "Data é obrigatória")
                                    .When(propertyUuid == null, "Propriedade é obrigatória")
                                    .When(description == null, "Descrição é obrigatória")
                                    .When(value <= 0, "Valor deve ser maior que zero")
                                    .When(account == null, "Conta é obrigatória")
                                    .When(category == null, "Categoria é obrigatória")
                                    .Thwros();
        }

    }
}
