namespace Blog.Application.UnitTests
{
    using System;
    using Application.Common.Interfaces;
    using Domain.Entities;
    using IdentityServer4.EntityFramework.Options;
    using Infrastructure.Persistence;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Moq;

    public static class ApplicationDbContextFactory
    {
        public static BlogDbContext Create()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var operationalStoreOptions = Options.Create(
                new OperationalStoreOptions
                {
                    DeviceFlowCodes = new TableConfiguration("DeviceCodes"),
                    PersistedGrants = new TableConfiguration("PersistedGrants")
                });

            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now)
                .Returns(new DateTime(3001, 1, 1));

            var currentUserServiceMock = new Mock<ICurrentUser>();
            currentUserServiceMock.Setup(m => m.UserId)
                .Returns("00000000-0000-0000-0000-000000000000");

            var context = new BlogDbContext(
                options, operationalStoreOptions,
                currentUserServiceMock.Object, dateTimeMock.Object);

            context.Database.EnsureCreated();

            SeedSampleData(context);

            return context;
        }

        public static void SeedSampleData(BlogDbContext context)
        {
            context.Articles.AddRange(
                new Article("Test Title 1", "Test Content 1", "Test User 1"),
                new Article("Test Title 2", "Test Content 2", "Test User 2"),
                new Article("Test Title 3", "Test Content 3", "Test User 3"));

            context.SaveChanges();
        }

        public static void Destroy(BlogDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}