using Domain;
using Domain.Repositories;
using Domain.Categories;
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
                cm.GetMemberMap(a => a.Uuid).SetElementName("uuid");
                cm.GetMemberMap(a => a.Name).SetElementName("name");
                cm.GetMemberMap(a => a.Priority).SetElementName("priority");
                cm.GetMemberMap(a => a.PropertyUuid).SetElementName("propertyUuid");
            });

            var database = client.GetDatabase("finance");
            _collection = database.GetCollection<Group>("group");
        }
    }
}
