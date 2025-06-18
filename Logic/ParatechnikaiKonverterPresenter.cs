using ParatechnikaJellemzok.Misc;

namespace ParatechnikaJellemzok.Logic;

public class ParatechnikaiKonverterPresenter : IParatechnikaiKonverterPresenter
{
    public void Present(IParatechnikaiKonverter konverter, ParatechnikaiJellemzo? jellemzo, bool legreteg)
    {
        Console.WriteLine();
        Console.ForegroundColor = Constants.ResultTextColor;
        try
        {
            if (legreteg)
            {
                Console.WriteLine(ErtekMertekegyseggel(ParatechnikaiJellemzo.Rv, konverter.Ellenallas()));
            }
            else if (jellemzo.HasValue)
            {
                switch (jellemzo.Value)
                {
                    case ParatechnikaiJellemzo.SdErtek:
                        Console.WriteLine(ErtekMertekegyseggel(ParatechnikaiJellemzo.Mu, konverter.Mu));
                        Console.WriteLine(ErtekMertekegyseggel(ParatechnikaiJellemzo.Delta, konverter.Delta));
                        Console.WriteLine(ErtekMertekegyseggel(ParatechnikaiJellemzo.Rv, konverter.Ellenallas()));
                        break;
                    case ParatechnikaiJellemzo.Mu:
                        Console.WriteLine(ErtekMertekegyseggel(ParatechnikaiJellemzo.Delta, konverter.Delta));
                        Console.WriteLine(ErtekMertekegyseggel(ParatechnikaiJellemzo.SdErtek, konverter.SdErtek));
                        Console.WriteLine(ErtekMertekegyseggel(ParatechnikaiJellemzo.Rv, konverter.Ellenallas()));
                        break;
                    case ParatechnikaiJellemzo.Delta:
                        Console.WriteLine(ErtekMertekegyseggel(ParatechnikaiJellemzo.Mu, konverter.Mu));
                        Console.WriteLine(ErtekMertekegyseggel(ParatechnikaiJellemzo.SdErtek, konverter.SdErtek));
                        Console.WriteLine(ErtekMertekegyseggel(ParatechnikaiJellemzo.Rv, konverter.Ellenallas()));
                        break;
                }
            }
        }
        finally
        {
            Console.ResetColor(); 
        }
        Console.WriteLine("\nKilépéshez nyomjon meg egy billentyűt...");
        Console.ReadKey();
    }

    private static string ErtekMertekegyseggel(ParatechnikaiJellemzo? jellemzo, double ertek)
    {
        return $"{jellemzo?.Jel()} = {ertek} {jellemzo?.Mertekegyseg()}";
    }
}
