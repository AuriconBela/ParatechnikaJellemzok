using System.Reflection;
using ParatechnikaJellemzok.Logic;

namespace ParatechnikaJellemzok.Misc;

public static class ParatechnikaiJellemzoExtensions
{
    public static string? Jel(this ParatechnikaiJellemzo jellemzo)
    {
        var type = typeof(ParatechnikaiJellemzo);
        var memInfo = type.GetMember(jellemzo.ToString());
        var attr = memInfo[0].GetCustomAttribute<JelAttribute>();
        return attr?.Jel;
    }

    public static string? Mertekegyseg(this ParatechnikaiJellemzo jellemzo)
    {
        var type = typeof(ParatechnikaiJellemzo);
        var memInfo = type.GetMember(jellemzo.ToString());
        var attr = memInfo[0].GetCustomAttribute<MertekegysegAttribute>();
        return attr?.Mertekegyseg;
    }

    public static string? Nev(this ParatechnikaiJellemzo jellemzo, bool isLowerCase)
    {
        var type = typeof(ParatechnikaiJellemzo);
        var memInfo = type.GetMember(jellemzo.ToString());
        var attr = memInfo[0].GetCustomAttribute<NevAttribute>();
        return isLowerCase? attr?.Nev.ToLower() : attr?.Nev;
    }
}
