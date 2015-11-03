using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.Model;

namespace Admin.DAL
{
    public class DbAttributterStub : IDbAttributter
    {
        public ForHvem addFor(string forNavn)
        {
            var ny = new ForHvem()
            {
                forId = 1,
                navn = forNavn
            };

            if(forNavn == "")
            {
                return null;
            }
            else
            {
                return ny;
            }
        }

        public Kategori addKategori(string kategoriNavn)
        {
            var ny = new Kategori()
            {
                kategoriId = 1,
                navn = kategoriNavn
            };

            if (kategoriNavn == "")
            {
                return null;
            }
            else
            {
                return ny;
            }
        }

        public Merke addMerke(string merkeNavn)
        {
            var ny = new Merke()
            {
                merkeId = 1,
                navn = merkeNavn
            };

            if (merkeNavn == "")
            {
                return null;
            }
            else
            {
                return ny;
            }
        }

        public ForHvem deleteFor(int id)
        {
            var ny = new ForHvem()
            {
                forId = 1,
                navn = "Herre"
            };

            if (id != ny.forId)
            {
                return null;
            }
            else
            {
                return ny;
            }
        }

        public Kategori deleteKategori(int id)
        {
            var ny = new Kategori()
            {
                kategoriId = 1,
                navn = "Sko"
            };

            if (id != ny.kategoriId)
            {
                return null;
            }
            else
            {
                return ny;
            }
        }

        public Merke deleteMerke(int id)
        {
            var ny = new Merke()
            {
                merkeId = 1,
                navn = "Adidas"
            };

            if (id != ny.merkeId )
            {
                return null;
            }
            else
            {
                return ny;
            }
        }

        public List<ForHvem> getFor()
        {

            var liste = new List<ForHvem>
            {
                new ForHvem { forId = 1, navn = "Herre", antallSko = 1 },
                new ForHvem { forId = 2, navn = "Dame", antallSko = 2 },
                new ForHvem { forId = 3, navn = "Barn", antallSko = 3 }
            };
            
            return liste;
        }

        public ForHvem getFor(int id)
        {
            throw new NotImplementedException();
        }

        public Kategori getKategori(int id)
        {
            throw new NotImplementedException();
        }

        public List<Kategori> getKategorier()
        {
            var liste = new List<Kategori>
            {
                new Kategori { kategoriId = 1, navn = "Sko", antallSko = 1 },
                new Kategori { kategoriId = 2, navn = "Sneakers", antallSko = 2 },
                new Kategori { kategoriId = 3, navn = "Gummistøvler", antallSko = 3 }
            };

            return liste;
        }

        public List<Merke> getMerke()
        {
            var liste = new List<Merke>
            {
                new Merke { merkeId = 1, navn = "Odiin", antallSko = 1 },
                new Merke { merkeId = 2, navn = "B&CO", antallSko = 2 },
                new Merke { merkeId = 3, navn = "Sanita", antallSko = 3 }
            };

            return liste;
        }

        public Merke getMerke(int id)
        {
            throw new NotImplementedException();
        }

        public List<Skoen> getSkoAvFor(int id)
        {
            throw new NotImplementedException();
        }

        public List<Skoen> getSkoAvKategori(int id)
        {
            throw new NotImplementedException();
        }

        public List<Skoen> getSkoAvMerke(int id)
        {
            throw new NotImplementedException();
        }

        public ForHvem updateFor(ForHvem forhvem)
        {
            if(forhvem.navn == "")
            {
                return null;
            }
            else
            {
                return forhvem;
            }
        }

        public Kategori updateKategori(Kategori kategori)
        {
            if(kategori.navn == "")
            {
                return null;
            }
            else
            {
                return kategori;
            }
        }

        public Merke updateMerke(Merke merke)
        {
            if(merke.navn == "")
            {
                return null;
            }
            else
            {
                return merke;
            }
        }
    }
}
