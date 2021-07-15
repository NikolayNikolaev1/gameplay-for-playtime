namespace FreeGaming.Infrastructure.Mapping
{
    using AutoMapper;

    public interface IHaveCustomMapping
    {
        void ConfigureMapping(IProfileExpression profile);
    }
}
