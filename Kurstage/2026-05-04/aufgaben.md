# Aufgabe 1

Schreibe eine Razor Page `/Greeting` die im Query-String einen Parameter `name` erwartet, und den darüber übergebenen String in einer Begrüßung ausgibt, z.B. `Willkommen, [name]!`.


# Aufgabe 2

Ergänze die `Index`-Page um ein Formular mit einem Textfeld und einem Button, in den der Nutzer seinen Namen einträgt.
Das Formular sendet die Daten an die `Greeting`-Page aus Aufgabe 1: `action="/Greeting"`, `method=get`.


# Aufgabe 3

Ergänze das Formular um ein Textfeld, in dem der Nutzer sein Alter angeben kann. Die `OnGet`-Methode kann nun direkt einen Parameter vom Typ `int` bekommen. Untersuche, wie dieser sich verhält, wenn der entsprechende Schlüssel leer ist oder keine Zahl enthält.