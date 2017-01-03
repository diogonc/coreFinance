// using System.Collections.Generic;
// using MongoDB.Driver;

// namespace financeApi.Repositories
// {
//     public abstract class Repository<T> : IRepository<T> where T : class
//     {
//         private IMongoCollection<T> _collection;

//         public Repository(MongoClient client)
//         {
//             var database = client.GetDatabase("finance");
//             ConfigureMap();

//             _collection = database.GetCollection<T>(nameof(T));
//         }
//         public abstract void ConfigureMap();          

//         public IEnumerable<T> GetAll()
//         {
//             var allUserCursor = _collection.Find(FilterDefinition<T>.Empty).ToListAsync();
//             allUserCursor.Wait();
//             return allUserCursor.Result;
//         }
//     }
// }