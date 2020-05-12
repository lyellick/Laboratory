using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Binder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Laboratory.DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {

            var services = ConfigureServices(args);

            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<Application>().Run();
        }

        private static IServiceCollection ConfigureServices(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddCommandLine(args);

            var config = builder.Build();
            services.Configure<AppSettings>(options => config.GetSection("AppSettings"));
            services.AddSingleton<IConfiguration>(config);
            services.AddTransient<Application>();

            return services;
        }
    }
}
