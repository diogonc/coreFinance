using System.Collections.Generic;
using CoreFinance.Domain.Accounts;

namespace CoreFinance.Domain.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        IEnumerable<Account> GetFromOwner(string propertyUuid, string ownerUuid);
    }
}
