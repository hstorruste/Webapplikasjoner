TEKNISKE SPESIFIKASJONER - Admin for Nettbutikk

Strukturering
Hele l�sningen inneholder koden fra oblig 1 og oblig 2. For � kunne gjenbruke mest mulig kode fra oblig 1 har vi valgt � lagdele denne ogs�. Vi f�lte vi fikk bedre oversikt ved � gj�re det slik. For � holde orden p� koden p� en ryddig m�te, har vi valgt � holde koden fra oblig 1 og 2 adskilt p� f�lgende m�te:

I MVC prosjektet er admin-delen (oblig 2) lagt i et eget Area - Admin. Admin (MVC-delen) ligger i namespace "Nettbutikk.Areas.Admin", mens Nettbutikk (Oblig 1) ligger fremdeles i namespace "Nettbutikk". Begge har selvf�lgelig ogs� egne namespaces for .Controller, .View og .Models.

I prosjektene BLL, DAL og Model er koden for oblig 1 og 2 lagt i f�lgende mapper: Nettbutikk og Admin. De er ogs� delt inn egne namespaces, eksempelvis: Nettbutikk.BLL og Admin.BLL.

I enhetstest-prosjektet ligger kunn test for koden i admin-delen (oblig 2).

Ved � dele dem inn i mapper og ulike namespace h�per vi det vil bli oversiktelig og det gj�r det ogs� lettere � se om vi har testet det vi kan i administrasjons-delen.