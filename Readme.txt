TEKNISKE SPESIFIKASJONER - Admin for Nettbutikk

Forord
Pga av mangel p� tid og en meget omfattende oppgave er ikke alle funskjoner implementert. Mye fungerer godt, men et par ting fungerer ikke. Det f�lgende: 
- Laste opp bilder til ny sko.
- Redigere sko.
- Legge til ny pris p� sko.
- Det meste er enhetstestet, men det kan v�re enkelt mangler.

Versjonsh�ndtering og deployment
Det finnes en kj�rende versjon p�: http://dotnet.cs.hioa.no/s165519/
Vi har brugt Git til versjonsh�ndtering og deployet med Visual Studio. 

Strukturering
Hele l�sningen inneholder koden fra oblig 1 og oblig 2. For � kunne gjenbruke mest mulig kode fra oblig 1 har vi valgt � lagdele denne ogs�. Vi f�lte vi fikk bedre oversikt ved � gj�re det slik. For � holde orden p� koden p� en ryddig m�te, har vi valgt � holde koden fra oblig 1 og 2 adskilt p� f�lgende m�te:

I MVC prosjektet er admin-delen (oblig 2) lagt i et eget Area - Admin. Admin (MVC-delen) ligger i namespace "Nettbutikk.Areas.Admin", mens Nettbutikk (Oblig 1) ligger fremdeles i namespace "Nettbutikk". Begge har selvf�lgelig ogs� egne namespaces for .Controller, .View og .Models.

I prosjektene BLL, DAL og Model er koden for oblig 1 og 2 lagt i f�lgende mapper: Nettbutikk og Admin. De er ogs� delt inn egne namespaces, eksempelvis: BLL.Nettbutikk og BLL.Admin.

I enhetstest-prosjektet ligger kunn test for koden i admin-delen (oblig 2).

Ved � dele dem inn i mapper og ulike namespace h�per vi det vil bli oversiktelig og det gj�r det ogs� lettere � se om vi har testet det vi kan i administrasjons-delen.


Logging
Det viktigste vi tenker � ta vare p� er prishistorikk. Vi har derfor valgt � ta vare p� alle prisendringer p� varene i databasen. P� denne m�ten kan man se tilbake i tid p� hva som har v�rt prisen p� produktet. Varene (skoene) slettes aldri helt fra databasen, men blir isteden satt til slettet. P� denne m�ten kan man hente frem varer man tidligere har hatt.

Logging av feilsituasjoner til fil foreg�r i Db-klassene. Vi har valgt � skrive til fil i catch-blokken f�r metodene returnerer. Det opprettes en ny fil for hver feil i mappen "Nettbutikk/Errors/".