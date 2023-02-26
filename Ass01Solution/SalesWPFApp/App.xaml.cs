using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Repository;
using DataAccess.Management;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            //Config for DependencyInjection (01)
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton(typeof(IMemberRepository), typeof(MemberRepository));
            services.AddSingleton<MemberManagement>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var window = serviceProvider.GetService<MainWindow>();
            window.Show();
        }
    }
}
