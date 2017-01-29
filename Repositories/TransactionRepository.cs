using financeApi.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace financeApi.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(MongoClient client)
        {
            BsonClassMap.RegisterClassMap<Transaction>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(t => t.Uuid).SetElementName("uuid");
                cm.GetMemberMap(t => t.Description).SetElementName("description");
                cm.GetMemberMap(t => t.Payed).SetElementName("payed");
                cm.GetMemberMap(t => t.Date).SetElementName("date");
                cm.GetMemberMap(t => t.Value).SetElementName("value");
                cm.GetMemberMap(t => t.CategoryUuid).SetElementName("categoryUuid");
                cm.GetMemberMap(t => t.CategoryName).SetElementName("categoryName");
                cm.GetMemberMap(t => t.CategoryType).SetElementName("categoryType");
                cm.GetMemberMap(t => t.AccountUuid).SetElementName("accountUuid");
                cm.GetMemberMap(t => t.AccountName).SetElementName("accountName");
                cm.GetMemberMap(t => t.PropertyUuid).SetElementName("propertyUuid");
            });

            var database = client.GetDatabase("finance");
            _collection = database.GetCollection<Transaction>("transaction");
        }
    }
}