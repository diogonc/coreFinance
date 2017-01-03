using System.Collections.Generic;
using financeApi.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace financeApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IMongoCollection<User> _collection;

        public UserRepository(MongoClient client)
        {
            var database = client.GetDatabase("finance");
            ConfigureMap();

            _collection = database.GetCollection<User>("user");
        }       

        public IEnumerable<User> GetAll()
        {
            var allUserCursor = _collection.Find(FilterDefinition<User>.Empty).ToListAsync();
            allUserCursor.Wait();
            return allUserCursor.Result;
        }

        public void ConfigureMap()
        {
            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(u => u.Uuid).SetElementName("uuid");
                cm.GetMemberMap(u => u.Username).SetElementName("username");
                cm.GetMemberMap(u => u.Password).SetElementName("password");
                cm.GetMemberMap(u => u.PropertyUuid).SetElementName("propertyUuid");
            });
        }
    }
}