using System;

namespace financeApi.Models
{
    public class Transaction : Model
    {
        public string Uuid { get; set; }
        public string PropertyUuid { get; set; }
        public bool Payed { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string CategoryUuid { get; set; }
        public string CategoryName { get; set; }
        public string CategoryType { get; set; }
        public string AccountUuid { get; set; }
        public string AccountName { get; set; }

        public Transaction(string propertyUuid, DateTime date, string description, decimal value,
              Account account, Category category)
        {
            Uuid = Guid.NewGuid().ToString();
            Payed = true;
            Date = date;
            Description = description;
            Value = value;
            PropertyUuid = propertyUuid;
            AccountUuid = account.Uuid;
            AccountName = account.Name;
            CategoryUuid = category.Uuid;
            CategoryName = category.Name;
            CategoryType = category.CategoryType;  
        }

        public Transaction(string uuid, string propertyUuid, DateTime date, string description, decimal value,
                        Account account, Category category)
        {
            Uuid = uuid;
            Payed = true;
            PropertyUuid = propertyUuid;
            Date = date;
            Description = description;
            Value = value;
            AccountUuid = account.Uuid;
            AccountName = account.Name;
            CategoryUuid = category.Uuid;
            CategoryName = category.Name;
            CategoryType = category.CategoryType;
        }
    }
}