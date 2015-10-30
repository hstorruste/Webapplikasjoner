Skobutikken - tekniske spesifikasjoner

Denne "readme"- filen inneholder kunn informasjon om tekniske informasjon knyttet til Oblig 1. For informasjon om tekniske valg og l�sninger ang�ende oblig 2 se i Readme.txt.

EksempelData
Siden vi i f�rste mappe ikke skal lage en administrasjonsl�sning for kunder, produkter, kategorier og ordre, s� har vi lagd en klasse som skal legge inn data om produktene i databasen for oss.
"public class Eksempeldata : DropCreateDatabaseIfModelChanges<NettbutikkContext>{
	       protected override void Seed(NettbutikkContext context)"

Denne klassen sletter, gjenoppretter og fyller databasen med dataene fra seed-metoden. Databasen blir initialisert i Application_Start(). Vi har lagt inn en del varer men ingen brukere og ordre i eksempeldataene.
Alle data og bilder av skoene er hentet fra "Skoringen.no".

Sessions og Cookies
Vi fors�ker � bruke session-id som en unik id for Kundevognen. P� denne m�ten kan man vite hvilke rader i Kundevogn-tabellen p� databasen som tilh�rer hvilken innlogget kunde. (HttpSessionStateBase.SessionId)
Vi velger � ikke generere en ny sessionId for hver gang man logger inn. Dette er ikke en sikkerhetskritisk side, s� det er heller nyttig � kunne finne igjen det man har i handlevogna n�r man g�r tilbake til siden. Om man logger inn med en annen enhet, vil den f� en ny sessionId uansett.

Dynamiske nav
Ettersom man legger inn "For hvem" og kategorier i databasen vil nav-et p� toppen utvide seg. Dette gj�res ved bruk av partial views og � itterere over dataene.
