PDF Tester


Installationsprogramm: PdfTester_Setup.exe entpackt die benötigten Daten selbstständig und erstellt eine Programmverknüpfung auf der Desktop.


Funktionen:
Automatisch PDF Betrachtungsprogramme mit PDF Dokument aufrufen, Screenshot anfertigen, Screenshotvergleich, OCR Texterkennung


Speicherort:
Eingaben werden in Konfigurationsdateien unter "C:\Users\USERNAME\AppData\Local\PdfTester\" abgespeichert.


[Start]

PDF Programmliste:
Eingabe der Pfade zu den einzelnen PDF Betrachtungsprogrammen (ein Pfad pro Zeile).
Optional kann durch die Eingabe eines Semikolons + anschließenden String ein Name gewählt werden.
Dieser Name wird als Dateiname zum dazugehörigen Screenshot verwendet.
Wird kein Name angebeben, wird der Dateiname des PDF Betrachungsprogramms verwendet.

PDF Dateien (Pfadangabe):
An dieser Stelle muss der Ordner zu den PDF Dateien angegeben werden.
Die einzelnen Dateien werden als Argument zum Programmstart der Betrachtungsprogramme hinzugefügt.

Ablageort Screenshot (Pfadangabe):
An dieser Stelle muss der Ordner ausgewählt werden, in dem die erstellten Screenshots abgespeichert werden sollen.

PDF Tester starten:
Dieser Button startet die Abarbeitung.
Jedes unter der Pfadangabe gefundete PDF Dokument wird mit jedem PDF Betrachtungsprogramm in der Programmliste aufgerufen.
Anschließend wird ein Screenshot erstellt und dieser unter dem gewählten Ablageort gespeichert.
Der Dateiname des Screenshot setzt sich wie folgt zusammen "PDF-Dateiname + _ + Name in Programmliste + _ + Datum + .png".

Speichern:
Speichert die Programmliste, sowie die Pfadangaben.

Debug öffnen:
Öffnet die Debug-Datei aus der im Fehlerfall weitere Informationen entnommen werden können.


[Vergleich]

Hier können Screenshots mit einander verglichen werden.
Da jeweils Pixel mit Pixel verglichen wird, müssen die zu vergleichenden Screenshots die selbe Pixelbreite aufweisen.

Pfadangabe zu Screenshots:
Hier muss der Pfad zu den unter [Start] erstellten Screenshots eingetragen werden.

Pfadangabe zu Screenshots (valide):
Einmalig müssen unter [Start] Screenshots erstellt werden, die eine valide Signaturüberprüfung aufweisen.
Diese Screenshots dienen als Referenz und sollen mit späteren Screenshots von manipulierten PDF Dokumenten vergleichen werden.

Screenshot Vergleich starten:
Dieser Button startet die Abarbeitung.
Das Programm liest die Dateinamen in den angegebenen Ordnern ein und vergleicht den enthaltenen Namen des PDF Betrachtungsprogramm.
Es wird für den zu überprüfenden Screenshot ein passender validen Screenshot gesucht (Bsp. beide Screenshots wurden mit geöffneten Acrobat Reader DC erstellt, so ist im Dateinamen "AdobeDC" enthalten).
Wird ein passender validen Screenshot gefunden, werden beide Screenshots miteinander verglichen.
Tritt hierbei keine Pixeldifferenz auf, kann daraus abgeleitet werden, dass der Inhalt gleich ist und somit der zu überprüfende Screenshot eine valide Signaturprüfung aufweist.
Die Ergebnisse werden in den beiden Textboxen ausgegeben.


[OCR]

Hier können Screenshots durch eine OCR Texterkennung eingelesen werden und der Inhalt nach expliziten Suchbegriffen durchsucht werden.
Für die Texterkennung wird Tesseract in der Version 4 verwendet.

Pfadangabe zu Screenshots:
Hier muss der Pfad zu den unter [Start] erstellten Screenshots eingetragen werden.

Pfadangabe zum Speichern des erkannten Textes:
Der über die OCR Texterkennung gescannte Inhalt der Screenshots wird für eine spätere Auswertung in der Textdatei geschrieben.

Suchbegriffe:
In diesem Textfeld muss der zu suchende Begriff eingegeben werden. Bsp. "signature is valid".
Das Programm sucht im gescannten Inhalt nach den eingetragenen Suchbegriffen und stellt sie in der entsprechenden Textbox dar.


[Einstellungen]

Wartezeit bevor das PDF Betrachtungsprogramm geschlossen wird:
Je nach Rechenleistung und Betrachtungsprogramms, kann es eine Weile dauern, bis das PDF Betrachtungsprogramm die PDF Datei vollständig geladen hat.
Erst nach Ablauf dieser Wartezeit, wird der Screenshot [Start] angefertigt.
Standardwert: 50 Sekunden

Wartezeit nachdem das PDF Betrachtungsprogramm geschlossen wurde:
Je nach Rechenleistung und Betrachtungsprogramms, kann es einen Moment dauern, bis das PDF Betrachtungsprogramm vollständig durch den PDF Tester geschlossen wurde.
Erst nach Ablauf dieser Wartezeit, das nächste PDF Betrachtungsprogramm aufgerufen.
Standardwert: 2 Sekunden

Differenzgrenze für erfolgreichen Screenshotvergleich:
Beim Screenshotvergleich [Vergleich], kann es zu minimalen Pixelabweichungen kommen, obwohl der zu überprüfende Screenshot eine valide Signaturprüfung aufweist.
Die maximale Abweichung kann an dieser Stelle angepasst werden.
Standardwert: 0,00001

Maximal zu berücksichtigende Bildhöhe:
Der relevante Bildausschnitt beim Screenshotvergleich [Vergleich], welcher eine valide bzw. eine invalide Signaturprüfung aufweist, befindet sich i.d.R. im oberen Bildbereich.
Um den Screenshotvergleich zu beschleuningen, kann der zu berücksichtigende Bildbereich eingeschränkt werden.
Standardwert: 500 Pixel

Sprachauswahl OCR-Texterkennung:
Für die Texterkennung kann das Sprachpaket ausgewählt werden.
Es wird empfohlen die Screenshots in englischer Sprache anzufertigen und das englische Sprachpaket "eng" auszuwählen, da hiermit die besten Ergebnisse erzielt werden konnten.

Pfadangabe zum Tesseract Ordner:
Hier kann der Tesseract Programmordner ausgewählt werden.
Standardmäßig entpackt die Datei PdfTester_Setup.exe die Dateien unter "C:\Users\USERNAME\AppData\Local\PdfTester\tesseract".
Unterhalb des tesseract-Ordners müssen die Sprachpakete im Ordner "tessdata" liegen.


Hinweise:
Die PdfTester.exe ist digital signiert, um Sicherheitsmeldungen durch PDF Betrachtungsprogrammen vorzubeugen.
Das Zertifikat muss dem Rechner als Vertrauenswürdige Stammzertifizierungsstelle hinzugefügt werden.
 

