# Lern Periode 11

14.8 bis 11.9.2024

## Grob-Planung

1. Erklären Sie Ihre Projekt-Idee in einem Satz, als müssen Sie einen Investor davon überzeugen.
   Ich entwickle eine einfache Water-Tracker-App mit Avalonia, mit der man seine tägliche Trinkmenge erfassen und den Fortschritt zum Tagesziel verfolgen kann.
   
2. Erklären Sie, welche technischen Herausforderungen Sie in Ihrem Projekt erwarten.
   Eine technische Herausforderung wird die lokale Speicherung der Daten sein. Die App soll die getrunkene Wassermenge, das Tagesziel und die einzelnen Einträge auch nach dem Schliessen der App behalten. Ausserdem muss ich die            Benutzeroberfläche mit Avalonia und XAML erstellen und die Logik korrekt mit C# verbinden.
   
3. Beschreiben Sie, welche nicht-technischen Aspekte Sie in diesem Projekt besonders üben möchten.
   Ich möchte vor allem meine Planung und mein selbstständiges Arbeiten verbessern. Ich will die einzelnen Funktionen sinnvoll auf Arbeitspakete verteilen und darauf achten, dass ich zuerst die wichtigsten Funktionen fertigstelle,        bevor ich zusätzliche Features einbaue.
   
4. Wie unterscheidet sich dieses Projekt von Ihrem Projekt in 335; und wo ergänzen sich diese Projekte?
   Im Modul 335 liegt der Fokus stärker auf der Entwicklung einer mobilen Applikation und auf der Benutzeroberfläche. Bei diesem Projekt möchte ich mich zusätzlich stärker mit C#, Avalonia und der lokalen Speicherung beschäftigen. Die    Projekte ergänzen sich, weil ich Wissen über mobile Benutzeroberflächen aus Modul 335 direkt für meine Water-Tracker-App verwenden kann.

## 14.8

- [x] Als Benutzer möchte ich meine getrunkene Wassermenge mit einem Button hinzufügen können, damit ich sehe, wie viel ich heute bereits getrunken habe.
- [x] Grundlegende Benutzeroberfläche mit Avalonia und XAML erstellen. Dazu gehören Titel, aktuelle Trinkmenge, Tagesziel und Buttons für verschiedene Wassermengen.
- [x] Lokale Speicherung vorbereiten und eine Datenstruktur für Trinkmenge, Tagesziel, Datum und einzelne Einträge erstellen.

Heute habe ich die Grundstruktur meiner Water-Tracker-App mit Avalonia und C# erstellt. Ich habe eine Benutzeroberfläche mit Titel, aktueller Trinkmenge, Tagesziel und Buttons für 250 ml und 500 ml gebaut. Die Buttons funktionieren bereits und erhöhen die Wassermenge. Zusätzlich habe ich eine Datenklasse für Wassermenge, Tagesziel und Datum erstellt und mit JSON die lokale Speicherung vorbereitet. Dabei habe ich auch mehr über MVVM, ObservableProperty, RelayCommand, Konstruktoren und Namespaces gelernt.

## 21.8
- [x] Als Benutzer möchte ich, dass meine Trinkmenge lokal gespeichert und beim erneuten Starten der App geladen wird, damit mein Fortschritt nicht verloren geht.
- [x] Einen Reset für einen neuen Tag umsetzen, damit die Trinkmenge zurück auf 0 ml gesetzt wird, wenn sich das Datum ändert.
- [x] Eine Fortschrittsanzeige erstellen, die zeigt, wie viel Prozent des Tagesziels bereits erreicht wurden. 


Heute habe ich meine Water-Tracker-App weiterentwickelt. Ich habe die Speicherung fertig gemacht, damit die Trinkmenge auch nach einem Neustart erhalten bleibt. Ausserdem habe ich den täglichen Reset getestet und dafür mit AddDays ein anderes Datum simuliert, um zu prüfen, ob die Wassermenge an einem neuen Tag wieder auf 0 ml gesetzt wird. Danach habe ich eine Fortschrittsanzeige erstellt, die zeigt, wie viel Prozent vom Tagesziel erreicht wurden. Dabei habe ich auch besser verstanden, wie Binding und Properties in Avalonia funktionieren.

## 28.8

- [ ] Als Benutzer möchte ich meinen Wasserstand in einem Kreis sehen, damit ich meinen aktuellen Fortschritt visuell erkennen kann.
- [ ] Als Benutzer möchte ich eine animierte Wasserwelle sehen, die sich mit meiner Trinkmenge verändert, damit die Fortschrittsanzeige lebendiger dargestellt wird.
- [ ] Als Benutzer möchte ich eine übersichtliche und ansprechende Benutzeroberfläche mit passenden Farben, Buttons und einer klaren Anzeige meiner Trinkmenge haben, damit die App einfach und angenehm zu bedienen ist.
