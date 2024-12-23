using KTPO4310.Shelehov.Lib.Common;
using KTPO4310.Shelehov.Lib.SampleCommands;
using KTPO4310.Shelehov.Service.LibConfig;
using KTPO4310.Shelehov.Service.WindsorInstallers;

namespace KTPO4310.Shelehov.Service;

class Program
{
    static void Main(string[] args)
    {
        CastleFactory.container.Install(
            new SampleCommandInstaller(),
            new ViewInstaller());

        for (int i = 0; i < 5; i++)
        {
            ISampleCommands someCommand = CastleFactory.container.Resolve<ISampleCommands>();
            someCommand.Execute();
        }
    }
}

