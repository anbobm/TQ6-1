// ═══════════════════════════════════════════════════════════════════
// LÖSUNG 12 – Reguläre Ausdrücke & eigene Fehlerklassen
// ═══════════════════════════════════════════════════════════════════
//
// GRUNDIDEE:
// Wenn Benutzer etwas eingeben, kann alles Mögliche falsch sein:
// zu kurz, zu lang, gefährliche Zeichen, falsches Format.
//
// Reguläre Ausdrücke (RegExp) helfen uns, Text auf Muster zu prüfen.
// Eigene Fehlerklassen helfen uns, Fehler gezielt zu unterscheiden
// und unterschiedlich darauf zu reagieren.
//
// ═══════════════════════════════════════════════════════════════════


// ─────────────────────────────────────────────────────────────────
// AUFGABE 12.1 – Eigene Fehlerklassen erstellen
// ─────────────────────────────────────────────────────────────────
//
// JavaScript hat bereits Fehlertypen wie "Error" oder "TypeError".
// Wir erstellen eigene, damit wir später genau wissen,
// was für ein Fehler aufgetreten ist.
//
// "extends Error" bedeutet: Unsere Klasse erbt alles von Error
// (z.B. message, stack) und fügt eigene Sachen hinzu.


// Fehler für ungültige Eingaben des Benutzers
class EingabeFehler extends Error {

  constructor(fehlermeldung) {
    // super() ruft den Konstruktor der Elternklasse (Error) auf.
    // Ohne diesen Aufruf würde "this.message" nicht funktionieren.
    super(fehlermeldung);

    // this.name überschreibt den Standard-Namen "Error"
    // mit unserem eigenen Namen
    this.name = "EingabeFehler";

    // Wir speichern außerdem, wann der Fehler aufgetreten ist
    this.zeitpunkt = new Date().toLocaleString("de-DE");
  }

} // ← Ende EingabeFehler


// Fehler für Probleme beim Speichern (z.B. localStorage voll)
class SpeicherFehler extends Error {

  constructor(fehlermeldung) {
    super(fehlermeldung);
    this.name = "SpeicherFehler";
    this.zeitpunkt = new Date().toLocaleString("de-DE");
  }

} // ← Ende SpeicherFehler


// ─────────────────────────────────────────────────────────────────
// AUFGABE 12.2 – Eingabe prüfen mit regulären Ausdrücken
// ─────────────────────────────────────────────────────────────────
//
// Ein regulärer Ausdruck ist ein Suchmuster für Text.
// Schreibweise: /muster/  oder  new RegExp("muster")
//
// .test(text) prüft: Enthält der Text dieses Muster?
// Gibt true oder false zurück.
//
// Wichtige Muster:
//   \S       = ein Zeichen das KEIN Leerzeichen ist
//   [^>]+    = ein oder mehr Zeichen die KEIN > sind
//   <[^>]+>  = ein HTML-Tag wie <b> oder <script>

function eingabePruefen(text) {

  // Prüfung 1: Ist der Text leer oder fehlt er ganz?
  // !text ist true, wenn text undefined, null oder "" ist
  // !text.trim() ist true, wenn der Text nur aus Leerzeichen besteht
  if (!text || !text.trim()) {
    throw new EingabeFehler("Bitte gib etwas ein. Das Feld darf nicht leer sein.");
  }

  // Prüfung 2: Ist der Text zu lang?
  // .length gibt die Anzahl der Zeichen zurück
  if (text.length > 100) {
    throw new EingabeFehler(
      "Der Text ist zu lang. Maximal 100 Zeichen erlaubt. " +
      "Du hast " + text.length + " Zeichen eingegeben."
    );
  }

  // Prüfung 3: Enthält der Text HTML-Tags?
  // Das Muster /<[^>]+>/ sucht nach Zeichenfolgen wie <b>, <script> usw.
  // .test() gibt true zurück, wenn das Muster gefunden wurde
  const htmlTagMuster = /<[^>]+>/;
  if (htmlTagMuster.test(text)) {
    throw new EingabeFehler(
      "HTML-Tags sind nicht erlaubt. " +
      "Zeichen wie < und > dürfen nicht verwendet werden."
    );
  }

  // Prüfung 4: Hat der Text mindestens ein echtes Zeichen?
  // \S steht für "kein Leerzeichen" – also buchstaben, zahlen, sonderzeichen
  const echteZeichenMuster = /\S/;
  if (!echteZeichenMuster.test(text)) {
    throw new EingabeFehler("Der Text enthält keine echten Zeichen, nur Leerzeichen.");
  }

  // Alle Prüfungen bestanden!
  return true;

} // ← Ende eingabePruefen()


