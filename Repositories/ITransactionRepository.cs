using System.Collections.Generic;
using financeApi.Models;

namespace financeApi.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        IEnumerable<Transaction> GetAll(string propertyUuid);
    }
}