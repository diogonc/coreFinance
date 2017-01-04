using System.Collections.Generic;
using financeApi.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace financeApi.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(MongoClient client)
        {
            BsonClassMap.RegisterClassMap<Account>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(a => a.Uuid).SetElementName("uuid");
                cm.GetMemberMap(a => a.Name).SetElementName("name");
                cm.GetMemberMap(a => a.Priority).SetElementName("priority");
                cm.GetMemberMap(a => a.PropertyUuid).SetElementName("propertyUuid");
            });

            var database = client.GetDatabase("finance");
            _collection = database.GetCollection<Account>("account");
        }

        public IEnumerable<Account> GetAll(string propertyUuid)
        {
            var builder = Builders<Account>.Filter;
            var filter = builder.Eq(a => a.PropertyUuid, propertyUuid);

            var cursor = _collection.Find(filter).ToListAsync();
            cursor.Wait();
            return cursor.Result;
        }
    }
}