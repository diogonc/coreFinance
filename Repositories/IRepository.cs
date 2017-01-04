using System.Collections.Generic;
using financeApi.Models;

namespace financeApi.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(string propertyUuid);
    }
}