using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Templates;
using SupervisorCompany.App.Context;

namespace SupervisorCompany.App
{
    internal static class Program
    {
        private static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            services.AddLogging(c =>
            {
                var appLogPath = ctx.Configuration["AppLog"];

                if (string.IsNullOrWhiteSpace(appLogPath))
                {
                    return;
                }

                var logger = new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .WriteTo.File(
                        new ExpressionTemplate("{@t:yyyy-MM-dd HH:mm:ss.fff zzz} [{@l:u3}] {SourceContext}\r\n{@m:lj}\r\n{@x}"),
                        appLogPath)
                    .CreateLogger();

                c.AddSerilog(logger);
            });

            services.AddDbContextFactory<SupervisorCompanyDbContext>((p, c) =>
            {
                c.UseFirebird(ctx.Configuration.GetConnectionString("Database"));
                c.EnableSensitiveDataLogging();
            });

            services.AddSingleton<MainForm>();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args)
                .ConfigureServices(ConfigureServices);

            return builder;
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            var host = CreateHostBuilder(args).Build();
            host.Start();
            Application.Run(host.Services.GetRequiredService<MainForm>());
        }
    }
}