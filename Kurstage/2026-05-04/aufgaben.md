# Aufgabe 1

Schreibe eine Razor Page `/Greeting` die im Query-String einen Parameter `name` erwartet, und den darüber übergebenen String in einer Begrüßung ausgibt, z.B. `Willkommen, [name]!`.


# Aufgabe 2

Ergänze die `Index`-Page um ein Formular mit einem Textfeld und einem Button, in den der Nutzer seinen Namen einträgt.
Das Formular sendet die Daten an die `Greeting`-Page aus Aufgabe 1: `action="/Greeting"`, `method=get`.


# Aufgabe 3

Ergänze das Formular um ein Textfeld, in dem der Nutzer sein Alter angeben kann. Die `OnGet`-Methode kann nun direkt einen Parameter vom Typ `int` bekommen. Untersuche, wie dieser sich verhält, wenn der entsprechende Schlüssel leer ist oder keine Zahl enthält.


# Aufgabe 4

Anstatt seines Alters soll der Benutzer nun sein Geburtstag angeben. In `OnGet` prüfen wir dann, ob der Benutzer heute Geburtstag hat. Falls ja gratulieren wir ihm.

# Aufgabe 5

Zusätzlich zum Geburtstag überprüfen wir nun außerdem auf Volljährigkeit und erzeugen eine entsprechende Ausgabe.


# Aufgabe 6

Erstelle eine Page mit einem Formular, mit dem der Benutzer seine Versandkosten berechnen lassen kann.

Mit einer select-box kann er zwischen "Deutschland", "EU", und "International" wählen. Nach dem Absenden erhält er die Versandkosten angezeigt (0€, 5€, 15€).