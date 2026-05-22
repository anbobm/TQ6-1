class Turn {
    public Player? Player {get; set;}
    public List<List<int>> Rolls {get; set;} = [];
    public Score? Score {get; set;}

    public int RollCount(){
        return Rolls.Count;
    }

    public List<int> LastRoll(){
        return Rolls[Rolls.Count-1];
    }
}
