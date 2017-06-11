using System;
using Xunit;
using Domain;

namespace DomainTest
{
    public class AccountTest
    {
        [Fact]
        public void ShouldCreateAnAccount()
        {
            var account = new Account("3423", "2342", "name", 3);

            Assert.True(account != null);
        }
    }
}
