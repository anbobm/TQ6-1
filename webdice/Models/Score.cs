public class Score {
    public int Id {get; set;}
    public string Name {get; set;}
    public int Points {get; set;}
    public bool Open {get; set;} = true;
    public bool Upper {get; set;} = true;

    public Score(int id, string name, int points){
        Id = id;
        Name = name;
        Points = points;
    }
}
