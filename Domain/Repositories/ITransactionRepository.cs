using System.Collections.Generic;

namespace CoreFinance.Domain.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        IEnumerable<Transaction> GetFromCategory(string propertyUuid, string categoryUuid);
        IEnumerable<Transaction> GetFromAccount(string propertyUuid, string accountUuid);
    }
}
