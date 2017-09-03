using System;
using Domain;
using Domain.Categories;

namespace DomainTest.Builders
{
    public class TransactionBuilder
    {
        private string _propertyUuid = "1";
        private DateTime _date = DateTime.Now;
        private string _description = "description";
        private decimal _value = 2423.34m;
        private Account _account = new Account("3242", "credit card", 3);
        private Category _category = new Category("23424", "food", CategoryType.Debit, CategoryNeed.Essential, 2);

        public static TransactionBuilder ATransaction()
        {
            return new TransactionBuilder();
        }

        public Transaction Build()
        {
            return new Transaction(_propertyUuid, _date, _description, _value, _account, _category);
        }
    }
}