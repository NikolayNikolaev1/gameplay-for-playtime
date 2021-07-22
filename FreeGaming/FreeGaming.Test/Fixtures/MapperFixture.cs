namespace FreeGaming.Test.Fixtures
{
    using AutoMapper;
    using Infrastructure.Mapping;

    public class MapperFixture
    {
        public MapperFixture()
        {
            this.InitializeMapper();
        }

        public IMapper Mapper { get; private set; }

        private void InitializeMapper()
            => this.Mapper = new MapperConfiguration(
                cfg => cfg.AddProfile<AutoMapperProfile>())
            .CreateMapper();
    }
}
