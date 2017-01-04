using financeApi.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace financeApi
{
    public static class DIConfig
    {
        public static void AddDIConfig(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
        }
    }
}