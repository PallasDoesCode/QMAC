using System.Windows;
using Caliburn.Micro;
using QMAC_Caliburn.Micro.ViewModels;

namespace QMAC_Caliburn.Micro
{
    public class AppBootstrapper : BootstrapperBase
    {
        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
