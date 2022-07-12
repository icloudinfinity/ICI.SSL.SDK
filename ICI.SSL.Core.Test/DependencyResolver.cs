using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ICI.SSL.Core.Test
{
    public static class DependencyResolver
    {
        public static ServiceProvider ServiceProvider()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddUserSecrets<TestProject>();
            IConfiguration Configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();

            services.AddLogging(options =>
            {
                options.AddDebug();
                options.SetMinimumLevel(LogLevel.Information);
            });

            services.AddSSLServices(options => Configuration.Bind("API", options));

            return services.BuildServiceProvider();
        }
    }

    public class TestProject
    {
    }
}
