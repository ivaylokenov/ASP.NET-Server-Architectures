namespace Blog.Infrastructure.IntegrationTests.Persistence
{
    using System;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities;
    using IdentityServer4.EntityFramework.Options;
    using Infrastructure.Persistence;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Moq;
    using Shouldly;
    using Xunit;

    public class BlogDbContextTests : IDisposable
    {
        private readonly string userId;
        private readonly DateTime dateTime;
        private readonly BlogDbContext data;

        public BlogDbContextTests()
        {
            this.dateTime = new DateTime(3001, 1, 1);

            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.SetupGet(dt => dt.Now).Returns(this.dateTime);

            this.userId = "00000000-0000-0000-0000-000000000000";
            var currentUserMock = new Mock<ICurrentUser>();
            currentUserMock.Setup(m => m.UserId).Returns(this.userId);

            var options = new DbContextOptionsBuilder<BlogDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var operationalStoreOptions = Options.Create(
                new OperationalStoreOptions
                {
                    DeviceFlowCodes = new TableConfiguration("DeviceCodes"),
                    PersistedGrants = new TableConfiguration("PersistedGrants")
                });

            this.data = new BlogDbContext(options, operationalStoreOptions, currentUserMock.Object, dateTimeMock.Object);

            this.data.Articles.Add(new Article("Test Title", "Test Content", this.userId));

            this.data.SaveChanges();
        }

        [Fact]
        public async Task SaveChangesAsyncGivenNewArticleShouldSetCreatedProperties()
        {
            var article = new Article("Test Title 2", "Test Content 2", this.userId);

            this.data.Articles.Add(article);

            await this.data.SaveChangesAsync();

            article.CreatedOn.ShouldBe(this.dateTime);
            article.CreatedBy.ShouldBe(this.userId);
        }

        [Fact]
        public async Task SaveChangesAsyncGivenExistingArticleShouldSetModifiedProperties()
        {
            var article = await this.data.Articles.FindAsync(1);

            article.Title = "New Test Title";

            await this.data.SaveChangesAsync();

            article.ModifiedOn.ShouldNotBeNull();
            article.ModifiedOn.ShouldBe(this.dateTime);
            article.ModifiedBy.ShouldBe(this.userId);
        }

        public void Dispose() => this.data?.Dispose();
    }
}
