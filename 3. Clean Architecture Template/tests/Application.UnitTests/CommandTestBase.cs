using DefaultTemplate.Infrastructure.Persistence;
using System;

namespace DefaultTemplate.Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        public CommandTestBase()
        {
            Context = ApplicationDbContextFactory.Create();
        }

        public ApplicationDbContext Context { get; }

        public void Dispose()
        {
            ApplicationDbContextFactory.Destroy(Context);
        }
    }
}