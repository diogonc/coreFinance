using CoreFinance.Domain.Accounts;
using CoreFinance.Domain.Categories;
using CoreFinance.Domain.Repositories;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace CoreFinance
{
    public static class DIConfig
    {
        public static void AddDIConfig(this IServiceCollection services)
        {
            services.AddSingleton<IOwnerRepository, OwnerRepository>();
            services.AddSingleton<IAccountRepository, AccountRepository>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<ITransactionRepository, TransactionRepository>();
            services.AddSingleton<IGroupRepository, GroupRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<UpdateAccountService, UpdateAccountService>();
            services.AddSingleton<DeleteAccountService, DeleteAccountService>();
            services.AddSingleton<UpdateCategoryService, UpdateCategoryService>();
            services.AddSingleton<DeleteCategoryService, DeleteCategoryService>();
            services.AddSingleton<UpdateOwnerService, UpdateOwnerService>();
            services.AddSingleton<DeleteOwnerService, DeleteOwnerService>();
            services.AddSingleton<UpdateGroupService, UpdateGroupService>();
            services.AddSingleton<DeleteGroupService, DeleteGroupService>();
        }
    }
}