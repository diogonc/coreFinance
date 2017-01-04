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
    }
}