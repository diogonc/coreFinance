using System.Collections.Generic;
using financeApi.Models;

namespace financeApi.Repositories
{
    public interface IRepository<T> where T : Model
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(string propertyUuid);
        T Get(string uuid);
        void Update(T model);
        void Create(T model);
        void Delete(string uuid);
    }
}