# PDF Tester


## Installationsprogramm
PdfTester_Setup_32-Bit.exe / PdfTester_Setup_64-Bit.exe entpackt die benötigten Daten selbstständig und erstellt eine Programmverknüpfung auf dem Desktop.


## Funktionen
Automatisch PDF Betrachtungsprogramme mit PDF Dokument aufrufen<br/>
Screenshot anfertigen<br/>
Screenshotvergleich<br/>
OCR Texterkennung<br/>


## Speicherort
Eingaben werden in Konfigurationsdateien unter "C:\Users\USERNAME\AppData\Local\PdfTester\" abgespeichert.


## [Start]

PDF Programmliste:<br/>
Eingabe der Pfade zu den einzelnen PDF Betrachtungsprogrammen (ein Pfad pro Zeile).
Optional kann durch die Eingabe eines Semikolons + anschließenden String ein Name gewählt werden.
Dieser Name wird als Dateiname zum dazugehörigen Screenshot verwendet.
Wird kein Name angebeben, wird der Dateiname des PDF Betrachungsprogramms verwendet.
Zusätzlich zum Namen, kann durch die Eingabe eines weiteren Semikolons + anschließenden ganzzahligen Wert ein Wartezeit eingetragen werden.
Da PDF Betrachtungsprogramme unterschiedliche Zeitspannen benötigen, um den Inhalt eines PDF Dokuments anzuzeigen, kann hier eine Wartezeit individuell für jedes PDF Betrachtungsprogramm eingetragen werden.
Erst nach dieser Wartezeit wird ein Screenshot angefertigt und das Programm geschlossen.
Wird keine Wartezeit angegeben, so wird die Wartezeit unter [Einstellungen] verwendet.
<br/>
PDF Dateien (Pfadangabe):<br/>
An dieser Stelle muss der Ordner zu den PDF Dateien angegeben werden (Unterordner werden berücksichtigt).
Die einzelnen Dateien werden als Argument zum Programmstart der Betrachtungsprogramme hinzugefügt.
<br/>
Ablageort Screenshot (Pfadangabe):<br/>
An dieser Stelle muss der Ordner ausgewählt werden, in dem die erstellten Screenshots abgespeichert werden sollen.
Für jedes PDF Betrachtungsprogramm wird ein Unterordner erstellt.
<br/>
PDF Tester starten:<br/>
Dieser Button startet die Abarbeitung.
Jedes unter der Pfadangabe gefundene PDF Dokument, wird mit jedem PDF Betrachtungsprogramm in der Programmliste aufgerufen.
Anschließend wird ein Screenshot erstellt und dieser unter dem gewählten Ablageort gespeichert.
Der Dateiname des Screenshot setzt sich wie folgt zusammen "PDF-Dateiname + _ + Name in Programmliste + _ + Datum + .png".
<br/>
Speichern:<br/>
Speichert die Programmliste, sowie die Pfadangaben.
<br/>
Debug öffnen:<br/>
Öffnet die Debug-Datei aus der im Fehlerfall weitere Informationen entnommen werden können.


## [Vergleich]

Hier können Screenshots mit einander verglichen werden.
Da jeweils Pixel mit Pixel verglichen wird, müssen die zu vergleichenden Screenshots die selbe Pixelbreite aufweisen.
<br/>
Pfadangabe zu Screenshots:<br/>
Hier muss der Pfad zu den unter [Start] erstellten Screenshots eingetragen werden (Unterordner werden berücksichtigt).
<br/>
Pfadangabe zu Screenshots (valide):<br/>
Einmalig müssen unter [Start] Screenshots erstellt werden, die eine valide Signaturüberprüfung aufweisen.
Diese Screenshots dienen als Referenz und sollen mit späteren Screenshots von manipulierten PDF Dokumenten vergleichen werden.
Bei der Pfadangabe werden Unterordner berücksichtigt.
<br/>
Screenshot Vergleich starten:<br/>
Dieser Button startet die Abarbeitung.
Das Programm liest die Dateinamen in den angegebenen Ordnern ein und vergleicht den enthaltenen Namen des PDF Betrachtungsprogramm.
Es wird für den zu überprüfenden Screenshot ein passender validen Screenshot gesucht (Bsp. beide Screenshots wurden mit geöffneten Acrobat Reader DC erstellt, so ist im Dateinamen "AdobeDC" enthalten).
Wird ein passender validen Screenshot gefunden, werden beide Screenshots miteinander verglichen.
Tritt hierbei keine Pixeldifferenz auf, kann daraus abgeleitet werden, dass der Inhalt gleich ist und somit der zu überprüfende Screenshot eine valide Signaturprüfung aufweist.
Die Ergebnisse werden in den beiden Textboxen ausgegeben.


## [OCR]

