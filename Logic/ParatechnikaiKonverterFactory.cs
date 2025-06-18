using UnitsNet;

namespace ParatechnikaJellemzok.Logic;

public class ParatechnikaiKonverterFactory : IParatechnikaiKonverterFactory
{
    public IParatechnikaiKonverter Create_LegretegSzamito(Length vastagsag, Temperature atlagHomerseklet)
    {
        return new ParatechnikaiKonverterLegreteg(vastagsag, atlagHomerseklet);
    }

    public IParatechnikaiKonverter Create_NemLegretegSzamito(ParatechnikaiJellemzo jellemzo, double megadottertek, Length vastagsag)
    {
        return new ParatechnikaiKonverterNemLegreteg(jellemzo, megadottertek, vastagsag);
    }
}
