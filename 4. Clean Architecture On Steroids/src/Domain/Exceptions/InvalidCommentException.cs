namespace Blog.Domain.Exceptions
{
    using System;

    public class InvalidCommentException : Exception
    {
        public InvalidCommentException(string message)
            : base(message)
        {
        }
    }
}
