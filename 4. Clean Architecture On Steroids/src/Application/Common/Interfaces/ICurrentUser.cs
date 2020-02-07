namespace Blog.Application.Common.Interfaces
{
    using Services;

    public interface ICurrentUser : IScopedService
    {
        string UserId { get; }
    }
}
