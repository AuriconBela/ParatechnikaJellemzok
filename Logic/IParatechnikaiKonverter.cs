namespace ParatechnikaJellemzok.Logic;

public interface IParatechnikaiKonverter
{
    double SdErtek { get; }
    double Mu { get; }
    double Delta { get; }
    double Ellenallas();
}
