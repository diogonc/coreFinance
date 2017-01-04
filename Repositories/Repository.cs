using System.Collections.Generic;
using financeApi.Models;
using MongoDB.Driver;

namespace financeApi.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : BaseModel
    {
        protected IMongoCollection<T> _collection {get; set;}
        
        public IEnumerable<T> GetAll()
        {
            var cursor = _collection.Find(FilterDefinition<T>.Empty).ToListAsync();
            cursor.Wait();
            return cursor.Result;
        }

        public IEnumerable<T> GetAll(string propertyUuid)
        {
            var builder = Builders<T>.Filter;
            var filter = builder.Eq(t => t.PropertyUuid, propertyUuid);

            var cursor = _collection.Find(filter).ToListAsync();
            cursor.Wait();
            return cursor.Result;
        }
    }
}