# Variablen

## Explizite Deklaration

Um eine Variable explizit zu deklarieren benutze das Pattern Datentyp gefolgt von Variablenname und optional eine Wertzuweisung.

Beispiel

'''
string meineZeichenfolge;
string zeichenfolgeMitWertzuweisung = "asdf";
int zahl1;
int zahlMitWertZuweisung = 5;
'''

## Implizite Deklaration

Bei der Impliziten Deklaration wird das Schlüsselwort var verwendet. Es muss eine Wertzuweisung erfolgen. Der Zugewiesene Wert legt automatisch den Datentyp fest.

Beispiel

'''
var meineZeichenfolge = "asdf";
var meineZahl = 5;
'''

# Ausgabe auf der Konsole

'''
Console.WriteLine("Text mit anschließendem Zeilenumbruch");
Console.Write("Text ohne Zeilenumbruch");
'''

# Datentypen

bool
byte
sbyte
char
decimal
double
float
int
uint
nint
nuint

# Integrale Typen

| Schlüsselwort | Bereich                           | Größe                                         |
| :------------ | :---------------------------------| :---------------------------------------------|
| sbyte         | -128 bis 127                      | Signierte 8-Bit-Ganzzahl                      |
| byte          | 0 bis 255                         | Nicht signierte 8-Bit-Ganzzahl                |
| short         | -32.768 bis 32.767                | Signierte 16-Bit-Ganzzahl                     |
| ushort        | 0 bis 65.535                      | Nicht signierte 16-Bit-Ganzzahl               |
| int           | -2.147.483.648 bis 2.147.483.647  | 32-Bit-Ganzzahl                               |
| uint          | 0 to 4.294.967.295                | Nicht signierte 32-Bit-Ganzzahl               | 
| long          | -9.223.372.036.854.775.808 bis    | 64-Bit-Ganzzahl                               |
|               | 9.223.372.036.854.775.807         | Nicht signierte 64-Bit-Ganzzahl               |
| ulong         | 0 bis 18.446.744.073.709.551.615  |                                               |
| nint          | Hängt von der Plattform ab        | Signierte 32-Bit- oder 64-Bit-Ganzzahl        |
| nuint         | Hängt von der Plattform ab        | Nicht signierte 32-Bit- oder 64-Bit-Ganzzahl  |

# Gleitkommatypen

| Schlüsselwort | Bereich                            | Größe    |
| :-------------| :----------------------------------| :--------|
| float         | ±1,5 x 10^−45 bis ±3,4 x 10^38     | 4 Byte   |
| double        | ±5.0 × 10^−324 bis ±1,7 × 10^308   | 8 Byte   |
| decimal       |	±1.0 × 10^-28 to ±7.9228 × 10^28 | 16 Bytes |


# String Templates

# Verbatim Strings

Aufgabe 03-03-2026

Vorgabe:

'''c#
string projectName = "ACME";

string russianMessage = "\u041f\u043e\u0441\u043c\u043e\u0442\u0440\u0435\u0442\u044c \u0440\u0443\u0441\u0441\u043a\u0438\u0439 \u0432\u044b\u0432\u043e\u0434";
'''

Gewünschte Ausgabe:

'''
View English output:
  c:\Exercise\ACME\data.txt

Посмотреть русский вывод:
  c:\Exercise\ACME\ru-RU\data.txt
'''

Lösung:

'''c#
string projectName = "ACME";

string russianMessage = "\u041f\u043e\u0441\u043c\u043e\u0442\u0440\u0435\u0442\u044c \u0440\u0443\u0441\u0441\u043a\u0438\u0439 \u0432\u044b\u0432\u043e\u0434";

Console.WriteLine($"View English output:\n  c:\\Exercise\\{projectName}\\data.txt");
Console.WriteLine($"\n{russianMessage}:\n  c:\\Exercise\\{projectName}\\ru-Ru\\data.txt");
'''

# Methoden
public / private
static -> Methode kann aufgerufen werden ohne dass ein Object der Klasse erzeugt wurde
void -> Methode hat keinen Rückgabewert

// seed ist optional
// random object muss erst angelegt werden.
var random = new Random(seed)

erzeugt random integer
random.Next(min, max)
// min inklusive
// max 
