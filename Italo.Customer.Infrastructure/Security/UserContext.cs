using Italo.Customer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Italo.Customer.Infrastructure.Security
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public string? GetUserNameByToken()
        {
            if (_httpContextAccessor.HttpContext.User.Identity is ClaimsIdentity identity && 
                _httpContextAccessor.HttpContext.User.Claims.Count() >= 1)
                return identity.FindFirst(ClaimTypes.NameIdentifier).Value;

            return "noUser";
        }
    }
}
