# Aufgabe 1

Erstelle eine Klasse `Auto` mit den Attributen `Marke`, `Modell` und `Baujahr` und einer Methode `DisplayInfo()`, die diese formatiert ausgibt.

Erstelle mit `new` ein paar Objekte dieser Klasse und teste die `DisplayInfo()`-Methode.

# Aufgabe 2: Kapselung

Setze die Attribute jetzt `private` und schreibe Getter und Setter zum Auslesen und Setzen der Werte: `GetMarke()`, `SetMarke(marke)`, etc.

`Baujahr` soll nicht kleiner als 1880 sein.

# Aufgabe 3: Properties

Der Zugriff über Getter und Setter kann recht umständlich sein, daher gibt es die Möglichkeit stattdessen **Properties** zu verwenden.

Diese verhalten sich nach außen wie öffentliche Felder, können aber getter- und setter-Funktionalität implementieren.

Schreibe die Getter und Setter für die drei Attribute von `Auto` in Properties um.

Marke darf nur auf `BMW`, `Opel` oder `Trabant` gesetzt werden. Wenn die Marke gesetzt wird, wird das Modell auf ein konkretes Modell gesetzt, welches zu dieser Marke gehört.

Zulässige Werte für `Modell`, je nach gesetzter Marke:

* BMW: "3er", "5er", "7er"
* Opel: "Corsa", "Astra", "Adam"
* Trabant: "P 50", "P 60", "P 601", "1.1"

Das `Baujahr` darf weiterhin nur Werte >= 1880 enthalten.

# Aufgabe 4: Konstruktor

Ergänze einen passenden Konstruktor in der `Auto`-Klasse, der die Attribute mit den übergebenen Parametern initialisiert.

# Aufgabe 5

Schreibe eine Klasse `Cabrio` die von `Auto` erbt. Diese Klasse soll eine Property `IsVerdeckOffen` (`bool`) besitzen, die festhält, ob das Verdeck geöffnet ist oder nicht. Außerdem überschreibt (`override`) die Klasse die `DisplayInfo()`-Methode (dazu muss in der Basisklasse `Auto` die Methode noch als `virtual` deklariert werden).

# Aufgabe 6

Die Klasse `Auto` soll eine Basisklasse namens `Fahrzeug` bekommen, und diese soll `abstract` sein. In ihr soll es eine abstrakte Methode `Fahren()` geben. Diese soll eine passende Ausgabe in der Kommandozeile erzeugen. 

# Aufgabe 7

Schreibe eine Klasse `LKW` die von Fahrzeug erbt. Es soll eine Property `Beladung` (`int` in kg) und eine nur lesbare Property (`private set`) `MaximaleBeladung` (`int` in kg) geben, letztere wird dem Konstruktor übergeben. Die Beladung darf sich nur im Bereich zwischen 0 und `MaximaleBeladung` bewegen.