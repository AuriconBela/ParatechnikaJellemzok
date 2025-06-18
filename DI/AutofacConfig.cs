using Autofac;
using ParatechnikaJellemzok.Logic;
using ParatechnikaJellemzok.Misc;

namespace ParatechnikaJellemzok.DI;

public static class AutofacConfig
{
    public static IContainer ConfigureContainer()
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<ParatechnikaiKonverterFactory>().As<IParatechnikaiKonverterFactory>().SingleInstance();
        builder.RegisterType<ParatechnikaiKonverterPresenter>().As<IParatechnikaiKonverterPresenter>().SingleInstance();
        builder.RegisterType<InputReader>().As<IInputReader>().SingleInstance();

        return builder.Build();
    }
}
