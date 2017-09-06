﻿using System.Collections.Generic;
using Domain;
using Domain.Repositories;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Infra.Repositories
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
                cm.GetMemberMap(t => t.Date).SetElementName("date");
                cm.GetMemberMap(t => t.Value).SetElementName("value");
                cm.GetMemberMap(t => t.PropertyUuid).SetElementName("propertyUuid");
                cm.GetMemberMap(t => t.Account).SetElementName("account");
                cm.GetMemberMap(t => t.Category).SetElementName("category");
            });

            var database = client.GetDatabase("finance");
            _collection = database.GetCollection<Transaction>("transaction");
        }

        public IEnumerable<Transaction> GetFromCategory(string propertyUuid, string categoryUuid)
        {
            var builder = Builders<Transaction>.Filter;
            var filter = builder.Eq(transaction => transaction.PropertyUuid, propertyUuid) & builder.Eq(transaction => transaction.Category.Uuid, categoryUuid);

            var cursor = _collection.Find(filter).ToListAsync();
            cursor.Wait();
            return cursor.Result;
        }
    }
}
