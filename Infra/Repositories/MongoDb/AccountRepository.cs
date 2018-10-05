using Domain.Accounts;
using Domain;
using Domain.Repositories;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Infra.Repositories
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
                cm.GetMemberMap(a => a.Owner).SetElementName("owner");
            });

            var database = client.GetDatabase("finance");
            _collection = database.GetCollection<Account>("account");
        }

        public IEnumerable<Account> GetFromOwner(string propertyUuid, string ownerUuid)
        {
            var builder = Builders<Account>.Filter;
            var filter = builder.Eq(account => account.PropertyUuid, propertyUuid) & builder.Eq(account => account.Owner.Uuid, ownerUuid);

            var cursor = _collection.Find(filter).ToListAsync();
            cursor.Wait();
            return cursor.Result;
        }
    }
}
