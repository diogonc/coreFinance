using Domain;
using Domain.Repositories;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Linq;

namespace Infra.Repositories.Sql
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public bool Exists(string username, string password, string propertyUuid)
        {
return true;
        }
    }
}
