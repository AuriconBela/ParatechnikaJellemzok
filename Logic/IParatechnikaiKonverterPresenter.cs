namespace ParatechnikaJellemzok.Logic
{
    public interface IParatechnikaiKonverterPresenter
    {
        void Present(IParatechnikaiKonverter konverter, ParatechnikaiJellemzo? jellemzo, bool legreteg);
    }
}