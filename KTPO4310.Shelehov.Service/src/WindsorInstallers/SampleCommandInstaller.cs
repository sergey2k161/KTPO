using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using KTPO4310.Shelehov.Lib.SampleCommands;

namespace KTPO4310.Shelehov.Service.WindsorInstallers;

public class SampleCommandInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(
            Component.For<ISampleCommands>().ImplementedBy<SampleCommandDecorator>().LifeStyle.Singleton,
            Component.For<ISampleCommands>().ImplementedBy<SelfCommandDecorator>().LifeStyle.Singleton,
            Component.For<ISampleCommands>().ImplementedBy<SecondCommand>().LifeStyle.Singleton);
    }
}