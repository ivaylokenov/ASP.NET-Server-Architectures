namespace Blog.Domain.Exceptions
{
    using System;

    public class InvalidArticleException : Exception
    {
        public InvalidArticleException(string message)
            : base(message)
        {
        }
    }
}
