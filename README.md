# HAN Multiplayer research 2024
Niels van Ammelrooij
Stephan
Maarten
Aron Maijen
Bram van Xanten

# Inleiding
In deze workshop gaan we jullie verschillende aspecten van multiplayer in unity leren. Dit zullen we doen in vier onderdelen. Deze zullen hieronder uitgelegd worden.


( nummer ) = hoeveelheid minuten per onderdeel?

## (10) Onderdeel 1: Server uitleg + Verbinding maken

### Algemene beschrijving:
In dit onderdeel zal beschreven worden hoe wij de server hebben opgezet en wat jullie zelf moeten doen om een verbinding te maken.

### Hoe werkt de server:

#### Welke stappen hebben wij ondernomen

Ervanuitgaande dat je unity project helemaal correct is ingesteld met de juiste scenes en componenten is het vrij gemakkelijk om het op een server te zetten. Je moet van unity een build maken voor een dedicated server en deze op de server zetten via een file transfer protocol(FTP), vervolgens moet je de build starten door de executable te starten.

Hieronder zal er per stap uitgelegd worden hoe wij het precies hebben gedaan.

**Unity scenes met de juiste componenten**



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


### Opdracht:
1. Controleer je IP (bijvoorbeeld door [hier](https://www.ipchicken.com) te klikken)
2. Probeer zelf te verbinden met [OPENVPN](https://openvpn.net/client/client-connect-vpn-for-windows/) aan de hand van het bestand dat te vinden is in de folder VPN met de volgende credentials:
```
User: gameguest

Password: mTezxQXPWqc38$
```
3. Controleer of je IP is veranderd.


## (30) Onderdeel  2: Download branch + eigen multiplayer opstarten.

### Algemene beschrijving:
Wij hebben voor jullie een branch klaargezet waarin alles is klaar gezet voor de meest simpele versie van multiplayer binnen unity en fishnet. We hebben echter een paar belangrijke dingen niet ingesteld. Dit mogen jullie zelf gaan instellen.

### Opdracht:
1. Checkout de "_stap1branch_" branch
2. Zoek naar de netwerkcomponenten en bekijk hoe je deze moet instellen.
3. Maak de player prefab een netwerkobject(vergeet het script niet).
4. Start de game en kijk of je de klasgenoten kunt pesten!





## (30) Opdracht 3: Cheaten!
Alle studenten mogen vanaf nu proberen om vals te spelen in het multiplayer spel. Dit kan gedaan worden door de code voor het schieten of bewegen te veranderen.


## (10) Opdracht 4: Cheating v2 + Server authoritative uitleg
Alle studenten mogen nogmaals proberen hun ‘cheats’ uit te voeren, maar er is een nieuwe build actief die ervoor hoort te zorgen dat alle ofwel de meeste cheats niet meer werken. hierin hebben studenten maar kort de tijd om te testen wat er nu wel en niet werkt omdat wij een uitleg gaan geven over hoe de server ervoor kan zorgen dat spelers zich aan de regels houden.

# common issues
- prefab niet op server prefab niet activeerbaar
