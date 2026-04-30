# Aufgabe 1

Erstelle ein neues Razor Pages Projekt. Erstelle dazu einen Ordner mit einem Projektnamen deiner Wahl und führe innerhalb diesem `dotnet new razor` aus.

Starte anschließend das Projekt über den Visual Studio Code Debugger. Der Browser sollte sich automatisch öffnen und die durch das Template vorgegebene Start-Webseite anzeigen.

# Aufgabe 2

Lösche alle Dateien und Unterordner im `Pages` Ordner.

Erstelle eine neue `Index.cshtml` im `Pages` Ordner: eine statische HTML-Seite mit einem Begrüßungstext.

Schreibe in die allererste Zeile `@page`, so dass ASP .NET Core diese `cshtml`-Datei als "Razor Page" erkennt.

Die `Index.cshtml` ist die Startseite, die beim Aufruf von `http://localhost:.../` angezeigt wird.

Starte das Projekt und überprüfe, dass die Änderung funktioniert hat.

# Aufgabe 3

Ergänze nun den HTML-Code in `Index.cshtml` mit C#-Code durch die Verwendung der [Razor-Syntax](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/razor):

* Lege zwei Variablen `name` und `alter` an und weise ihnen geeignete Werte zu
* In einem Absatz (paragraph) soll dann der Inhalt dieser Variablen ausgeben werden, z.B. `Ich bin ... und bin ... Jahre alt.`


# Aufgabe 4

Zeige auf der Startseite auch das aktuelle Datum im Format `yyyy-MM-dd` an.

Nutze außerdem die `@if` Syntax, um entweder einen Paragraphen mit `Willkommen zurück` anzuzeigen, oder einen Link `Login`, je nachdem ob die (vorher anzulegende) Variable `isLoggedIn` `true` oder `false` ist.


# Aufgabe 5

Erstelle eine Klasse `Book` in einer `Book.cs` mit den Properties: Title, Author, Pages (Seitenzahl).

Erzeuge in der `Index.cshtml` ein Array aus Buchobjekten (circa 3 Stück mit selbstgewählten Angaben zu Titel, Autor, Seitenzahl).

Erzeuge dann aus diesem Array mittels einer `@foreach`-Schleife eine unsortierte Liste `<ul> ... </ul>`, die jeweils den Titel des Buches darstellt.

# Aufgabe 6

Statt einer `<ul>`, erzeuge nun eine Tabelle `<table>`, die alle 3 Informationen der Buchobjekte darstellt.