using UnitsNet;

namespace ParatechnikaJellemzok.Logic;

public interface IParatechnikaiKonverterFactory
{
    IParatechnikaiKonverter Create_LegretegSzamito(Length vastagsag, Temperature atlagHomerseklet);
    IParatechnikaiKonverter Create_NemLegretegSzamito(ParatechnikaiJellemzo jellemzo, double megadottertek, Length vastagsag);
}