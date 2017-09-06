using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        IEnumerable<Transaction> GetFromCategory(string propertyUuid, string categoryUuid);
    }
}
