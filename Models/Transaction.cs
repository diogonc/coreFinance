using System;

namespace financeApi.Models
{
    public class Transaction : Model
    {
        public new string Uuid { get; set; }
        public new string PropertyUuid { get; set; }
        public bool Payed {get; set;}
        public DateTime Date {get; set;}
        public string Description { get; set; }
        public decimal Value { get; set; }
        // public Category Category { get; set; }
        // public Account Account { get; set; }
    }
}