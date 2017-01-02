using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace financeApi
{
    public static class MongoSupport
    {
        public static void AddMongo(this IServiceCollection services, IConfigurationSection configuration)
        {
            services.AddSingleton(new MongoClient(configuration.GetSection("ConnectionString").Value));
        }
    }
}