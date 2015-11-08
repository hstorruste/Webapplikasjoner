TEKNISKE SPESIFIKASJONER - Admin for Nettbutikk

Forord
Pga av mangel på tid og en meget omfattende oppgave er ikke alle funskjoner implementert. Mye fungerer godt, men et par ting fungerer ikke. Det følgende: 
- Laste opp bilder til ny sko.
- Redigere sko.
- Legge til ny pris på sko.
- Det meste er enhetstestet, men det kan være enkelt mangler.

Versjonshåndtering og deployment
Det finnes en kjørende versjon på: http://dotnet.cs.hioa.no/s165519/
Vi har brugt Git til versjonshåndtering og deployet med Visual Studio. 

Strukturering
Hele løsningen inneholder koden fra oblig 1 og oblig 2. For å kunne gjenbruke mest mulig kode fra oblig 1 har vi valgt å lagdele denne også. Vi følte vi fikk bedre oversikt ved å gjøre det slik. For å holde orden på koden på en ryddig måte, har vi valgt å holde koden fra oblig 1 og 2 adskilt på følgende måte:

I MVC prosjektet er admin-delen (oblig 2) lagt i et eget Area - Admin. Admin (MVC-delen) ligger i namespace "Nettbutikk.Areas.Admin", mens Nettbutikk (Oblig 1) ligger fremdeles i namespace "Nettbutikk". Begge har selvfølgelig også egne namespaces for .Controller, .View og .Models.

I prosjektene BLL, DAL og Model er koden for oblig 1 og 2 lagt i følgende mapper: Nettbutikk og Admin. De er også delt inn egne namespaces, eksempelvis: BLL.Nettbutikk og BLL.Admin.

I enhetstest-prosjektet ligger kunn test for koden i admin-delen (oblig 2).

Ved å dele dem inn i mapper og ulike namespace håper vi det vil bli oversiktelig og det gjør det også lettere å se om vi har testet det vi kan i administrasjons-delen.


Logging
Det viktigste vi tenker å ta vare på er prishistorikk. Vi har derfor valgt å ta vare på alle prisendringer på varene i databasen. På denne måten kan man se tilbake i tid på hva som har vært prisen på produktet. Varene (skoene) slettes aldri helt fra databasen, men blir isteden satt til slettet. På denne måten kan man hente frem varer man tidligere har hatt.

Logging av feilsituasjoner til fil foregår i Db-klassene. Vi har valgt å skrive til fil i catch-blokken før metodene returnerer. Det opprettes en ny fil for hver feil i mappen "Nettbutikk/Errors/".