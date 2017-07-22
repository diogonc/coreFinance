using System.Collections.Generic;
using Domain.Repositories;
using Domain;
using Domain.Categories;
using MongoDB.Driver;
using System.Linq;
using MongoDB.Bson.Serialization;

using System;

namespace Migration
{
    public class MigrateTransactions
    {
        private MongoClient _client;
        private IAccountRepository _accountRepository;
        private ICategoryRepository _categoryRepository;
        private IMongoCollection<TransactionToMigrate> _collection;

        public MigrateTransactions(MongoClient client, 
                                   IAccountRepository accountRepository,
                                   ICategoryRepository categoryRepository)
        {
            _client = client;
            _accountRepository = accountRepository;
            _categoryRepository = categoryRepository;

            BsonClassMap.RegisterClassMap<TransactionToMigrate>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(t => t.Uuid).SetElementName("uuid");
                cm.GetMemberMap(t => t.Description).SetElementName("description");                
                cm.GetMemberMap(t => t.Date).SetElementName("date");
                cm.GetMemberMap(t => t.Value).SetElementName("value");
                cm.GetMemberMap(t => t.PropertyUuid).SetElementName("propertyUuid");
                cm.GetMemberMap(t => t.Account).SetElementName("account");
                cm.GetMemberMap(t => t.Category).SetElementName("category");
                cm.GetMemberMap(t => t.AccountUuid).SetElementName("accountUuid"); 
                cm.GetMemberMap(t => t.CategoryUuid).SetElementName("categoryUuid"); 
            });

            var database = client.GetDatabase("finance");
            _collection = database.GetCollection<TransactionToMigrate>("transaction");
        }

        public IEnumerable<TransactionToMigrate> GetAllTransactionsToMigrate()
        {
            var cursor = _collection.Find(FilterDefinition<TransactionToMigrate>.Empty).ToListAsync();
            cursor.Wait();
            return cursor.Result;
        }

        public void Update(TransactionToMigrate model)
        {
            _collection.ReplaceOneAsync(Builders<TransactionToMigrate>.Filter.Eq(m => m.Uuid, model.Uuid), model);
        }

        public void Migrate()
        {
            var transactions = GetAllTransactionsToMigrate();
            foreach (var transaction in transactions)
            {
                var propertyUuid = transaction.PropertyUuid;
                var category = _categoryRepository.Get(transaction.CategoryUuid, propertyUuid);
                var account = _accountRepository.Get(transaction.AccountUuid, propertyUuid);
                
                transaction.Account = account;
                transaction.Category = category;

                Update(transaction);
            }
        }
    }
}
