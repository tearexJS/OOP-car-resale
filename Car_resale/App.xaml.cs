using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CarResale.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CarResale.BL;
using App.Services;
using App.ViewModels;
using App.Views;
using App.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using CarResale.DAL.Factories;
using App.ViewModels.Interfaces;

namespace Car_resale
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {

            _host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(ConfigureAppConfiguration)
                .ConfigureServices((context, services) => { ConfigureServices(context.Configuration, services); })
                .Build();
        }

        private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSingleton<ShellView>();
            services.AddBLServices();
            services.AddSingleton<IMediator, Mediator>();

            services.Configure<DALSettings>(configuration.GetSection("CarResale:DAL"));

            services.AddSingleton<IDbContextFactory<CarResaleDbContext>>(provider =>
            {
                var dalSettings = provider.GetRequiredService<IOptions<DALSettings>>().Value;
                return new LocalDbContextFactory(dalSettings.ConnectionString!, dalSettings.SkipMigrationAndSeedDemoData);
            });

            services.AddSingleton<ShellViewModel>();
            services.AddSingleton<IBrowseViewModel, BrowseViewModel>();
            services.AddSingleton<INewAdvertViewModel,NewAdvertViewModel>();
            services.AddSingleton<IAdvertViewModel, AdvertViewModel>();
        }

        private void ConfigureAppConfiguration(HostBuilderContext context, IConfigurationBuilder builder)
        {
            builder.AddJsonFile(@"C:\Users\pivop\Documents\GitHub\OOP-car-resale2\Car_resale\AppSettings.json", false, false);
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();
            var dbContextFactory = _host.Services.GetRequiredService<IDbContextFactory<CarResaleDbContext>>();

            var dalSettings = _host.Services.GetRequiredService<IOptions<DALSettings>>().Value;

            await using ( var dbx = await dbContextFactory.CreateDbContextAsync())
            {
                if (dalSettings.SkipMigrationAndSeedDemoData)
                {
                    await dbx.Database.EnsureDeletedAsync();
                    await dbx.Database.EnsureCreatedAsync();
                }
            }
            var shellView = _host.Services.GetRequiredService<ShellView>();
            shellView.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }
    }
}
