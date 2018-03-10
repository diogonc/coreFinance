using Domain.Accounts;

namespace DomainTest.Builders
{
    public class AccountBuilder
    {
        private Owner _owner = new Owner("324", "Diogo", 1);

        public static AccountBuilder AnAccount()
        {
            return new AccountBuilder();
        }

        public Account Build()
        {
            return new Account("324", "name",  3, _owner);
        }
    }
}