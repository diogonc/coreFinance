﻿using CoreFinance.Domain.Accounts;
using CoreFinance.Domain.Repositories;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Infra.Repositories
{
    public class OwnerRepository : Repository<Owner>, IOwnerRepository
    {
        public OwnerRepository(MongoClient client)
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Owner)))
            {
                BsonClassMap.RegisterClassMap<Owner>(cm =>
                            {
                                cm.AutoMap();
                                cm.GetMemberMap(a => a.Name).SetElementName("name");
                                cm.GetMemberMap(a => a.Priority).SetElementName("priority");
                                cm.GetMemberMap(a => a.UserLogin).SetElementName("userLogin");
                            });
            }

            var database = client.GetDatabase("finance");
            _collection = database.GetCollection<Owner>("owner");
        }
    }
}
