using System.Collections.Generic;
using financeApi.Models;

namespace financeApi.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetAll(string propertyUuid);
    }
}