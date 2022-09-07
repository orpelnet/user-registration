using FluentMigrator.Runner;
using FluentMigrator.Runner.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using UserRegistration.Migrations.Migrations;

namespace SGE.Migrations
{
    public class Program
    {
        private static IConfiguration Configuration;

        static void Main(string[] args)
        {
            var serviceProvider = CreateServices();

            using (var scope = serviceProvider.CreateScope())
            {
                Run(scope.ServiceProvider, args);
            }
#if DEBUG
            Console.Read();
#endif
        }

        static private IServiceProvider CreateServices()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", true);

            Configuration = builder.Build();

            return new ServiceCollection()
                .AddLogging()
                .Configure<FluentMigratorLoggerOptions>(configuration =>
                {
                    configuration.ShowSql = true;
                    configuration.ShowElapsedTime = true;
                })
                .AddFluentMigratorCore()
                //.AddSingleton<IConventionSet>(new DefaultConventionSet("public", null))
                .ConfigureRunner(runner =>
                {
                    runner.AddSqlServer2016()
                        .WithGlobalConnectionString(Configuration["DatabaseSettings:ConnectionString"])
                        .ScanIn(typeof(_20220907075700_AddTableUsuarios).Assembly).For.Migrations();
                })
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(true);
        }

        private static void Run(IServiceProvider serviceProvider, string[] args)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            if (args[0].ToUpper() == "UP")
            {
                runner.MigrateUp();
            }
            else
            {
                if (args.Length > 1)
                {
                    var version = Convert.ToInt64(args[1]);
                    runner.MigrateDown(version);
                }
                else
                {
                    runner.Rollback(1);
                }
            }
        }
    }
}