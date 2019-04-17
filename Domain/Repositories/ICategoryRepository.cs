using System.Collections.Generic;
using CoreFinance.Domain.Categories;

namespace CoreFinance.Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetFromGroup(string propertyUuid, string groupUuid);
    }
}
