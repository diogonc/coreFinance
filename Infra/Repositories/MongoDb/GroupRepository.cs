using CoreFinance.Domain;
using CoreFinance.Domain.Repositories;
using CoreFinance.Domain.Categories;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Infra.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(MongoClient client)
        {
            BsonClassMap.RegisterClassMap<Group>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(a => a.Name).SetElementName("name");
                cm.GetMemberMap(a => a.CategoryType).SetElementName("categoryType");
                cm.GetMemberMap(a => a.Priority).SetElementName("priority");
            });

            var database = client.GetDatabase("finance");
            _collection = database.GetCollection<Group>("group");
        }
    }
}
