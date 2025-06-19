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
        builder.RegisterType<InputReader>().As<IInputReader>();

        builder.Register<IConsoleColorSetter>((ctx, p) =>
        {
            var color = p.Named<ConsoleColor>("consoleColor");
            return new ConsoleColorSetter(color);
        }).AsSelf();

        builder.Register<Func<ConsoleColor, IConsoleColorSetter>>(ctx =>
        {
            var c = ctx.Resolve<IComponentContext>();
            return color => c.Resolve<IConsoleColorSetter>(new NamedParameter("consoleColor", color));
        });        

        return builder.Build();
    }
}
