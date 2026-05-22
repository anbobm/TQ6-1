using System.Text.Json;

class GameController {
    public List<Player> Players {get; set;} = [];
    public List<Turn> Turns {get; set;} = [];

    public void NextTurn(){
        if(Turns.Count == 0){
            //Implement Random Starting Player
            
            var turn = new Turn();
            turn.Player = Players[0];
            Turns.Add(turn);
        }
    }

    public Turn CurrentTurn() {
        return Turns[Turns.Count - 1];
    }

    public string CurrentTurnToJson(){
        var turn = this.CurrentTurn();
        //string test = JsonSerializer.Serialize(turn);
        Console.WriteLine(JsonSerializer.Serialize(turn));
        return JsonSerializer.Serialize(turn);
    }
}