// ─────────────────────────────────────────────────────────────────
// AUFGABE 12.3 – Todos durchsuchen
// ─────────────────────────────────────────────────────────────────
//
// Wir durchsuchen alle gespeicherten Todos nach einem Suchbegriff.
// Dabei soll Groß- und Kleinschreibung keine Rolle spielen
// ("MILCH" und "milch" sollen dasselbe finden).
//
// new RegExp(suchbegriff, "i") erstellt das Muster zur Laufzeit.
// Das "i" am Ende bedeutet: Groß-/Kleinschreibung ignorieren.

function todsosDurchsuchen(suchbegriff) {

  // Zuerst prüfen wir, ob das Suchmuster überhaupt gültig ist.
  // Manche Zeichen haben in RegExp eine Sonderbedeutung (z.B. "[" oder "(").
  // Ein ungültiges Muster wirft einen Fehler – den fangen wir ab.
  let suchmuster;

  try {
    // Wir versuchen, das Muster zu erstellen
    suchmuster = new RegExp(suchbegriff, "i");
  } catch (regexFehler) {
    // Das Muster ist ungültig (z.B. ein nicht geschlossenes "[")
    // Wir werfen unseren eigenen EingabeFehler
    throw new EingabeFehler(
      "Das Suchmuster ist ungültig: \"" + suchbegriff + "\". " +
      "Bitte vermeide Sonderzeichen wie [ ] ( ) \\ ^ $ *"
    );
  }

  // Todos aus dem localStorage laden
  // Wenn nichts gespeichert ist, nehmen wir ein leeres Array
  const alleInhalt = localStorage.getItem("todos");
  const alleTodos  = alleInhalt ? JSON.parse(alleInhalt) : [];

  // Wir filtern: nur Todos behalten, bei denen der Aufgabentext
  // zum Suchmuster passt. .test() gibt true oder false zurück.
  const gefundene = alleTodos.filter(function(todo) {
    return suchmuster.test(todo.aufgabe);
  });

  return gefundene;

} // ← Ende todosDurchsuchen()


// ─────────────────────────────────────────────────────────────────
// HILFSFUNKTION – Todo sicher speichern
// ─────────────────────────────────────────────────────────────────
//
// Diese Funktion zeigt, wie wir SpeicherFehler einsetzen würden.
// In echten Projekten kann localStorage voll sein – dann schlägt
// setItem() mit einem Fehler fehl.

function todoSpeichern(neuesAufgabe) {

  try {
    // Zuerst die Eingabe prüfen
    eingabePruefen(neuesAufgabe);

    // Bestehende Todos laden
    const vorhandene = JSON.parse(localStorage.getItem("todos") || "[]");

    // Neues Todo-Objekt erstellen und anhängen
    vorhandene.push({
      id:       Date.now(),        // aktuelle Zeit als eindeutige ID
      aufgabe:  neuesAufgabe,
      erledigt: false,
    });

    // Versuchen zu speichern
    try {
      localStorage.setItem("todos", JSON.stringify(vorhandene));
      console.log("Gespeichert:", neuesAufgabe);
    } catch (speicherProblem) {
      // localStorage kann voll sein (z.B. im privaten Modus)
      throw new SpeicherFehler(
        "Speichern fehlgeschlagen. Möglicherweise ist der Speicher voll."
      );
    }

  } catch (fehler) {

    // Wir reagieren unterschiedlich je nachdem, was für ein Fehler es ist
    if (fehler instanceof EingabeFehler) {
      console.error("Eingabe ungültig →", fehler.message);
      console.log("Zeitpunkt:", fehler.zeitpunkt);
    } else if (fehler instanceof SpeicherFehler) {
      console.error("Speicher-Problem →", fehler.message);
      console.log("Zeitpunkt:", fehler.zeitpunkt);
    } else {
      // Unbekannter Fehler – weitergeben
      throw fehler;
    }
  }

} // ← Ende todoSpeichern()


