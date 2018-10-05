using System.Collections.Generic;
using Domain;
using Domain.Categories;
using Domain.Repositories;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Infra.Repositories
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
                cm.GetMemberMap(c => c.Group).SetElementName("group");
            });

            var database = client.GetDatabase("finance");
            _collection = database.GetCollection<Category>("category");
        }

        public IEnumerable<Category> GetFromGroup(string propertyUuid, string groupUuid)
        {
            var builder = Builders<Category>.Filter;
            var filter = builder.Eq(category => category.PropertyUuid, propertyUuid) & builder.Eq(category => category.Group.Uuid, groupUuid);

            var cursor = _collection.Find(filter).ToListAsync();
            cursor.Wait();
            return cursor.Result;
        }
    }
}
