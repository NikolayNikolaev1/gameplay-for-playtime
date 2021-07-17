namespace FreeGaming.Test
{
    using AutoMapper;
    using Data;
    using Infrastructure.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System;

    // TODO: Look into xUnit Shared Context between Tests
    // Documentation: https://xunit.net/docs/shared-context
    public abstract class ServiceTests
    {
        private FreeGamingDbContext dbContext;
        private IMapper mapper;

        public FreeGamingDbContext DbContext
            => this.dbContext ??= new FreeGamingDbContext(
                new DbContextOptionsBuilder<FreeGamingDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);

        public IMapper Mapper
            => this.mapper ??= new MapperConfiguration(
                cfg => cfg.AddProfile<AutoMapperProfile>())
            .CreateMapper();
    }
}
