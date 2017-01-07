using financeApi.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace financeApi
{
    public static class DIConfig
    {
        public static void AddDIConfig(this IServiceCollection services)
        {
            services.AddSingleton<IAccountRepository, AccountRepository>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<ITransactionRepository, TransactionRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();

        }
    }
}