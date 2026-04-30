# Aufgabe 1

Erstelle ein neues Razor Pages Projekt. Erstelle dazu einen Ordner mit einem Projektnamen deiner Wahl und führe innerhalb diesem `dotnet new razor` aus.

Starte anschließend das Projekt über den Visual Studio Code Debugger. Der Browser sollte sich automatisch öffnen und die durch das Template vorgegebene Start-Webseite anzeigen.

# Aufgabe 2

Lösche alle Dateien und Unterordner im `Pages` Ordner.

Erstelle eine neue `Index.cshtml` im `Pages` Ordner: eine statische HTML-Seite mit einem Begrüßungstext.

Dies ist die Startseite, die beim Aufruf von `localhost:...` angezeigt wird.

# Aufgabe 3

Ergänze nun den HTML-Code in `Index.cshtml` mit C#-Code durch die Verwendung der [Razor-Syntax](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/razor):

* Lege zwei Variablen `name` und `alter` an und weise ihnen geeignete Werte zu
* In einem Absatz (paragraph) soll dann der Inhalt dieser Variablen ausgeben werden, z.B. `Ich bin ... und bin ... Jahre alt.`