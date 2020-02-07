namespace Blog.Web.Services
{
    using System.Security.Claims;
    using Application.Common.Interfaces;
    using Microsoft.AspNetCore.Http;

    public class CurrentUserService : ICurrentUser
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor) 
            => this.UserId = httpContextAccessor
                .HttpContext?
                .User?
                .FindFirstValue(ClaimTypes.NameIdentifier);

        public string UserId { get; }
    }
}
