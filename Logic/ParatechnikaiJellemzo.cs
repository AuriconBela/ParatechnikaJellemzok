namespace ParatechnikaJellemzok.Logic;

public enum ParatechnikaiJellemzo
{
    [Nev("Páradiffúziós egyenértékű légrétegvastagság (Sd)")]
    [Jel("Sd")]
    [Mertekegyseg("m")]
    SdErtek = 1,
    [Nev("Páradiffúziós ellenállási szám (μ)")]
    [Jel("μ")]
    [Mertekegyseg("")]
    Mu = 2,
    [Nev("Páradiffúziós tényező (δ)")]
    [Jel("δ")]
    [Mertekegyseg("g/msMPa")]
    Delta = 3,
    [Nev("Páradiffúziós ellenállás")]
    [Jel("Rv")]
    [Mertekegyseg("m²sMPa/g")]
    Rv = 4
}
