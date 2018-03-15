using System.Collections.Generic;
using Domain.Accounts;

namespace Domain.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        IEnumerable<Account> GetFromOwner(string propertyUuid, string ownerUuid);
    }
}
