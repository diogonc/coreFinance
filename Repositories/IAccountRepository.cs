using System.Collections.Generic;
using financeApi.Models;

namespace financeApi.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        IEnumerable<Account> GetAll(string propertyUuid);
    }
}