using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Nettbutikk.Models
{
    public class Eksempeldata : DropCreateDatabaseIfModelChanges<NettbutikkContext>
    {
        protected override void Seed(NettbutikkContext context)
        {
            var forHvem = new List<For>
            {
                new For { Navn = "Dame" },
                new For { Navn = "Herre" },
                new For { Navn = "Barn" },
                new For { Navn = "Alle" }
            };

            var kategorier = new List<Kategorier>
            {
                new Kategorier { Navn = "Sko" },
                new Kategorier { Navn = "Sneakers" },
                new Kategorier { Navn = "Gummistøvler" },
                new Kategorier { Navn = "TEX-membran" }
            };

            var skoene = new List<Sko>
            {
                new Sko { Navn = "B&CO 2455100311", Beskrivelse= "Tøff B&CO damesko med lisser. Skoen er i tekstil med små metall nitter. Den har sort kantbånd rundt lisser stykket og langs kanten. Skoen er sort med brune flammer. Den har canvas dekksåle og canvas fôr. Gummisålen er tofarget hvit og sort.",
                        Farge = "Sort", Pris = 499.00M,  ForHvem = forHvem.Single( f => f.Navn == "Dame"), Kategori = kategorier.Single( k => k.Navn == "Sko")},
                new Sko { Navn = "Sanita 538665", Beskrivelse = "" ,
                        Farge = "Grønn", Pris = 249.00M , ForHvem = forHvem.Single( f => f.Navn == "Herre"), Kategori = kategorier.Single( k => k.Navn == "Gummistøvler")},
                new Sko { Navn = "92-98024", Beskrivelse= "",
                        Farge = "Sort", Pris = 399.00M, ForHvem = forHvem.Single( f => f.Navn == "Dame"), Kategori = kategorier.Single( k => k.Navn == "Gummistøvler")},
                new Sko { Navn = "Odiin 1625500150", Beskrivelse = "Tøff snøresko til herre i marineblått nubuckskinn. Skoen har et perforert mønster unntatt på hælkappen, som er i glatt brunt skinn. Den har en brun skinndetalj på pløsen og detaljer på yttersiden. Den har dekksåle og fôr i tekstil. Den hvite gummisålen gjør den tøff og ungdommelig. ",
                        Farge = "Blå", Pris = 999.00M, ForHvem = forHvem.Single( f => f.Navn == "Herre"), Kategori = kategorier.Single( k => k.Navn == "Sko")},
                new Sko { Navn = "ECCO 634504 HAROLD", Beskrivelse = "Flott Ecco snøresko til herre i lekkert konjakkfarget skinn. Skoen har dekksåle i skinn samt meshfôr og skinnfôr i bakkappen. Den har stikninger på sidene. Sålen er i PU. Modellen fås også i sort. ",
                        Farge = "Brun", Pris = 999.00M, ForHvem = forHvem.Single( f => f.Navn == "Herre"), Kategori = kategorier.Single( k => k.Navn == "Sko")}
            };
            
            skoene.ForEach(s => context.Sko.Add(s));

            new List<Storlekar>
            {
                new Storlekar { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"),  Storlek = 36  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"),  Storlek = 37  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"),  Storlek = 38  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"),  Storlek = 39  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"),  Storlek = 40  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"),  Storlek = 41  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "Sanita 538665"),  Storlek = 36  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "Sanita 538665"),  Storlek = 37  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "Sanita 538665"),  Storlek = 38  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "Sanita 538665"),  Storlek = 39  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "Sanita 538665"),  Storlek = 40  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "Sanita 538665"),  Storlek = 41  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "Sanita 538665"),  Storlek = 42  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "Sanita 538665"),  Storlek = 43  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "Sanita 538665"),  Storlek = 44  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "Sanita 538665"),  Storlek = 45  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "Sanita 538665"),  Storlek = 46  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "92-98024"), Storlek = 36 },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "92-98024"), Storlek = 37 },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "92-98024"), Storlek = 38 },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "92-98024"), Storlek = 39 },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "92-98024"), Storlek = 40 },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "92-98024"), Storlek = 41 },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "Odiin 1625500150"), Storlek = 40 },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "Odiin 1625500150"), Storlek = 41 },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "Odiin 1625500150"), Storlek = 42 },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "Odiin 1625500150"), Storlek = 43 },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "Odiin 1625500150"), Storlek = 44 },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "Odiin 1625500150"), Storlek = 45 },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "Odiin 1625500150"), Storlek = 46 },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "ECCO 634504 HAROLD"),  Storlek = 39  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "ECCO 634504 HAROLD"),  Storlek = 40  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "ECCO 634504 HAROLD"),  Storlek = 41  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "ECCO 634504 HAROLD"),  Storlek = 42  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "ECCO 634504 HAROLD"),  Storlek = 43  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "ECCO 634504 HAROLD"),  Storlek = 44  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "ECCO 634504 HAROLD"),  Storlek = 45  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "ECCO 634504 HAROLD"),  Storlek = 46  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "ECCO 634504 HAROLD"),  Storlek = 47  }

            }.ForEach(s => context.Storlekar.Add(s));

            new List<Bilder>
            {
                new Bilder { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"), BildeUrl = "/Pictures/Sko/Medium/2455100311_1.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"), BildeUrl = "/Pictures/Sko/Medium/2455100311_2.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"), BildeUrl = "/Pictures/Sko/Medium/2455100311_4.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"), BildeUrl = "/Pictures/Sko/Medium/2455100311_6.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"), BildeUrl = "/Pictures/Sko/Stor/2455100311_1.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"), BildeUrl = "/Pictures/Sko/Stor/2455100311_2.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"), BildeUrl = "/Pictures/Sko/Stor/2455100311_4.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"), BildeUrl = "/Pictures/Sko/Stor/2455100311_6.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "Sanita 538665"), BildeUrl = "/Pictures/Sko/Medium/8435550140_1.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "Sanita 538665"), BildeUrl = "/Pictures/Sko/Medium/8435550140_2.png" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "Sanita 538665"), BildeUrl = "/Pictures/Sko/Medium/8435550140_4.png" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "Sanita 538665"), BildeUrl = "/Pictures/Sko/Medium/8435550140_6.png" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "Sanita 538665"), BildeUrl = "/Pictures/Sko/Stor/8435550140_1.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "Sanita 538665"), BildeUrl = "/Pictures/Sko/Stor/8435550140_2.png" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "Sanita 538665"), BildeUrl = "/Pictures/Sko/Stor/8435550140_4.png" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "Sanita 538665"), BildeUrl = "/Pictures/Sko/Stor/8435550140_6.png" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "92-98024"), BildeUrl = "/Pictures/Sko/Medium/8425411611_1.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "92-98024"), BildeUrl = "/Pictures/Sko/Medium/8425411611_2.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "92-98024"), BildeUrl = "/Pictures/Sko/Medium/8425411611_4.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "92-98024"), BildeUrl = "/Pictures/Sko/Medium/8425411611_6.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "92-98024"), BildeUrl = "/Pictures/Sko/Stor/8425411611_1.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "92-98024"), BildeUrl = "/Pictures/Sko/Stor/8425411611_2.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "92-98024"), BildeUrl = "/Pictures/Sko/Stor/8425411611_4.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "92-98024"), BildeUrl = "/Pictures/Sko/Stor/8425411611_6.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "Odiin 1625500150"), BildeUrl = "/Pictures/Sko/Medium/1625500150_1.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "Odiin 1625500150"), BildeUrl = "/Pictures/Sko/Medium/1625500150_2.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "Odiin 1625500150"), BildeUrl = "/Pictures/Sko/Medium/1625500150_4.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "Odiin 1625500150"), BildeUrl = "/Pictures/Sko/Medium/1625500150_6.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "Odiin 1625500150"), BildeUrl = "/Pictures/Sko/Stor/1625500150_1.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "Odiin 1625500150"), BildeUrl = "/Pictures/Sko/Stor/1625500150_2.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "Odiin 1625500150"), BildeUrl = "/Pictures/Sko/Stor/1625500150_4.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "Odiin 1625500150"), BildeUrl = "/Pictures/Sko/Stor/1625500150_6.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "ECCO 634504 HAROLD"), BildeUrl = "/Pictures/Sko/Medium/1225520531_1.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "ECCO 634504 HAROLD"), BildeUrl = "/Pictures/Sko/Medium/1225520531_2.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "ECCO 634504 HAROLD"), BildeUrl = "/Pictures/Sko/Medium/1225520531_4.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "ECCO 634504 HAROLD"), BildeUrl = "/Pictures/Sko/Medium/1225520531_6.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "ECCO 634504 HAROLD"), BildeUrl = "/Pictures/Sko/Stor/1225520531_1.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "ECCO 634504 HAROLD"), BildeUrl = "/Pictures/Sko/Stor/1225520531_2.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "ECCO 634504 HAROLD"), BildeUrl = "/Pictures/Sko/Stor/1225520531_4.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "ECCO 634504 HAROLD"), BildeUrl = "/Pictures/Sko/Stor/1225520531_6.jpg" }


            }.ForEach(b => context.Bilder.Add(b));
        }
    }
}