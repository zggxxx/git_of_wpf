using Microsoft.Extensions.DependencyInjection;
using recharge_system.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace recharge_system
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Services = ConfigureServices();
            HomePage homePage = new HomePage();
            homePage.Show();
        }

        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; set; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<Common.IUserOrderService, Common.UserOrderService>();
            services.AddTransient<ViewModel.DepPageVM>();
            return services.BuildServiceProvider();
        }
    }
}
