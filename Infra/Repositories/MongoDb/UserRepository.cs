using CoreFinance.Domain;
using CoreFinance.Domain.Repositories;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Linq;

namespace Infra.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MongoClient client)
        {
            BsonClassMap.RegisterClassMap<Model>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(u => u.Uuid).SetElementName("uuid");
                cm.GetMemberMap(u => u.PropertyUuid).SetElementName("propertyUuid");
            });

            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(u => u.Username).SetElementName("username");
                cm.GetMemberMap(u => u.Password).SetElementName("password");
            });

            var database = client.GetDatabase("finance");
            _collection = database.GetCollection<User>("user");
        }

        public bool Exists(string username, string password, string propertyUuid)
        {
            var builder = Builders<User>.Filter;
            var filter = builder.Eq(u => u.Username, username)
                         & builder.Eq(u => u.Password, password)
                         & builder.Eq(u => u.PropertyUuid, propertyUuid);


            var cursor = _collection.Find(filter).ToListAsync();
            cursor.Wait();
            return cursor.Result.Count > 0;
        }
    }
}
