using Domain.Accounts;
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
            services.AddSingleton<IGroupRepository, GroupRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IOwnerRepository, OwnerRepository>();
            services.AddSingleton<Domain.Accounts.UpdateAccountService, Domain.Accounts.UpdateAccountService>();
            services.AddSingleton<DeleteAccountService, DeleteAccountService>();
            services.AddSingleton<Domain.Categories.UpdateCategoryService, Domain.Categories.UpdateCategoryService>();
            services.AddSingleton<DeleteCategoryService, DeleteCategoryService>();
            services.AddSingleton<MigrateTransactions, MigrateTransactions>();
        }
    }
}