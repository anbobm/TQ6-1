// See https://aka.ms/new-console-template for more information

var scoreSheet = new ScoreSheet();

Console.WriteLine(scoreSheet.Points[0].Name);
Console.WriteLine(scoreSheet.Points[0].Points);
Console.WriteLine(scoreSheet.Points[0].Open);

class Turn {
    public int tries {get; set;} = 0;
    public List<int> rolls 
}

class Score {
    public string Name {get; set;}
    public int Points {get; set;}
    public bool Open {get; set;} = true;

    public Score(string name, int points){
        Name = name;
        Points = points;
    }
}

class ScoreSheet {
    public List<Score> Points = new List<Score>{
        new Score("⚀ ⚀ ⚀", 0),
        new Score("twos", 0),
    };

    public void PrintSheet(){

    }
}

//List<Int32> = new List(Int32);
//core.Add(5);




/*
class ScoreSheet {
    list score = new List(Int32)
}

Console.WriteLine("[1]: 1er:")
*/
