using System;
using Domain;
using Domain.Categories;
using Domain.Accounts;

namespace DomainTest.Builders
{
    public class TransactionBuilder
    {
        private string _propertyUuid = "1";
        private DateTime _date = DateTime.Now;
        private string _description = "description";
        private decimal _value = 2423.34m;
        private Account _account;
        private Category _category;

        public TransactionBuilder()
        {
            _account = AccountBuilder.AnAccount().Build();
            _category = new Category(_propertyUuid, "food", CategoryType.Debit, new Group(_propertyUuid, "group name", CategoryType.Debit, 3), 2);

        }
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