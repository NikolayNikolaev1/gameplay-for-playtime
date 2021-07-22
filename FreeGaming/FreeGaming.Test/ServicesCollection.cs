namespace FreeGaming.Test
{
    using Fixtures;
    using Xunit;

    [CollectionDefinition("Service Collection")]
    public class ServicesCollection : ICollectionFixture<DatabaseFixture>, ICollectionFixture<MapperFixture>
    { }
}
