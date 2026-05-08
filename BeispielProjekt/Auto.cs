abstract class Fortbewegungsmittel
{
    public double Geschwindigkeit { get; set; }
}

abstract class Schwimmzeug : Fortbewegungsmittel
{
    abstract public void Schwimmen();
}

abstract class Flugzeug : Fortbewegungsmittel
{
    abstract public void Fliegen();
}

abstract class Fahrzeug : Fortbewegungsmittel
{
    abstract public void Fahren();

    virtual public int Baujahr { get; set; }

    virtual public string Marke { get; set; }

    virtual public string Modell { get; set; }
}


class Auto : Fahrzeug
{
    private Dictionary<string, string[]> marken = new Dictionary<string, string[]>()
    {
        {"BMW", ["3er", "5er", "7er"]},
        {"Opel", ["Corsa", "Astra", "Adam"]},
        {"Trabant", ["P 50,", "P 60", "P 601", "1.1"]}
    };

    private int baujahr;

    private string marke;

    private string modell;

    private ILog logger;

    public Auto(string marke, string modell, int baujahr, ILog logger)
    {
        this.logger = logger;

        if (baujahr < 1880) this.baujahr = 1880;

        this.baujahr = baujahr;
        
        if (!marken.ContainsKey(marke))
        {
            this.marke = "BMW";
            this.modell = "3er";
            return;
        }

        this.marke = marke;

        if(!marken[marke].Contains(modell))
        {
            this.modell = marken[marke].First();
            return;
        }

        this.modell = modell;
    }

    override public int Baujahr
    {
        get
        {
            return baujahr;
        }
        set
        {
            if (value < 1880)
            {
                logger.LogWarning($"Es wurde versucht Baujahr auf einen ungültigen Wert ({value}) zu setzen.");
                return;
            }
            
            baujahr = value;
        }
    }
    
    override public string Marke
    {
        get
        {
            return marke;
        }
        set
        {
            if (!marken.ContainsKey(value)) return;

            marke = value;

            modell = marken[marke].First();
        }
    }

    override public string Modell
    {
        get
        {
            return modell;
        }
        set
        {
            if(!marken[marke].Contains(value)) return;

            modell = value;
        }
    }
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Auto: {Marke} {Modell}, Baujahr {Baujahr}");
    }

    public override void Fahren()
    {
        if (DateTime.Now.Hour >= 12)
        {
            Console.WriteLine("Brumm Brumm!");
        }
    }
}

class Cabrio : Auto
{
    private bool isVerdeckOffen;

    public bool IsVerdeckOffen
    {
        get
        {
            return isVerdeckOffen;
        }
        set
        {
            if (Geschwindigkeit != 0)
            {
                return;
            }

            isVerdeckOffen = value;
        }
    }

    public Cabrio(string marke, string modell, int baujahr, ILog logger, bool isVerdeckOffen = false) : base(marke, modell, baujahr, logger)
    {
        IsVerdeckOffen = isVerdeckOffen;
    }    

    override public void DisplayInfo(){
        Console.Write($"\nEin tolles Cabrio der Marke: {Marke}, Modell: {Modell}, Baujahr: {Baujahr}.");
        if(IsVerdeckOffen){
            Console.Write(" Die Sonne scheint. Verdeck offen. Lets Goooo.\n");
        }else{
            Console.Write(" Es regnet mal wieder. Verdeck zu. Laune im Keller 😑\n");
        }
    }
}

class Lkw : Fahrzeug
{
    private int beladung;

    public int Beladung
    {
        get
        {
            return beladung;
        }
        set
        {
            if (value < 0 || value > MaximaleBeladung)
            {
                return;
            }

            beladung = value;
        }
    }

    public int MaximaleBeladung { get; private set; }

    public Lkw(int maximaleBeladung)
    {
        MaximaleBeladung = maximaleBeladung;
    }

    public override void Fahren()
    {
        Console.WriteLine("Der LKW fährt 🤷");
    }
}