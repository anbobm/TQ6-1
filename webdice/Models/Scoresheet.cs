public class ScoreSheet {
    public int? Id {get; set;}
    public Player? Player {get; set;}
    public Game? Game {get; set;}
    public Game ActiveGame {get; set;}
    public int? Ones {get; set;}
    public int? Twos {get; set;}
    public int? Threes {get; set;}
    public int? Fours {get; set;}
    public int? Fives {get; set;}
    public int? Sixes {get; set;}
    public int? ThreeOfAKind {get; set;}
    public int? FourOfAKind {get; set;}
    public int? FiveOfAKind {get; set;}
    public int? FullHouse {get; set;}
    public int? Straight {get; set;}
    public int? LongStraight {get; set;}
    public int? Chance {get; set;}

    public int ScoreTopPart(){
        int topPart = 0;
        topPart += ((Ones ?? 0) + (Twos ?? 0) + (Threes ?? 0) + (Fours ?? 0) + (Fives ?? 0) + (Sixes ?? 0));
        return topPart;
    }

    public int TopPartBonus(int points){
        if(points >= 63)return 35;
        return 0;
    }

    public int ScoreTopTotal(){
        int top = ScoreTopPart();
        int bonus = TopPartBonus(top);
        return top + bonus;
    }

    public int ScoreBottomPart(){
        int bottomPart = 0;
        bottomPart += ((ThreeOfAKind ?? 0) + (FourOfAKind ?? 0) + (FiveOfAKind ?? 0) + (FullHouse ?? 0) + (Straight ?? 0) + (LongStraight ?? 0) + (FiveOfAKind ?? 0) + (Chance ?? 0));
        return bottomPart;
    }

    public int ScoreTotal(){
        return ScoreTopPart() + ScoreBottomPart();
    }
}
