// See https://aka.ms/new-console-template for more information

var auto1 = new Auto();
auto1.Marke = "Nissan";
auto1.Modell = "Micra";
auto1.Baujahr = "2012";
auto1.DisplayInfo();

var auto2 = new Auto();
auto2.Marke = "DeLorean";
auto2.Modell = "DMC-12";
auto2.Baujahr = "1981";
auto2.DisplayInfo();

var auto3 = new Auto();
auto3.Marke = "Koenigsegg";
auto3.Modell = "CC850";
auto3.Baujahr = "2024";
auto3.DisplayInfo();
/*
var auto4 = new AutoMitKonstruktor("General Motors", "K.I.T.T", "1982");
auto4.DisplayInfo();
*/
class Auto {

    private string? _marke;
    private string? _modell;
    private string? _baujahr;

    public string Marke {
        get{return _marke;}
        set{
            _marke = value;
        }
    }
    public string Modell {
        get{return _modell;}
        set{_modell = value;}
    }

    public string Baujahr {
        get{return _baujahr;}
        set{
            int baujahr = 0;
            bool isValid = int.TryParse(value, out baujahr);
            if(baujahr >= 1880){
                _baujahr = baujahr.ToString();
            } 
        }
    }

    public void DisplayInfo(){
        Console.WriteLine($"Ein tolles Auto der Marke: {_marke}, Modell: {_modell}, Baujahr: {_baujahr}");
    }
}

class AutoMitKonstruktor {
    public string Marke {get; set;}
    public string Modell {get; set;}
    public string Baujahr {get; set;}

    public AutoMitKonstruktor(string marke, string modell, string baujahr){
        Marke = marke;
        Modell = modell;
        Baujahr = baujahr;
    }

    public void DisplayInfo(){
        Console.WriteLine($"Ein tolles Auto der Marke {Marke}, Modell: {Modell}, Baujahr: {Baujahr}");
    }
}
