class Auto2
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
    public void DisplayInfo()
    {
        Console.WriteLine($"Auto: {Marke} {Modell}, Baujahr {Baujahr}");
    }
}