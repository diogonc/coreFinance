using System.Collections.Generic;
using financeApi.Models;
using MongoDB.Driver;
using System.Linq;

namespace financeApi.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Model
    {
        protected IMongoCollection<T> _collection { get; set; }

        public IEnumerable<T> GetAll()
        {
            var cursor = _collection.Find(FilterDefinition<T>.Empty).ToListAsync();
            cursor.Wait();
            return cursor.Result;
        }

        public IEnumerable<T> GetAll(string propertyUuid)
        {
            var builder = Builders<T>.Filter;
            var filter = builder.Eq(model => model.PropertyUuid, propertyUuid);

            var cursor = _collection.Find(filter).ToListAsync();
            cursor.Wait();
            return cursor.Result;
        }

        public T Get(string uuid, string propertyUuid)
        {
            var builder = Builders<T>.Filter;
            var filter = builder.Eq(model => model.PropertyUuid, propertyUuid)
                         & builder.Eq(model => model.Uuid, uuid);

            var cursor = _collection.Find(filter).ToListAsync();
            cursor.Wait();
            return cursor.Result.FirstOrDefault();
        }

        public void Create(T model)
        {
            _collection.InsertOneAsync(model);
        }

        public void Update(T model)
        {
            _collection.ReplaceOneAsync(Builders<T>.Filter.Eq(m => m.Uuid, model.Uuid), model);
        }

        public void Delete(string uuid, string propertyUuid)
        {
            var builder = Builders<T>.Filter;
            var filter = builder.Eq(model => model.PropertyUuid, propertyUuid)
                         & builder.Eq(model => model.Uuid, uuid);

            _collection.DeleteOneAsync(filter);
        }
    }
}