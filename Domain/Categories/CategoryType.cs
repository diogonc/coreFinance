using System.ComponentModel;

namespace CoreFinance.Domain.Categories
{
    public enum CategoryType
    {
        [Description("Crédito")]
        Credit = 1,
        [Description("Débito")]
        Debit = 2,
        [Description("Transfrência de crédito")]
        CreditTransfer = 3,
        [Description("Transfrência de débito")]
        DebitTransfer = 4
    }
}
