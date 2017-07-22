using Domain.Categories;
using Domain.Repositories;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Migration;

namespace CoreFinance
{
    public static class DIConfig
    {
        public static void AddDIConfig(this IServiceCollection services)
        {
            services.AddSingleton<IAccountRepository, AccountRepository>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<ITransactionRepository, TransactionRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<MigrateTransactions, MigrateTransactions>();
        }
    }
}