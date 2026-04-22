// ═══════════════════════════════════════════════════════════════════
// LÖSUNG 11 – Promises & async/await
// ═══════════════════════════════════════════════════════════════════
//
// GRUNDIDEE:
// JavaScript kann immer nur eine Sache gleichzeitig tun.
// Wenn wir auf etwas warten (z.B. Daten vom Server holen), würde der
// Browser einfrieren – das wollen wir nicht.
//
// Die Lösung: Wir sagen „mach das im Hintergrund und sag mir Bescheid,
// wenn es fertig ist". Genau das macht ein Promise.
//
// ═══════════════════════════════════════════════════════════════════


// ─────────────────────────────────────────────────────────────────
// AUFGABE 11.1 – Eine Funktion, die ein Promise zurückgibt
// ─────────────────────────────────────────────────────────────────
//
// Wir bauen eine Funktion, die so tut als würde sie Daten von einem
// Server holen. In echten Projekten würde man hier fetch() benutzen.
// Wir simulieren die Wartezeit mit setTimeout (= „warte X Millisekunden").
//
// Ein Promise hat zwei mögliche Ausgänge:
//   fertig(ergebnis)  → alles gut, hier ist das Ergebnis
//   fehler(meldung)   → etwas ging schief, hier ist der Fehler

function datenvomServerHolen(adresse) {

  // new Promise(...) erstellt das Versprechen.
  // Die Funktion darin bekommt zwei Werkzeuge:
  //   - fertig:  rufen wir auf, wenn alles geklappt hat
  //   - fehler:  rufen wir auf, wenn etwas schiefgelaufen ist
  return new Promise(function(fertig, fehler) {

    // setTimeout wartet 500 Millisekunden, bevor es weitergeht.
    // Das simuliert die Wartezeit eines echten Netzwerkaufrufs.
    setTimeout(function() {

      // Wir prüfen, welche Adresse angefragt wurde
      if (adresse === "/todos") {

        // Alles gut! Wir geben eine Liste von Todos zurück.
        // fertig() löst das Promise erfolgreich auf.
        fertig([
          { id: 1, aufgabe: "Milch kaufen",  erledigt: false },
          { id: 2, aufgabe: "Sport machen",  erledigt: true  },
          { id: 3, aufgabe: "Buch lesen",    erledigt: false },
        ]);

      } else {

        // Unbekannte Adresse – wir melden einen Fehler.
        // new Error(...) erstellt eine Fehlermeldung.
        // fehler() bricht das Promise mit diesem Fehler ab.
        fehler(new Error("Diese Adresse gibt es nicht: " + adresse));
      }

    }, 500); // ← 500 = warte 500 Millisekunden (= 0,5 Sekunden)

  }); // ← Ende new Promise(...)

} // ← Ende datenvomServerHolen()


// ─────────────────────────────────────────────────────────────────
// AUFGABE 11.2 – async/await: Auf das Promise warten
// ─────────────────────────────────────────────────────────────────
//
// Mit async/await können wir so schreiben, als würde der Code
// von oben nach unten laufen – obwohl er im Hintergrund wartet.
//
// Das Schlüsselwort "async" vor "function" bedeutet:
//   "Diese Funktion darf mit await arbeiten."
//
// Das Schlüsselwort "await" bedeutet:
//   "Warte hier, bis das Promise fertig ist, dann mach weiter."

async function todosLadenVomServer() {

  // try/catch fängt Fehler ab – genau wie bei normalem Code.
  // Alles in "try" wird versucht.
  // Wenn etwas schiefgeht, springt der Code in "catch".
  try {

    // await wartet, bis datenvomServerHolen() fertig ist.
    // Erst dann läuft der Code in der nächsten Zeile weiter.
    // Die Variable "todoListe" bekommt das Ergebnis (das Array).
    const todoListe = await datenvomServerHolen("/todos");

    // Jetzt haben wir die Daten – wir speichern sie im localStorage
    localStorage.setItem("todos", JSON.stringify(todoListe));

    // Wir geben eine Rückmeldung in der Konsole
    console.log("Erfolgreich geladen! Anzahl Todos:", todoListe.length);

    // Wir zeigen die Aufgaben-Texte mit map() an
    const aufgabenTexte = todoListe.map(function(todo) {
      return todo.aufgabe;
    });
    console.log("Aufgaben:", aufgabenTexte);

  } catch (aufgetretenerFehler) {

    // Dieser Block läuft nur, wenn etwas schiefgegangen ist.
    // aufgetretenerFehler.message enthält die Fehlerbeschreibung.
    console.error("Fehler beim Laden:", aufgetretenerFehler.message);

  }

} // ← Ende todosLadenVomServer()


