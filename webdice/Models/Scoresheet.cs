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
        bottomPart += ((ThreeOfAKind ?? 0) + (FourOfAKind ?? 0) + (FiveOfAKind ?? 0) + (FullHouse ?? 0) + (Straight ?? 0) + (LongStraight ?? 0) + (Chance ?? 0));
        return bottomPart;
    }

    public int ScoreTotal(){
        return ScoreTopPart() + ScoreBottomPart();
    }

    public bool ScoreOnes(List<int> roll){
        if(Ones != null)return false;
        int score = 0;
        foreach(int eyes in roll){
            if(eyes == 1)score += eyes;
        }
        Ones = score;
        return true;
    }

    public bool ScoreTwos(List<int> roll){
        if(Twos != null)return false;
        int score = 0;
        foreach(int eyes in roll){
            if(eyes == 2)score += eyes;
        }
        Twos = score;
        return true;
    }

    public bool ScoreThrees(List<int> roll){
        if(Threes != null)return false;
        int score = 0;
        foreach(int eyes in roll){
            if(eyes == 3)score += eyes;
        }
        Threes = score;
        return true;
    }

    public bool ScoreFours(List<int> roll){
        if(Fours != null)return false;
        int score = 0;
        foreach(int eyes in roll){
            if(eyes == 4)score += eyes;
        }
        Fours = score;
        return true;
    }

    public bool ScoreFives(List<int> roll){
        if(Fives != null)return false;
        int score = 0;
        foreach(int eyes in roll){
            if(eyes == 5)score += eyes;
        }
        Fives = score;
        return true;
    }

    public bool ScoreSixes(List<int> roll){
        if(Sixes != null)return false;
        int score = 0;
        foreach(int eyes in roll){
            if(eyes == 6)score += eyes;
        }
        Sixes = score;
        return true;
    }

    public bool Score3OfAKind(List<int> roll){
        if(ThreeOfAKind != null){return false;}
        Dictionary<int, int> eyeDict = new Dictionary<int, int> {
            {1, 0},
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0},
            {6, 0},
        };

        foreach(var key in eyeDict.Keys.ToList()){
            int count = roll.Count(x => x==key);
            eyeDict[key] = count;
        }

        bool valid3OfAKind = false;
        foreach(var kvp in eyeDict){
            if(kvp.Value > 2){
                valid3OfAKind = true;
                break;
            }
        }

        ThreeOfAKind = 0;
        if(!valid3OfAKind){
            return true;
        }

        foreach(int dice in roll){
            ThreeOfAKind += dice;
        }
        
        return true;
    }

    public bool Score4OfAKind(List<int> roll){
        if(FourOfAKind != null){return false;}
        Dictionary<int, int> eyeDict = new Dictionary<int, int> {
            {1, 0},
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0},
            {6, 0},
        };

        foreach(var key in eyeDict.Keys.ToList()){
            int count = roll.Count(x => x==key);
            eyeDict[key] = count;
        }

        bool valid4OfAKind = false;
        foreach(var kvp in eyeDict){
            if(kvp.Value > 3){
                valid4OfAKind = true;
                break;
            }
        }

        FourOfAKind = 0;
        if(!valid4OfAKind){
            return true;
        }

        foreach(int dice in roll){
            FourOfAKind += dice;
        }
        
        return true;
    }

    public bool Score5OfAKind(List<int> roll){
        if(FiveOfAKind != null){return false;}
        Dictionary<int, int> eyeDict = new Dictionary<int, int> {
            {1, 0},
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0},
            {6, 0},
        };

        foreach(var key in eyeDict.Keys.ToList()){
            int count = roll.Count(x => x==key);
            eyeDict[key] = count;
        }

        bool valid5OfAKind = false;
        foreach(var kvp in eyeDict){
            if(kvp.Value > 4){
                valid5OfAKind = true;
                break;
            }
        }

        FiveOfAKind = 0;
        if(!valid5OfAKind){
            return true;
        }

        FiveOfAKind = 50;
        return true;
    }

    public bool ScoreLongStraight(List<int> roll){
        if(LongStraight != null){return false;}
        SortedDictionary<int, int> eyeDict = new SortedDictionary<int, int> {
            {1, 0},
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0},
            {6, 0},
        };

        foreach(var key in eyeDict.Keys.ToList()){
            int count = roll.Count(x => x==key);
            eyeDict[key] = count;
        }

        bool validStraight = false;
        int straightCounter = 0;

        foreach(var kvp in eyeDict){
            if(kvp.Value > 0){straightCounter += 1;}
            if(straightCounter > 4){
                validStraight = true;
                break;
            }
            if(kvp.Value == 0){straightCounter = 0;}
        }

        LongStraight = 0;
        if(!validStraight){
            return true;
        }

        LongStraight = 40;
        return true;
    }

    public bool ScoreStraight(List<int> roll){
        if(Straight != null){return false;}
        SortedDictionary<int, int> eyeDict = new SortedDictionary<int, int> {
            {1, 0},
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0},
            {6, 0},
        };

        foreach(var key in eyeDict.Keys.ToList()){
            int count = roll.Count(x => x==key);
            eyeDict[key] = count;
        }

        bool validStraight = false;
        int straightCounter = 0;

        foreach(var kvp in eyeDict){
            if(kvp.Value > 0){straightCounter += 1;}
            if(straightCounter > 3){
                validStraight = true;
                break;
            }
            if(kvp.Value == 0){straightCounter = 0;}
        }

        Straight = 0;
        if(!validStraight){
            return true;
        }

        Straight = 30; 
        return true;
    }

    public bool ScoreChance(List<int> roll){
        if(Chance != null){return false;}
        Chance = 0;
        foreach(int dice in roll){Chance += dice;}
        return true; 
    }

    public bool ScoreFullHouse(List<int> roll){
        if(FullHouse != null){return false;}
        Dictionary<int, int> eyeDict = new Dictionary<int, int> {
            {1, 0},
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0},
            {6, 0},
        };

        foreach(var key in eyeDict.Keys.ToList()){
            int count = roll.Count(x => x==key);
            eyeDict[key] = count;
        }

        bool validFullHouse = false;
        bool found3OfAKind = false;
        bool foundPair = false;
        bool found5OfAKind = false;

        foreach(var kvp in eyeDict){
            if(kvp.Value == 3){
                found3OfAKind = true;
            }
            if(kvp.Value == 2){
                foundPair = true;
            }
            if(kvp.Value > 4){
                found5OfAKind = true;
            }
        }

        if((found3OfAKind && foundPair) || found5OfAKind){
            validFullHouse = true;
        }

        FullHouse = 0;

        if(!validFullHouse){
            return true;
        }

        FullHouse = 25; 
        return true;
    }
}
