using System.Threading.Tasks;
using financeApi.Repositories;
using Microsoft.AspNetCore.Http;

namespace financeApi.Midlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserRepository _userRepository;

        public AuthMiddleware(RequestDelegate next, IUserRepository userRepository)
        {
            _next = next;
            _userRepository = userRepository;
        }

        public async Task Invoke(HttpContext context)
        {
            var username = context.Request.Headers["username"];
            var token = context.Request.Headers["token"];
            var propertyuuid = context.Request.Headers["propertyuuid"];

            if (IsNull(username, token, propertyuuid) || !_userRepository.Exists(username, token, propertyuuid))
            {
                context.Response.StatusCode = 401; 
                return;
            }

            await _next.Invoke(context);
        }

        private bool IsNull(string username, string token, string propertyuuid)
        {
            return username == null || token == null || propertyuuid == null;
        }
    }
}