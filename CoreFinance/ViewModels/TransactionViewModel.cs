using System;

namespace CoreFinance.ViewModels
{
    public class TransactionViewModel
    {
        public string PropertyUuid { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public CategoryOrAccountUuid Category { get; set; }
        public CategoryOrAccountUuid Account { get; set; }
    }
    public class CategoryOrAccountUuid{
        public string Uuid {get; set;}
    }
}
