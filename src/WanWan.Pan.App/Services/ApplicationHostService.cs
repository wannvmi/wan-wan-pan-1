using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WanWan.Pan.App.Contracts.Services;
using WanWan.Pan.App.Contracts.Views;
using WanWan.Pan.App.ViewModels;

namespace WanWan.Pan.App.Services
{
    public class ApplicationHostService : IHostedService
    {        
        private IShellWindow _shellWindow;

        private readonly IServiceProvider _serviceProvider;
        private readonly INavigationService _navigationService;
        private readonly IApplicationInfoService _applicationInfoService;

        private readonly ILogger<ApplicationHostService> _logger;
        private readonly IHostEnvironment _hostEnvironment;
        public ApplicationHostService(
            IServiceProvider serviceProvider, 
            INavigationService navigationService,
            IApplicationInfoService applicationInfoService,
            ILogger<ApplicationHostService> logger, 
            IHostEnvironment hostEnvironment)
        {
            _serviceProvider = serviceProvider;
            _navigationService = navigationService;
            _applicationInfoService = applicationInfoService;
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Environment: {@_hostEnvironment}", _hostEnvironment);
            _logger.LogInformation("Version: {@Version}", _applicationInfoService.GetVersion());

            // Initialize services that you need before app activation
            await InitializeAsync();

            await HandleActivationAsync();

            // Tasks after activation
            await StartupAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("WanWan.Pan.App is stopping.");
            await Task.CompletedTask;
        }

        private async Task InitializeAsync()
        {
            await Task.CompletedTask;
        }

        private async Task StartupAsync()
        {
            _logger.LogInformation("WanWan.Pan.App running.");
            await Task.CompletedTask;
        }

        private async Task HandleActivationAsync()
        {
            if (App.Current.Windows.OfType<IShellWindow>().Count() == 0)
            {
                // Default activation that navigates to the apps default page
                _shellWindow = _serviceProvider.GetService(typeof(IShellWindow)) as IShellWindow;
                _navigationService.Initialize(_shellWindow.GetNavigationFrame());
                _shellWindow.ShowWindow();
                _navigationService.NavigateTo(typeof(MainViewModel).FullName);
                await Task.CompletedTask;
            }
        }
    }
}
