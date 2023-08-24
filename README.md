# Route71

## Semplicemente Fotografare Live 2023

Ancora una volta ho voluto partecipare con una mostra fotografica personale al [Semplicemente Fotografare Live](https://strawberryfield.altervista.org/fq/semplicementefotografarelive.php) 2023.

![Copertina](https://strawberryfield.altervista.org/route71/foto/cover.jpg)

Le fotografie presentate raccontano un breve viaggio da Badia Prataglia, nei boschi del Casentino, fino alle porte di Ravenna lungo la ex statale 71, oggi in gran parte sostituita dalla superstrada Ravenna-Orte.

Come accade per la ben più celebre route 66 statunitense (che il titolo vorrebbe richiamare) il vecchio percorso, più lento, permette di scoprire tante cose che viaggiando veloci (dove possibile, date le disastrate condizioni di quella superstrada), o nei tunnel non si possono vedere.

Una nuova sezione del sito [raccoglie fotografie e storie attorno alla statale 71](https://strawberryfield.altervista.org/route71/index.php) e [le foto della mostra]((https://strawberryfield.altervista.org/route71/mostra-semplicemente-fotografare-live-2023.php), ed un piccolo [backstage](https://strawberryfield.altervista.org/route71/allestimento-mostra-roberto-ceccarelli-semplicemente-fotografare.php).

Le opere saranno esposte all'interno del «Semplicemente Fotografare Live 2023» alla [Rocca di Dozza dal 27 al 29 ottobre 2023](https://fb.me/e/11Gb8MlzO)

## Il software

Lo scorso anno pensavo di realizzare delle «Cartes de Visite» fotografiche, e per realizzarle modificai anche la [suite di tool](https://github.com/strawberryfield/Contemporary_CDV) che avevo messo a punto per facilitarne la realizzazione.

![Carte de visite Route71](https://strawberryfield.altervista.org/route71/foto/route71-carte-de-visite.jpg)

Si trattava di estrarre dai dati EXIF le coordinate geografiche; sono solito registrare la traccia GPS delle mie esplorazioni fotografiche e con questa si possono inserire i dati di localizzazione in ogni file.
I risultati sono molto precisi, occorre solo accertarsi che telefono e fotocamera abbiano gli orologi ben sincronizzati.

Alcuni problemi nella gestione della stampante mi hanno fatto cambiare strada; al [Semplicemente Fotografare Live 2022](https://strawberryfield.altervista.org/bicingiro/index.php) ho portato si delle cartes de visite, ma di un'altra serie.

![Carte de visite bicingiro](https://strawberryfield.altervista.org/bicingiro/foto/allestimento.jpg)

Nonostante il problema della stampante sia stato nel frattempo risolto, non potevo presentare qualcosa di uguale.

Ho pensato anche che poi avrei dovuto gestire le stampe fisiche una volta smontata la mostra; ricordo che alla [mia prima esperienza al Live](https://strawberryfield.altervista.org/fq/index.php), accanto alle mie foto ce ne erano quattro, ciascuna con un lato di almeno un metro e l'autore le guardava e diceva: "poi dove le metto? le ammonticchierò in cantina.".

Che fine ingloriosa!  
E' così che ho pensato di realizzare delle "pagine" che alla fine diventassero un album.

Ho riciclato molto dall'esperienza delle cartes de visite, ad esempio i ganci per appenderle realizzati con filo da cucito nascosto tra la stampa ed il cartoncino di supporto.

Nella preparazione delle stampe ho voluto inserire delle didascalie con il nome della località e le coordinate GPS; le stampe erano più grandi della cartes de visite ed il programma che avevo non andava bene.

![Esempio risultato](https://strawberryfield.altervista.org/route71/foto/esempio_pannello.jpg)

Avevo già scorporato le librerie di base che gestiscono le immagini ed inserite in un [pacchetto NuGet](https://www.nuget.org/packages/Casasoft.CCDV.Common), oltre ad aver creato un [template per nuovi progetti]([Nuova pagina](https://www.nuget.org/packages/Casasoft.CCDV.ProjectTemplate)) che utilizzassero la libreria.

Realizzare lo strumento per creare le pagine della «fanzine» è stata anche una ottima occasione per migliorare la libreria.
