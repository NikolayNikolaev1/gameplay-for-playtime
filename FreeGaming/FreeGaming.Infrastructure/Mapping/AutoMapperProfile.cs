namespace FreeGaming.Infrastructure.Mapping
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static Common.GlobalConstants;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            IEnumerable<Type> allTypes = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(a => a.GetName().Name.Contains(SolutionName))
                .SelectMany(a => a.GetTypes());

            // Using reflection for automatic mapping from data to view models.
            allTypes
                .Where(t => t.IsClass
                    && !t.IsAbstract
                    && t.GetInterfaces()
                        .Where(i => i.IsGenericType)
                        .Select(i => i.GetGenericTypeDefinition())
                        .Contains(typeof(IMapFrom<>)))
                .Select(t => new
                {
                    Destination = t,
                    Source = t
                        .GetInterfaces()
                        .Where(i => i.IsGenericType)
                        .Select(i => new
                        {
                            Definition = i.GetGenericTypeDefinition(),
                            Arguments = i.GetGenericArguments()
                        })
                        .Where(i => i.Definition.Equals(typeof(IMapFrom<>)))
                        .SelectMany(i => i.Arguments)
                        .First()
                })
                .ToList()
                .ForEach(mapping => this.CreateMap(mapping.Source, mapping.Destination));

            // Using reflection for configurating automatic custom mapping.
            allTypes
                .Where(t => t.IsClass
                    && !t.IsAbstract
                    && typeof(IHaveCustomMapping).IsAssignableFrom(t))
                .Select(Activator.CreateInstance)
                .Cast<IHaveCustomMapping>()
                .ToList()
                .ForEach(mapping => mapping.ConfigureMapping(this));
        }
    }
}
