namespace Blog.Application.Common.Interfaces
{
    using System;
    using Services;

    public interface IDateTime : IService
    {
        DateTime Now { get; }
    }
}
