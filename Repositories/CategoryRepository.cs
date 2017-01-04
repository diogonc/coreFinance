using System.Collections.Generic;
using financeApi.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace financeApi.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(MongoClient client)
        {
            BsonClassMap.RegisterClassMap<Category>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(c => c.Uuid).SetElementName("uuid");
                cm.GetMemberMap(c => c.Name).SetElementName("name");
                cm.GetMemberMap(c => c.CategoryType).SetElementName("categoryType");
                cm.GetMemberMap(c => c.Priority).SetElementName("priority");
                cm.GetMemberMap(c => c.PropertyUuid).SetElementName("propertyUuid");
            });

            var database = client.GetDatabase("finance");
            _collection = database.GetCollection<Category>("category");
        }

        public IEnumerable<Category> GetAll(string propertyUuid)
        {
            var builder = Builders<Category>.Filter;
            var filter = builder.Eq(c => c.PropertyUuid, propertyUuid);

            var cursor = _collection.Find(filter).ToListAsync();
            cursor.Wait();
            return cursor.Result;
        }
    }
}