namespace Blog.Application.Infrastructure
{
    public interface ILogger<T>
    {
        void LogInformation(string message);

        void LogWarning(string message);

        void LogError(string message);
    }
}
