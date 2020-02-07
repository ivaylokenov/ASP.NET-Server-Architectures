namespace Blog.Infrastructure.Persistence.Models
{
    using System.Collections.Generic;
    using Domain.Entities;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public ICollection<Article> Articles { get; } = new List<Article>();
    }
}
