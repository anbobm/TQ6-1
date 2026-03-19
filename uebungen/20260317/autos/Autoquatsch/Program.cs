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
auto7.Fahren();
auto7.DisplayInfo();

var cabrio1 = new Cabrio("BMW", "3er", "1990", true);
cabrio1.DisplayInfo();
cabrio1.Fahren();

var cabrio2 = new Cabrio("BMW", "3er", "1980", false);
cabrio2.DisplayInfo();
cabrio2.Fahren();
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

var lkw1 = new LKW(5000, 0);
lkw1.Fahren();
lkw1.Beladung = 6000;
lkw1.DisplayInfo();
lkw1.Beladung = 3000;
lkw1.DisplayInfo();

interface ILog {
   public void LogInfo(string message);
   public void LogWarning(string message);
   public void LogError(string message);
}

class ConsoleLogger : ILog {
    public void LogInfo(string message){
        Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} Info: {message}");
    }
    public void LogWarning(string message){
        Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} Warning: {message}");
    }
    public void LogError(string message){
        Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} Error: {message}");
    }
}

class FileLogger : ILog {
    public void LogInfo(string message){
        File.AppendAllText("Logs/ilogger.log", $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} Info: {message}\n");
    }
    public void LogWarning(string message){
        File.AppendAllText("Logs/ilogger.log", $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} Warning: {message}\n");
    }
    public void LogError(string message){
        File.AppendAllText("Logs/ilogger.log", $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} Error: {message}\n");
    }
}

/*
class FileLogger : ILog {

}
*/

abstract class Fahrzeug {
    abstract public void Fahren();
}

class LKW : Fahrzeug {

    private ConsoleLogger consoleLogger = new ConsoleLogger();
    private FileLogger fileLogger = new FileLogger();
    private int _beladung = 0; 
    public int MaximaleBeladung {get; private set;}
    public int Beladung {
        get {
         return _beladung;
        } 
        set{
            if(value <= MaximaleBeladung){
                _beladung = value;
                consoleLogger.LogInfo($"Fracht mit einem Gewicht von {value} wurde geladen ");
                fileLogger.LogInfo($"Fracht mit einem Gewicht von {value} wurde geladen ");
            }
            consoleLogger.LogError($"Fracht ist zu schwer");
            fileLogger.LogError($"Fracht ist zu schwer");
        }
    }

    public LKW (int maximaleBeladung, int beladung = 0) {
        MaximaleBeladung = maximaleBeladung;
        _beladung = beladung;
    }
 
    public override void Fahren(){
        Console.WriteLine("Der LKW fährt...");
    }

    public void DisplayInfo(){
        Console.WriteLine($"Ein Toller LKW mit zulässiger Beladung von {MaximaleBeladung}kg. Die derzeitige Ladung wiegt {_beladung}kg ");
    }
   
}

class Auto : Fahrzeug {

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

    virtual public void DisplayInfo(){
        Console.WriteLine($"Ein tolles Auto der Marke: {_marke}, Modell: {_modell}, Baujahr: {_baujahr}");
    }

    public override void Fahren(){
        Console.WriteLine("Das Auto fährt...");
    }
}

class Cabrio : Auto{
    public bool IsVerdeckOffen {get; set;}

    public Cabrio(string marke, string modell, string baujahr, bool verdeckOffen) : base(marke, modell, baujahr){
        IsVerdeckOffen = verdeckOffen;
    }

    override public void DisplayInfo(){
        Console.Write($"\nEin tolles Cabrio der Marke: {Marke}, Modell: {Modell}, Baujahr: {Baujahr}.");
        if(IsVerdeckOffen){
            Console.Write(" Die Sonne scheint. Verdeck offen. Lets Goooo.\n");
        }else{
            Console.Write(" Es regnet mal wieder. Verdeck zu. Laune im Keller -_-\n");
        }
    }

    public override void Fahren(){
        Console.WriteLine("Das Cabrio fährt...");
    }
}
