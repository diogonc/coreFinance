using System.Collections.Generic;
using financeApi.Models;

namespace financeApi.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
    }
}