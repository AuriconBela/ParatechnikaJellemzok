namespace ParatechnikaJellemzok.Logic;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class JelAttribute(string jel) : Attribute
{
    public string Jel { get; } = jel;
}

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class MertekegysegAttribute(string mertekegyseg) : Attribute
{
    public string Mertekegyseg { get; } = mertekegyseg;
}

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class NevAttribute(string nev) : Attribute
{
    public string Nev { get; } = nev;
}
