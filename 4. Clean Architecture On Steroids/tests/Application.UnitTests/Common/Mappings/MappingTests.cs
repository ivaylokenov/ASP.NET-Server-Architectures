namespace Blog.Application.UnitTests.Common.Mappings
{
    using AutoMapper;
    using System;
    using Application.Articles.Queries.Details;
    using Domain.Entities;
    using Xunit;

    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider configuration;
        private readonly IMapper mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            this.configuration = fixture.ConfigurationProvider;
            this.mapper = fixture.Mapper;
        }

        [Theory]
        [InlineData(typeof(ArticleDetailsModel), typeof(ArticleDetailsOutputModel))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            this.mapper.Map(instance, source, destination);
        }
    }
}
