using System;
using Domain;
using Domain.Categories;

namespace Migration
{
    public class TransactionToMigrate
    {
        public string Uuid { get; set; }
        public string PropertyUuid { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public Category Category {get; set;}
        public Account Account { get; set; }
        public string CategoryUuid {get; set;}
        public string AccountUuid {get; set;}
    }
}