// See https://aka.ms/new-console-template for more information

var hero = new Hero();
var villain = new Villain();

while(hero.checkAlive() && villain.checkAlive()){
    villain.defend(hero.atk());
    Console.WriteLine(villain.status());
    if(!villain.checkAlive()){
        break;
    }
    hero.defend(villain.atk());
    Console.WriteLine(hero.status());
}

if(!villain.checkAlive() && hero.checkAlive()){
    Console.WriteLine("Winner: Hero");
};

if(villain.checkAlive() && !hero.checkAlive()){
    Console.WriteLine("Winner: Villain");
};

if(!villain.checkAlive() && !hero.checkAlive()){
    Console.WriteLine("Both Losers");
}

class Hero {
    public int health {get; set;} = 10;

    public int atk(){
        var random = new Random();
        return random.Next(1, 10);
    }

    public int defend(int enemyAtk){
        health -= enemyAtk;
        return health;
    }

    public bool checkAlive(){
        return health >= 0;
    }

    public string status(){
        return $"Hero Health: {health}, Alive: {checkAlive()}";
    }
}

class Villain {
    public int health {get; set;} = 10;
    public int atk(){
        var random = new Random();
        return random.Next(1, 10);
    }

    public int defend(int enemyAtk){
        health -= enemyAtk;
        return health;
    }

    public bool checkAlive(){
        return health >= 0;
    }

    public string status(){
        return $"Villain Health: {health}, Alive: {checkAlive()}";
    }
}
