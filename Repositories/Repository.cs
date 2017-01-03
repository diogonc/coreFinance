using System.Collections.Generic;
using MongoDB.Driver;

namespace financeApi.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected IMongoCollection<T> _collection {get; set;}
        
        public IEnumerable<T> GetAll()
        {
            var cursor = _collection.Find(FilterDefinition<T>.Empty).ToListAsync();
            cursor.Wait();
            return cursor.Result;
        }
    }
}