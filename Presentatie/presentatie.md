# Server instellen

## Algemene beschrijving:
In dit onderdeel zal beschreven worden hoe wij de server hebben opgezet.

## Hoe werkt de server:
Onze build van de server wordt hier uitgelegd aan de hand van de scenes. Vervolgens worden de componenten per scene uitgelegd.

**DetectScene**

Hier begint het spel en bepaalt unity of je een server of een client bent. Vervolgens stuurt unity je dan door naar de _ServerScene_ als je een server bent. Als je een client bent stuurt unity je door naar de ClientConnectScene. 

**ClientConnectScene**

Dit is een "lege" scene met daarin een knop om proberen connectie te maken met de server. Klik je op deze knop en werkt de connectie dan kom je in de Client Scene.


**ClientScene**

Dit is de scene waar spelers elkaar kunnen zien.

**ServerScene**

Dit is de scene waar de server in draait. Hier haalt hij de settings op hoe hij moet runnen.

## Welke stappen hebben wij ondernomen:

Ervanuitgaande dat je unity project helemaal correct is ingesteld met de juiste scenes en componenten is het vrij gemakkelijk om het op een server te zetten. Je moet van unity een build maken voor een dedicated server en deze op de server zetten via een file transfer protocol(FTP), vervolgens moet je de build starten door de executable te starten.

Hieronder zal er per stap uitgelegd worden hoe wij het precies hebben gedaan.

**Unity scenes met de juiste componenten*


**Build maken**

Voordat je een build kunt maken voor een dedicated server moet je een paar modules importeren op je editor. Namelijk:

- Linux build support(IL2CPP)
- Linux Build support(Mono)
- Linux Dedicated Server Build Support

Dit doe je door naar je unity hub te gaan en te klikken op installs. Hier kun je je geïnstalleerde unity versies zien. Hier zoek je de juiste unity verzie en je klikt vervolgens op de 3 puntjes en selecteerd add modules. Hier zoek je vervolgens deze drie modules en deze installeer je.

Als je deze modules eenmaal hebt geïnstallerd en ingesteld dan kun je in het project naar File en dan naar build settings. Hier kun je vervolgens het een en ander selecteren en tot slot kun je hier op build klikken en een bestandslocatie kiezen.

**FTP**

Wij moesten natuurlijk de build overzetten naar de server. Wij hebben hiervoor fileZilla gebruikt. Hier kun je simpelweg de bestemmingscredentials invullen en dan zie je in de fileZilla omgeving de folderstructuur van de server en die van jezelf. Vervolgens kun je dan gemakkelijk bestanden overzetten.

Wij liepen echter tegen 1 probleem aan. Wij mochten als gebruiker geen bestanden op de root zetten. Wij hebben dit opgelost door een Root user in te stellen en deze toestemming te geven tot een ftp inlog.

**Starten excecutable**

Je kunt de excecutable op de server starten door eerst te SSH'en naar de server. Dit kan via je eigen terminal door het volgende commando:
```
ssh -l gamedesign 10.160.0.125
```
Dan vraagt het systeem om een wachtwoord en dan kun je commandos runnen op de server.

Je kunt het volgende commando runnen om de executable te starten:
```
./file-name.run
```
Krijg je hier een "permission denied" dan moet je eerst aan linux laten weten dat het bestand een excecutable is door het volgende commando:
```
chmod +x file-name.run
```