# dotnet-g033
Een webinterface voor het organiseren van en inschijven in sessies van het HoGent IT-Lab.

## How to use:
### Inloggen
Bij het gebruiken van de website zal u zich op een gegeven moment moeten inloggen. Er zijn enkele accounts reeds geconfigureerd die u hiervoor kan gebruiken:
| gebruikersnaam| wachtwoord |type gebruiker|
|----------|-----------|-----------------|
| pc123456 | koekjes   |normale gebruiker|
| sb123456 | appeltjes |normale gebruiker|
| rn123456 | peertjes  |normale gebruiker|
| as123456 | snoepjes  |normale gebruiker|
| sbv123456 | appeltjes |verantwoordelijke|
| hdw123456 | adminpass |hoofdverantwoordelijke|

### Sessies
Er zijn reeds enkele sessies geconfigureerd om een overzicht te geven wat er allemaal mogelijk is. Hieronder vindt u een overzicht met alle sessies en de opties per sessie.

| Sessie                        | optie |
|-------------------------------|-------|
| The Three Laws of TDD| Is al verlopen maar is nog niet gesloten, bevat alle mediatypes |
| How Netflix thinks of DevOps  | Is bezig maar staat niet open |
| Power use of Unix             | Zal direct beginnen, staat ook niet open |
| Life is terrible: let's talk about the web | Bevat media en een aankondiging |
| De weg naar de Cloud | Afgelopen, bevat feedback |
| Improving Security Is Possible? | Afgelopen, bevat feedback |

Om een sessie open te zetten dient men zich in te loggen als hoofdverantwoordelijke en de status van de gewenste sessie op 'open' te zetten.
### What to do
#### Dit kan een gewone gebruiker zien en doen :
- Homepagina
  - Eerst volgende sessie
  - Algemene en sessie specifieke aankondiging
  - Wist je dit
  - Huidige openingsuren
- Geplande Sessies
  - Een overzicht van alle toekomstige sessies van een bepaalde maand
  - Je kan zoeken titel en verantwoordelijke naam
  - Je kan een detail van een sessie bekijken en je ook inschrijven
- Afgelopen Sessies
  - Idem van "Geplande Sessies" maar
    - Je kan je niet inschrijven
    - Je kan feedback indienen als je aanwezig was bij de sessie
- Detail Sessie
  - Alle info in verband met de sessie
  - Alle media
#### Dit kan een verantwoordelijke extra doen vergeleken met hierboven : 
- Mijn Sessies
  - Een overzicht van alle sessies van die verantwoordelijke 
  - Je kan de sessies openzetten 
  - Je kan naar de details gaan
    - Hier kan je de gebruikers inschrijven via een barcode
    - Wij gebruikte de "Barcode to PC" gsm-app en "Barcode to PC server" computerapp om deze te testen
#### Dit kan een hoofdverantwoordelijke extra doen vergeleken met hierboven:
- Mijn Sessies
  - Hij kan het zelfde doen maar je ziet alle sessies
    
 
