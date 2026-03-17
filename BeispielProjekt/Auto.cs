class Auto2
{
    public string Marke;
    public string Modell;
    public int Baujahr;

    public void DisplayInfo()
    {
        Console.WriteLine($"Auto: {Marke} {Modell}, Baujahr {Baujahr}");
    }
}