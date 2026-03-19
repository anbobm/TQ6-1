using System.Collections;

public abstract class Tier
{
    public abstract void LautGeben();
    
    public void Schlafen()
    {
        Console.WriteLine("Das Tier schläft");
    }
}

public class Hund : Tier
{
    public override void LautGeben()
    {
        Console.WriteLine("Wuff!");
    }
}

public class Katze : Tier, ISchnurrbar
{
    public override void LautGeben()
    {
        Console.WriteLine("Miau!");
    }

    public void Schnurren(string aufWessenSchoß)
    {
        Console.WriteLine($"Katze schnurr auf {aufWessenSchoß}'s Schoß");
    }
}

public interface ISchnurrbar
{
    void Schnurren(string aufWessenSchoß);
}