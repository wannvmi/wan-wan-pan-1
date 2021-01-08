using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WanWan.Pan.App.Contracts.Services;
using WanWan.Pan.App.Contracts.Views;
using WanWan.Pan.App.Services;
using WanWan.Pan.App.ViewModels;
using WanWan.Pan.App.Views;

namespace WanWan.Pan.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        public T GetService<T>()
            where T : class
            => _host.Services.GetService(typeof(T)) as T;

        public App()
        {
        }

        private async void OnStartup(object sender, StartupEventArgs e)
        {
            var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            // For more information about .NET generic host see  https://docs.microsoft.com/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-3.0
            _host = Host.CreateDefaultBuilder(e.Args)
                .ConfigureAppConfiguration(c =>
                {
                    c.SetBasePath(appLocation);
                })
                .ConfigureServices(ConfigureServices)
                .Build();

            await _host.StartAsync();
        }

        private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            // TODO WTS: Register your services, viewmodels and pages here

            // App Host
            services.AddHostedService<ApplicationHostService>();

            // Services
            services.AddSingleton<IApplicationInfoService, ApplicationInfoService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // Views and ViewModels
            services.AddTransient<IShellWindow, ShellWindow>();
            services.AddTransient<ShellViewModel>();

            services.AddTransient<MainViewModel>();
            services.AddTransient<MainPage>();

            //services.AddTransient<BlankViewModel>();
            //services.AddTransient<BlankPage>();

            //services.AddTransient<WebViewViewModel>();
            //services.AddTransient<WebViewPage>();

            //services.AddTransient<MasterDetailViewModel>();
            //services.AddTransient<MasterDetailPage>();

            //services.AddTransient<ContentGridViewModel>();
            //services.AddTransient<ContentGridPage>();

            //services.AddTransient<ContentGridDetailViewModel>();
            //services.AddTransient<ContentGridDetailPage>();

            //services.AddTransient<DataGridViewModel>();
            //services.AddTransient<DataGridPage>();

            //services.AddTransient<SettingsViewModel>();
            //services.AddTransient<SettingsPage>();

            //services.AddTransient<IShellDialogWindow, ShellDialogWindow>();
            //services.AddTransient<ShellDialogViewModel>();

        }

        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
            _host = null;
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // TODO WTS: Please log and handle the exception as appropriate to your scenario
            // For more info see https://docs.microsoft.com/dotnet/api/system.windows.application.dispatcherunhandledexception?view=netcore-3.0
        }
    }
}
