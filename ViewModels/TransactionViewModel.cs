using System;

namespace CoreFinance.ViewModels
{
    public class TransactionViewModel
    {
        public string Uuid { get; set; }
        public string PropertyUuid { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public EntityWithUuid Category { get; set; }
        public EntityWithUuid Account { get; set; }
    }
}
