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