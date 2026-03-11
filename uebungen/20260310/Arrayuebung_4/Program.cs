// See https://aka.ms/new-console-template for more information

string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";

string[] orderArray = orderStream.Split(',');
char[] errorArray = ['r', 'o', 'r', 'r', 'E', ' ', '-'];


foreach(string order in orderArray){
    if(order.Length == 4){
        Console.WriteLine(order);
    }else{
        char[] letterArray = order.ToCharArray();
        Array.Resize(ref letterArray, 15);
        for(int i=0; i<letterArray.Length; i+=1){
            if(letterArray[i] == '\0'){
                letterArray[i] = ' ';
            }
        }
        for(int i = 0; i<errorArray.Length; i+=1){
            letterArray[letterArray.Length - i - 1] = errorArray[i];
        }
        Console.WriteLine(String.Join("", letterArray));
    }
}
