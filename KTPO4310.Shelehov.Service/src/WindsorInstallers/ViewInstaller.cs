using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using KTPO4310.Shelehov.Lib.LogAn;
using KTPO4310.Shelehov.Service.Views;

namespace KTPO4310.Shelehov.Service.WindsorInstallers;

public class ViewInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(
            Component.For<IView>().ImplementedBy<ConsoleView>().LifeStyle.Singleton);
    }
}