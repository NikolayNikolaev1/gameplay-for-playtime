namespace FreeGaming.Test
{
    using Data;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using System.IO;
    using System.Threading.Tasks;
    using Web;

    using static Common.GlobalConstants;
    // TODO: Look into more detailed clean code infrastructure around Fixtures in xUnit.
    public class Testing
    {
        private static IConfigurationRoot _configuration;
        private static IServiceScopeFactory _scopeFactory;

        public void Run()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

            ServiceCollection services = new ServiceCollection();

            Startup startup = new Startup(_configuration);

            services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
                w.ApplicationName == $"{SolutionName}.Web" &&
                w.EnvironmentName == "Development"));

            startup.ConfigureServices(services);

            _scopeFactory = services
                .BuildServiceProvider()
                .GetService<IServiceScopeFactory>();
        }

        public static async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            FreeGamingDbContext context = scope
                .ServiceProvider
                .GetService<FreeGamingDbContext>();

            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }
    }
}
