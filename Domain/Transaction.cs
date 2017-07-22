using System;
using Domain.Categories;

namespace Domain
{
    public class Transaction : Model
    {
        public string Uuid { get; set; }
        public string PropertyUuid { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public Category Category {get; set;}
        public Account Account { get; set; }

        public Transaction(string propertyUuid, DateTime date, string description, decimal value,
              Account account, Category category)
        {
            Uuid = Guid.NewGuid().ToString();
            Date = date;
            Description = description;
            Value = value;
            PropertyUuid = propertyUuid;
            Account = account;
        }

        public Transaction(string uuid, string propertyUuid, DateTime date, string description, decimal value,
                        Account account, Category category)
        {
            Uuid = uuid;
            PropertyUuid = propertyUuid;
            Date = date;
            Description = description;
            Value = value;
            Account = account;
            Category = category;
        }
    }
}
