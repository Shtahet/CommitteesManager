using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using CommitteesManager.AppUIClient.View;
using CommitteesManager.AppUIClient.ViewModel;
using CommitteesManager.BLL.Abstract;
using CommitteesManager.BLL.Concrete;
using CommitteesManager.DAL.Abstract;
using CommitteesManager.DAL.Model;

namespace CommitteesManager.AppUIClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IContainer _diContainer;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Configure DI container
            var builder = new ContainerBuilder();
            builder.RegisterType<ServiceProvider>().As<IServiceProvider>();
            builder.RegisterType<CMDB>().As<IDataProvider>();
            builder.RegisterType<MainWindowViewModel>().AsSelf();

            _diContainer = builder.Build();
            var model = _diContainer.Resolve<MainWindowViewModel>();
            var view = new MainWindow() { DataContext = model };
            view.Show();
        }
    }
}
