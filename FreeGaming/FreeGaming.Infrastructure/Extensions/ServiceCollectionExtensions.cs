namespace FreeGaming.Infrastructure.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using System.Reflection;

    using static Common.GlobalConstants;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            // Using reflection to add automatic dependency injection for new services.
            Assembly
                .Load($"{SolutionName}.Services")
                .GetTypes()
                .Where(t => t.IsClass && t.GetInterfaces().Any(i => i.Name.Equals($"I{t.Name}")))
                .Select(t => new
                {
                    Interface = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .ToList()
                .ForEach(s => services.AddTransient(s.Interface, s.Implementation));

            return services;
        }
    }
}
