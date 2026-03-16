public class Fahrzeug
{
    private int geschwindigkeit;
    private string marke = "foo";
    private string farbe = "bar";

    public int Geschwindigkeit {
        get
        {
            return geschwindigkeit;
        }
        set
        {
            if (value < 0)
            {
                return;
            }
            geschwindigkeit = value;
        }
    }

    public Fahrzeug(string marke, string farbe)
    {
        this.marke = marke;
        this.farbe = farbe;
    }

    public virtual void Fahren()
    {
        Console.WriteLine("Das Fahrzeug fährt");
    }

    public void Info()
    {
        Console.WriteLine("Ich bin ein Fahrzeug.");
        Console.WriteLine($"Ich bin {farbe} und {geschwindigkeit} schnell.");
    }

    public void Beschleunigen(int betrag)
    {
        geschwindigkeit = geschwindigkeit + betrag;
    }
}

public class Auto : Fahrzeug
{
    private bool istCabrio;

    public Auto(string marke, string farbe, bool istCabrio = false) : base(marke, farbe)
    {
        this.istCabrio = istCabrio;
    }

    public void Hupen()
    {
        Console.WriteLine("beep!");
    }

    public override void Fahren()
    {
        Console.WriteLine("Das Auto fährt");
    }
}