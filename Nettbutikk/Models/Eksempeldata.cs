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
                        Farge = "Sort", Pris = 499.00M,  ForHvem = forHvem.Single( f => f.Navn == "Dame"), Kategori = kategorier.Single( k => k.Navn == "Sko")}
            };
            
            skoene.ForEach(s => context.Sko.Add(s));

            new List<Storlekar>
            {
                new Storlekar { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"),  Storlek = 36  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"),  Storlek = 37  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"),  Storlek = 38  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"),  Storlek = 39  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"),  Storlek = 40  },
                new Storlekar { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"),  Storlek = 41  }

            }.ForEach(s => context.Storlekar.Add(s));

            new List<Bilder>
            {
                new Bilder { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"), BildeUrl = "/Pictures/Sko/2455100311_1.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"), BildeUrl = "/Pictures/Sko/2455100311_2.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"), BildeUrl = "/Pictures/Sko/2455100311_4.jpg" },
                new Bilder { Sko = skoene.Single(s => s.Navn == "B&CO 2455100311"), BildeUrl = "/Pictures/Sko/2455100311_6.jpg" }

            }.ForEach(b => context.Bilder.Add(b));
        }
    }
}