using System;
using CoreFinance.Domain.Accounts;

namespace CoreFinance.DomainTest.Builders
{
    public class AccountBuilder
    {
        private Owner _owner = new Owner("324", "7", "Diogo", 1);
        private string _name = "name";

        public static AccountBuilder AnAccount()
        {
            return new AccountBuilder();
        }

        public Account Build()
        {
            return new Account("324", _name, 3, _owner);
        }

        public AccountBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
    }
}