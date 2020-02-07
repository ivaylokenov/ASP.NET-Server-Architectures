namespace Blog.Application.Common.Exceptions
{
    using System;

    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"Entity '{name}' ({key}) was not found.")
        {
        }
    }
}
