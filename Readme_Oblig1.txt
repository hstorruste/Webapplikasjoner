Skobutikken - tekniske spesifikasjoner

Denne "readme"- filen inneholder kunn informasjon om tekniske informasjon knyttet til Oblig 1. For informasjon om tekniske valg og løsninger angående oblig 2 se i Readme.txt.

EksempelData
Siden vi i første mappe ikke skal lage en administrasjonsløsning for kunder, produkter, kategorier og ordre, så har vi lagd en klasse som skal legge inn data om produktene i databasen for oss.
"public class Eksempeldata : DropCreateDatabaseIfModelChanges<NettbutikkContext>{
	       protected override void Seed(NettbutikkContext context)"

Denne klassen sletter, gjenoppretter og fyller databasen med dataene fra seed-metoden. Databasen blir initialisert i Application_Start(). Vi har lagt inn en del varer men ingen brukere og ordre i eksempeldataene.
Alle data og bilder av skoene er hentet fra "Skoringen.no".

Sessions og Cookies
Vi forsøker å bruke session-id som en unik id for Kundevognen. På denne måten kan man vite hvilke rader i Kundevogn-tabellen på databasen som tilhører hvilken innlogget kunde. (HttpSessionStateBase.SessionId)
Vi velger å ikke generere en ny sessionId for hver gang man logger inn. Dette er ikke en sikkerhetskritisk side, så det er heller nyttig å kunne finne igjen det man har i handlevogna når man går tilbake til siden. Om man logger inn med en annen enhet, vil den få en ny sessionId uansett.

Dynamiske nav
Ettersom man legger inn "For hvem" og kategorier i databasen vil nav-et på toppen utvide seg. Dette gjøres ved bruk av partial views og å itterere over dataene.
