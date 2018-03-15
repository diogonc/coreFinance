using System.Collections.Generic;
using Domain.Categories;

namespace Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetFromGroup(string propertyUuid, string groupUuid);
    }
}
