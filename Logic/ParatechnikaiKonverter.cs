using ParatechnikaJellemzok.Misc;
using UnitsNet;

namespace ParatechnikaJellemzok.Logic;

public abstract class ParatechnikaiKonverter(Length vastagsag) : IParatechnikaiKonverter
{
    protected readonly Length _vastagsag = vastagsag;

    public double SdErtek { get; protected set; }
    public double Mu { get; protected set; }
    public double Delta { get; protected set; }

    public abstract double Ellenallas();
}

public class ParatechnikaiKonverterLegreteg(Length vastagsag, Temperature atlagHomerseklet) : ParatechnikaiKonverter(vastagsag)
{
    private readonly Temperature _atlagHomerseklet = atlagHomerseklet;

    public override double Ellenallas()
    {
        var delta = Constants.WaterVaporDiffusionCoefficientInAir * Math.Pow(_atlagHomerseklet.DegreesCelsius + Constants.ZeroCelsius, 0.81) / Constants.LegkoriNyomas;
        Delta = delta;
        return _vastagsag.Meters / delta / 1E9;
    }
}

public class ParatechnikaiKonverterNemLegreteg : ParatechnikaiKonverter
{
    protected double _megadottErtek;
    private readonly ParatechnikaiJellemzo _megadottJellemzo;
    public ParatechnikaiKonverterNemLegreteg(ParatechnikaiJellemzo jellemzo, double megadottErtek, Length vastagsag) : base(vastagsag)
    {
        _megadottJellemzo = jellemzo;
        _megadottErtek = megadottErtek;

        switch (jellemzo)
        {
            case ParatechnikaiJellemzo.SdErtek:
                SdErtek = megadottErtek;
                Mu = SzamolMu();
                Delta = SzamolDelta();
                break;
            case ParatechnikaiJellemzo.Mu:
                Mu = megadottErtek;
                SdErtek = SzamolSdErtek();
                Delta = SzamolDelta();
                break;
            case ParatechnikaiJellemzo.Delta:
                Delta = megadottErtek;
                Mu = SzamolMu();
                SdErtek = SzamolSdErtek();
                break;
        }
    }

    public override double Ellenallas()
    {
        switch (_megadottJellemzo)
        {
            case ParatechnikaiJellemzo.SdErtek:
                return 0.000001 * _megadottErtek / Constants.WaterVaporDiffusionCoefficientInAir;
            case ParatechnikaiJellemzo.Mu:
                Delta = Constants.WaterVaporDiffusionCoefficientInAir / _megadottErtek;
                return 0.000001 * _vastagsag.Meters / Delta;
            case ParatechnikaiJellemzo.Delta:
                return _vastagsag.Meters / _megadottErtek;
            default:
                throw new NotImplementedException();
        }
    }

    private double SzamolMu()
    {
        var ellenallas = Ellenallas();
        return 1E8 * ellenallas * Constants.WaterVaporDiffusionCoefficientInAir / _vastagsag.Meters;
    }
    private double SzamolDelta()
    {
        var ellenallas = Ellenallas();
        return 1E2 * ellenallas / _vastagsag.Meters;
    }
    private double SzamolSdErtek()
    {
        var ellenallas = Ellenallas();
        return 1E6 * ellenallas * Constants.WaterVaporDiffusionCoefficientInAir;
    }
}
