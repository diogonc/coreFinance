using financeApi.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace financeApi.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MongoClient client)
        {
            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(u => u.Uuid).SetElementName("uuid");
                cm.GetMemberMap(u => u.Username).SetElementName("username");
                cm.GetMemberMap(u => u.Password).SetElementName("password");
                cm.GetMemberMap(u => u.PropertyUuid).SetElementName("propertyUuid");
            });

            var database = client.GetDatabase("finance");
            _collection = database.GetCollection<User>("user");
        }
    }
}