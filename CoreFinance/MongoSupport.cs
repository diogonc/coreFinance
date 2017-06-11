using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson;

namespace CoreFinance
{
    public static class MongoSupport
    {
        public static void AddMongo(this IServiceCollection services, IConfigurationSection configuration)
        {
            services.AddSingleton(new MongoClient(configuration.GetSection("ConnectionString").Value));

            var conventionPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };
            
            ConventionRegistry.Register("IgnoreExtraElements", conventionPack, type => true);

            var pack = new ConventionPack {new EnumRepresentationConvention(BsonType.String) };

            ConventionRegistry.Register("EnumStringConvention", pack, t => true);
        }
    }
}