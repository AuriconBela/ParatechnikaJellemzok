using Autofac;
using ParatechnikaJellemzok;
using ParatechnikaJellemzok.DI;
using ParatechnikaJellemzok.Logic;
using ParatechnikaJellemzok.Misc;
using UnitsNet;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var container = AutofacConfig.ConfigureContainer();
using var scope = container.BeginLifetimeScope();
var factory = scope.Resolve<IParatechnikaiKonverterFactory>();
var presenter = scope.Resolve<IParatechnikaiKonverterPresenter>();
var inputReader = scope.Resolve<IInputReader>();

IParatechnikaiKonverter konverter;

var jellemzo = ParatechnikaiJellemzo.SdErtek;
Length vastagsag;
var legreteg = false;
var input = "n";

Console.WriteLine(Strings.LegretegetVagyNem);

Console.ForegroundColor = Constants.InputTextColor;
try
{
    input = Console.ReadLine()?.Trim().ToLower();
}
finally
{
    Console.ResetColor();
}

if (input == "i")
{
    if (!inputReader.ReadTemperatureInCelsius(Strings.LegretegHomersekletBekeres, out var atlagHomerseklet) ||
        !inputReader.ReadLengthInCentimeters(Strings.RetegVastagsagBekeres, out vastagsag))
    {
        return;
    }
    legreteg = true;
    konverter = factory.Create_LegretegSzamito(vastagsag, atlagHomerseklet);
}
else
{
    if (!inputReader.ReadIntInRange(Strings.ParatechnikaiJellemzoValasztas, (int)ParatechnikaiJellemzo.SdErtek, (int)ParatechnikaiJellemzo.Delta, out var jellemzoszam) ||
        !inputReader.ReadPositiveDouble(((ParatechnikaiJellemzo)jellemzoszam).Nev(true).WithHungarianDefiniteArticle(true).Formatted(Strings.ErtekBekeres)!, out var ertek) ||
        !inputReader.ReadLengthInCentimeters(Strings.RetegVastagsagBekeres, out vastagsag))
    {
        Console.ReadLine();
        return;
    }
    jellemzo = (ParatechnikaiJellemzo)jellemzoszam;
      
    konverter = factory.Create_NemLegretegSzamito(jellemzo, ertek, vastagsag);
}

presenter.Present(konverter, legreteg ? null : jellemzo, legreteg);
