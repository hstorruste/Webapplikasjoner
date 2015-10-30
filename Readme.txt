TEKNISKE SPESIFIKASJONER - Admin for Nettbutikk

Strukturering
Hele løsningen inneholder koden fra oblig 1 og oblig 2. For å kunne gjenbruke mest mulig kode fra oblig 1 har vi valgt å lagdele denne også. Vi følte vi fikk bedre oversikt ved å gjøre det slik. For å holde orden på koden på en ryddig måte, har vi valgt å holde koden fra oblig 1 og 2 adskilt på følgende måte:

I MVC prosjektet er admin-delen (oblig 2) lagt i et eget Area - Admin. Admin (MVC-delen) ligger i namespace "Nettbutikk.Areas.Admin", mens Nettbutikk (Oblig 1) ligger fremdeles i namespace "Nettbutikk". Begge har selvfølgelig også egne namespaces for .Controller, .View og .Models.

I prosjektene BLL, DAL og Model er koden for oblig 1 og 2 lagt i følgende mapper: Nettbutikk og Admin. De er også delt inn egne namespaces, eksempelvis: Nettbutikk.BLL og Admin.BLL.

I enhetstest-prosjektet ligger kunn test for koden i admin-delen (oblig 2).

Ved å dele dem inn i mapper og ulike namespace håper vi det vil bli oversiktelig og det gjør det også lettere å se om vi har testet det vi kan i administrasjons-delen.