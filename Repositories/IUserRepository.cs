using financeApi.Models;

namespace financeApi.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        bool Exists(string username, string password, string propertyUuid);
    }
}