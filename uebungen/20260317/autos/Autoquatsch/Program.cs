// See https://aka.ms/new-console-template for more information
/*
var auto1 = new Auto();
auto1.Marke = "BMW";
auto1.Baujahr = "2012";
auto1.DisplayInfo();

var auto2 = new Auto();
auto2.Marke = "Porsche"; // Falsche Marke
auto2.Baujahr = "2012";
auto2.DisplayInfo();

var auto3 = new Auto();
auto3.Marke = "Trabant"; 
auto3.Modell = "P50"; 
auto3.Baujahr = "2012";
auto3.DisplayInfo();

var auto4 = new Auto();
auto4.Marke = "Trabant"; 
auto4.Modell = "p950"; // falsches Modell
auto4.Baujahr = "2012";
auto4.DisplayInfo();
*/
var auto5 = new Auto("Opel", "Corsa", "1990");
auto5.DisplayInfo();
var auto6 = new Auto("Opel", "Csa", "1990");
auto6.DisplayInfo();
var auto7 = new Auto("VW", "Csa", "1990");
auto7.DisplayInfo();
/*
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
*/

/*
var auto4 = new AutoMitKonstruktor("General Motors", "K.I.T.T", "1982");
auto4.DisplayInfo();
*/
class Auto {

    private string _marke = "Unbekannte Marke";
    private string _modell = "Unbekanntes Modell";
    private string _baujahr = "Unbekanntes Baujahr";

    private Dictionary<string, List<string>> validCars = new Dictionary<string, List<string>>()
    {
        {"BMW", ["3er", "5er", "7er"]},
        {"Opel", ["Corsa", "Astra", "Adam"]},
        {"Trabant", ["P50", "P60", "P601", "1.1"]}
    };

    public Auto(string marke, string modell, string baujahr){
        if(!validCars.ContainsKey(marke))return;
        _marke = marke;
        if(!validCars[marke].Contains(modell))return;
        _modell = modell;
        
        int baja = 0;
        bool isValid =  int.TryParse(baujahr, out baja);
        if(isValid && baja >= 1880)_baujahr = baja.ToString();
    }

    public string Marke {
        get{return _marke;}
        set{
            string[] validChoices = ["BMW", "Opel", "Trabant"];
            if(!validChoices.Contains(value))return;
            _marke = value;
            var random = new Random();
            List<List<string>> validModels = [["3er", "5er", "7er"], ["Corsa", "Astra", "Adam"], ["P50", "P60", "P601", "1.1"]];
            int markeIndex = Array.IndexOf(validChoices, _marke);
            //Console.WriteLine(markeIndex);
            //Console.WriteLine(validModels[markeIndex].Count);
            string randomModell = validModels[markeIndex][random.Next(0, validModels[markeIndex].Count)];
            _modell = randomModell;
        }
    }

    public string Modell {
        get{return _modell;}
        set{
            if(_modell == null)return;
            string[] validModell = ["BMW", "Opel", "Trabant"];
            int markeIndex = Array.IndexOf(validModell, _marke);
            List<List<string>> validModels = [["3er", "5er", "7er"], ["Corsa", "Astra", "Adam"], ["P50", "P60", "P601", "1.1"]];
            if(!validModels[markeIndex].Contains(value))return;
            _modell = value;
        }
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