// ─────────────────────────────────────────────────────────────────
// TESTS – Alles ausprobieren
// ─────────────────────────────────────────────────────────────────

// Testdaten anlegen
localStorage.setItem("todos", JSON.stringify([
  { id: 1, aufgabe: "Milch kaufen",        erledigt: false },
  { id: 2, aufgabe: "E-Mails beantworten", erledigt: true  },
  { id: 3, aufgabe: "Sport machen",        erledigt: false },
  { id: 4, aufgabe: "Buch lesen",          erledigt: true  },
]));


console.log("=== Test: Eingabe prüfen ===");

// Gültige Eingabe
console.log(eingabePruefen("Einkaufen gehen")); // true

// Fehler: leer
try {
  eingabePruefen("");
} catch (fehler) {
  console.log(fehler instanceof EingabeFehler); // true
  console.log(fehler.name);                     // EingabeFehler
  console.log(fehler.message);                  // Bitte gib etwas ein...
  console.log(fehler.zeitpunkt);                // z.B. 16.4.2025, 10:30:00
}

// Fehler: HTML-Tag
try {
  eingabePruefen("<b>fetter Text</b>");
} catch (fehler) {
  console.log(fehler.message); // HTML-Tags sind nicht erlaubt...
}

// Fehler: zu lang (101 Zeichen)

try {
  eingabePruefen("a".repeat(101));
} catch (fehler) {
  console.log(fehler.message); // Der Text ist zu lang...
}

// Fehler: nur Leerzeichen
try {
  eingabePruefen("     ");
} catch (fehler) {
  console.log(fehler.message); // Der Text enthält keine echten Zeichen...
}


console.log("=== Test: Suche ===");

// Groß-/Kleinschreibung spielt keine Rolle
console.log(todsosDurchsuchen("milch").map(t => t.aufgabe));  // ["Milch kaufen"]
console.log(todsosDurchsuchen("SPORT").map(t => t.aufgabe));  // ["Sport machen"]

// Teilsuche – "en" findet alles mit "en"
console.log(todsosDurchsuchen("en").map(t => t.aufgabe));
// ["Milch kaufen", "E-Mails beantworten", "Buch lesen"]

// Ungültiges Suchmuster
try {
  todsosDurchsuchen("[nicht geschlossen");
} catch (fehler) {
  console.log(fehler.name);    // EingabeFehler
  console.log(fehler.message); // Das Suchmuster ist ungültig...
}


console.log("=== Test: Todo speichern ===");

todoSpeichern("Neues Todo");         // Gespeichert: Neues Todo
todoSpeichern("");                   // Eingabe ungültig → Bitte gib etwas ein...
todoSpeichern("<script>hack</script>"); // Eingabe ungültig → HTML-Tags sind nicht erlaubt...


console.log("=== Test: instanceof – Fehlertyp unterscheiden ===");

// instanceof prüft, ob ein Fehler zu einem bestimmten Typ gehört
try {
  eingabePruefen("");
} catch (fehler) {
  console.log(fehler instanceof EingabeFehler); // true  – ist ein EingabeFehler
  console.log(fehler instanceof SpeicherFehler); // false – ist kein SpeicherFehler
  console.log(fehler instanceof Error);          // true  – ist ein Error (Vererbung!)
}
