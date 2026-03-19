abstract class Fahrzeug2
{
    abstract public void Fahren();
}

class Auto2 : Fahrzeug2
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

    public Auto2(string marke, string modell, int baujahr)
    {
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

    public int Baujahr
    {
        get
        {
            return baujahr;
        }
        set
        {
            if (value < 1880) return;
            
            baujahr = value;
        }
    }
    
    public string Marke
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

    public string Modell
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
        Console.WriteLine("Brumm Brumm!");
    }
}

class Cabrio2 : Auto2
{
    public bool IsVerdeckOffen {get; set;}

    public Cabrio2(string marke, string modell, int baujahr, bool isVerdeckOffen = false) : base(marke, modell, baujahr)
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