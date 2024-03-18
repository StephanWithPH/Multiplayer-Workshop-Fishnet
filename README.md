# HAN Multiplayer research 2024
Niels van Ammelrooij, 
Stephan, 
Maarten, 
Aron Maijen, 
Bram van Xanten

# Inleiding
In deze workshop gaan we jullie verschillende aspecten van multiplayer in unity leren. Dit zullen we doen in vier onderdelen. Deze zullen hieronder uitgelegd worden.


( nummer ) = hoeveelheid minuten per onderdeel?

## (10) Onderdeel 1: Server uitleg + Verbinding maken

### Algemeen
Hier zullen we een presentatie delen en zul je zelf de verbinding maken met de server

### server uitleg
Zie [presentatie.md](./Presentatie/presentatie.md)


### Opdracht:
1. Controleer je IP (bijvoorbeeld door [hier](https://www.ipchicken.com) te klikken)
2. Probeer zelf te verbinden met [OPENVPN](https://openvpn.net/client/client-connect-vpn-for-windows/) aan de hand van het [bestand](./VPN/vpn-UDP4-1194-config_buro.ovpn) dat te vinden is in de folder VPN met de volgende credentials:
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