Hier können Screenshots durch eine OCR Texterkennung eingelesen werden und der Inhalt nach expliziten Suchbegriffen durchsucht werden.
Für die Texterkennung wird Tesseract in der Version 4 verwendet.
<br/>
Pfadangabe zu Screenshots:<br/>
Hier muss der Pfad zu den unter [Start] erstellten Screenshots eingetragen werden (Unterordner werden berücksichtigt).
<br/>
Pfadangabe zum Speichern des erkannten Textes:<br/>
Der über die OCR Texterkennung gescannte Inhalt der Screenshots wird für eine spätere Auswertung in der Textdatei geschrieben.
<br/>
Suchbegriffe:<br/>
In diesem Textfeld muss der zu suchende Begriff eingegeben werden. Bsp. "signature is valid".
Das Programm sucht im gescannten Inhalt nach den eingetragenen Suchbegriffen und stellt sie in der entsprechenden Textbox dar.
<br/>
Führe OCR Texterkennung zusätzlich mit hochskaliertem Screenshot durch:<br/>
Es kann vorkommen, dass die Screenshot Qualtität nicht ausreicht, um ein optimales Ergebnis bei der Texterkennung zu erzielen.
Durch einen zweiten Durchlauf mit einem hochskalierten Screenshot, kann die Texterkennung verbessert werden.
Die Option verlängert die Verarbeitung pro Bild um ca. den Faktor 2,5.


## [Einstellungen]

Wartezeit bevor das PDF Betrachtungsprogramm geschlossen wird:<br/>
Je nach Rechenleistung und Betrachtungsprogramms, kann es eine Weile dauern, bis das PDF Betrachtungsprogramm die PDF Datei vollständig geladen hat.
Erst nach Ablauf dieser Wartezeit, wird der Screenshot [Start] angefertigt.
Standardwert: 50 Sekunden
<br/>
Wartezeit nachdem das PDF Betrachtungsprogramm geschlossen wurde:<br/>
Je nach Rechenleistung und Betrachtungsprogramms, kann es einen Moment dauern, bis das PDF Betrachtungsprogramm vollständig durch den PDF Tester geschlossen wurde.
Erst nach Ablauf dieser Wartezeit, das nächste PDF Betrachtungsprogramm aufgerufen.
Standardwert: 2 Sekunden
<br/>
Differenzgrenze für erfolgreichen Screenshotvergleich:<br/>
Beim Screenshotvergleich [Vergleich], kann es zu minimalen Pixelabweichungen kommen, obwohl der zu überprüfende Screenshot eine valide Signaturprüfung aufweist.
Die maximale Abweichung kann an dieser Stelle angepasst werden.
Standardwert: 0,00001 %
<br/>
Maximal zu berücksichtigende Bildhöhe:<br/>
Der relevante Bildausschnitt beim Screenshotvergleich [Vergleich], welcher eine valide bzw. eine invalide Signaturprüfung aufweist, befindet sich i.d.R. im oberen Bildbereich.
Um den Screenshotvergleich zu beschleuningen, kann der zu berücksichtigende Bildbereich eingeschränkt werden.
Standardwert: 500 Pixel
<br/>
Sprachauswahl OCR-Texterkennung:<br/>
Für die Texterkennung kann das Sprachpaket ausgewählt werden.
Es wird empfohlen die Screenshots in englischer Sprache anzufertigen und das englische Sprachpaket "eng" auszuwählen, da hiermit die besten Ergebnisse erzielt werden konnten.
<br/>
Pfadangabe zum Tesseract Ordner:<br/>
Hier kann der Tesseract Programmordner ausgewählt werden.
Standardmäßig entpackt die Datei PdfTester_Setup_32-Bit.exe / PdfTester_Setup_64-Bit.exe die Dateien unter "C:\Users\USERNAME\AppData\Local\PdfTester\tesseract".
Unterhalb des tesseract-Ordners müssen die Sprachpakete im Ordner "tessdata" liegen.
 

## Hinweise
Die PdfTester.exe ist digital signiert, um Sicherheitsmeldungen durch PDF Betrachtungsprogrammen vorzubeugen.
Das Zertifikat muss dem Rechner als Vertrauenswürdige Stammzertifizierungsstelle hinzugefügt werden.
Die Datei "PdfTester_Setup_64-Bit.exe" enthält das Tesseract Programm in der 64 Bit Variante und liefert auf 64 Bit Systemen eine etwas schnellere Verarbeitung.
Im Ordner tesseract/tessdata liegen die Dateien "eng.traineddata" und "deu.traineddata". Diese stammen aus den Sprachpaketen "tessdata-best".
Um die Verarbeitung zu beschleunigen, können die Sprachpakete aus tesseract/tessdata/FastLanguage in tesseract/tessdata verschoben werden.
Allerdings kann dies zu einer Verschlechterung der Texterkennung führen.
 
## Links
 
Tesseract Programmdaten:<br/>
https://github.com/UB-Mannheim/tesseract/wiki
<br/>
Tesseract Sprachpakete ("tessdata-best" liefern zuverlässigere Ergebnisse):<br/>
https://github.com/tesseract-ocr

