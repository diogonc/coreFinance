using System;

namespace financeApi.ViewModels
{
    public class TransactionViewModel
    {
        public string PropertyUuid { get; set; }
        public string Description { get; set; }
        public DateTime Date {get; set;}
        public decimal Value { get; set; }
        public string CategoryUuid { get; set; }
        public string CategoryName { get; set; }
        public string CategoryType { get; set; }
        public string AccountUuid { get; set; }
        public string AccountName { get; set; }
    }
}