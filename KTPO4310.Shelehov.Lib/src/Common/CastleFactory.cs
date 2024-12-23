using Castle.Windsor;

namespace KTPO4310.Shelehov.Lib.Common;

public static class CastleFactory
{
    public static IWindsorContainer container { get; private set; }

    static CastleFactory()
    {
        container = new WindsorContainer();
    }
}