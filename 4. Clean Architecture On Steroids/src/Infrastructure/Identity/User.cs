namespace Blog.Infrastructure.Identity
{
    using System.Collections.Generic;
    using Domain.Entities;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public ICollection<Article> Articles { get; } = new List<Article>();

        public ICollection<Comment> Comments { get; } = new List<Comment>();
    }
}
