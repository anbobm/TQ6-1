# Aufgabe 1

* Installiere dir das Entity Framework mit SQLite als Provider in deinem WebApp-Projekt. Suche dir dazu auf nuget.org den passenden `add package`-Befehl raus.
* Erstelle dir eine `public` `Book.cs`-Klasse, mit den properties `Id`, `Title`, `Author`, `Pages`.
* Erstelle dir analog eine Tabelle `Books` in einer SQLite-Datenbank-Datei (im Projekt-Ordner) mit denselben Attributen.
* Erstelle eine Klasse `Db` die von `DbContext` erbt. Diese hat:
    * eine Property `DbSet<Book> Books`
    * `protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=<DATEINAME DER SQLITE-DATENBANK>");`
* Erstelle eine Page `/Books`, die alle Bücher aus der Datenbank ausliest und anzeigt. Erstelle dazu in der `OnGet`-Methode ein `Db`-Objekt mit `new Db()`. Mit diesem kannst du dann auf die Bücher zugreifen:

```csharp
var db = new Db();
...

... db.Books.ToList();
```

# Aufgabe 2

Erstelle nun auf gleiche Weise für die Entität `Member` mit den Attributen `Id`, `FirstName`, `LastName` und `Email` jeweils eine Tabelle, Klasse und Page zum Anzeigen.