// ─────────────────────────────────────────────────────────────────
// AUFGABE 11.3 – Promise.all: Mehrere Anfragen gleichzeitig starten
// ─────────────────────────────────────────────────────────────────
//
// Manchmal müssen wir mehrere Dinge gleichzeitig laden.
// Statt nacheinander zu warten, starten wir alles auf einmal.
//
// Promise.all([...]) bekommt eine Liste von Promises.
// Es wartet, bis ALLE fertig sind, und gibt dann alle Ergebnisse.
//
// ACHTUNG: Wenn auch nur EINES fehlschlägt, schlägt alles fehl.
// Für diesen Fall gibt es Promise.allSettled (weiter unten).

async function allesGleichzeitigLaden() {

  console.log("--- Promise.all: alle oder keiner ---");

  try {

    // Wir starten zwei Anfragen gleichzeitig.
    // Promise.all wartet, bis BEIDE fertig sind.
    // Destrukturierung: die Ergebnisse werden direkt in Variablen aufgeteilt
    const [todoErgebnis, kategorieErgebnis] = await Promise.all([
      datenvomServerHolen("/todos"),       // Anfrage 1 – wird klappen
      datenvomServerHolen("/kategorien"),  // Anfrage 2 – wird FEHLSCHLAGEN
    ]);

    // Diese Zeilen werden nie erreicht, weil Anfrage 2 fehlschlägt
    console.log("Todos:", todoErgebnis.length);
    console.log("Kategorien:", kategorieErgebnis);

  } catch (aufgetretenerFehler) {

    // Da /kategorien unbekannt ist, landen wir hier
    console.error("Promise.all gescheitert:", aufgetretenerFehler.message);
    // Ausgabe: "Diese Adresse gibt es nicht: /kategorien"

  }

  // ── Promise.allSettled: alle Ergebnisse, auch wenn etwas fehlschlägt ──
  //
  // allSettled() bricht NICHT ab, wenn etwas fehlschlägt.
  // Es liefert für jedes Promise ein Ergebnisobjekt mit:
  //   { status: "fulfilled", value: ... }   ← hat geklappt
  //   { status: "rejected",  reason: ... }  ← ist fehlgeschlagen

  console.log("--- Promise.allSettled: Ergebnisse trotz Fehler ---");

  const alleErgebnisse = await Promise.allSettled([
    datenvomServerHolen("/todos"),      // klappt
    datenvomServerHolen("/unbekannt"),  // schlägt fehl
  ]);

  // Wir gehen jedes Ergebnis durch
  alleErgebnisse.forEach(function(ergebnis, position) {

    const nummer = position + 1; // Zählung ab 1, nicht ab 0

    if (ergebnis.status === "fulfilled") {
      // "fulfilled" bedeutet: hat geklappt
      console.log(
        "Anfrage " + nummer + " erfolgreich:",
        ergebnis.value.length + " Einträge"
      );
    } else {
      // "rejected" bedeutet: ist fehlgeschlagen
      console.log(
        "Anfrage " + nummer + " fehlgeschlagen:",
        ergebnis.reason.message
      );
    }

  });

} // ← Ende allesGleichzeitigLaden()


// ─────────────────────────────────────────────────────────────────
// AUSFÜHREN
// ─────────────────────────────────────────────────────────────────
//
// Beide Funktionen werden aufgerufen.
// Die Ausgaben erscheinen erst nach ~500ms, weil wir auf setTimeout warten.
// Der Rest des Browsers läuft während der Wartezeit normal weiter.

todosLadenVomServer();
allesGleichzeitigLaden();
