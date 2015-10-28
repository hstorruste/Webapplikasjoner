using System;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel;

namespace Nettbutikk.DAL
{
    public class NettbutikkContext : DbContext
    {
        
        public NettbutikkContext()
            : base("name=Nettbutikk")
        {
        }

        public DbSet<Kunder> Kunder { get; set; }
        public DbSet<Poststeder> Poststeder { get; set; }
        public DbSet<Passorden> Passorden { get; set; }
        public DbSet<Sko> Sko { get; set; }
        public DbSet<Priser> Priser { get; set; }
        public DbSet<For> For { get; set; }
        public DbSet<Kategorier> Kategorier { get; set; }
        public DbSet<Merker> Merker { get; set; }
        public DbSet<Bilder> Bilder { get; set; }
        public DbSet<Storlekar> Storlekar { get; set; }
        public DbSet<Ordrer> Ordrer { get; set; }
        public DbSet<OrdreDetaljer> OrdreDetaljer { get; set; }
        public DbSet<Kundevogner> Kundevogner { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }

    public class Kunder
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string Postnr { get; set; }
        public string Epost { get; set; }
        [ForeignKey("Passorden")]
        public int PassordId { get; set; }

        public virtual Poststeder Poststeder { get; set; }
        public virtual Passorden Passorden { get; set; }
    }

    public class Poststeder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Postnr { get; set; }
        public string Poststed { get; set; }

        public virtual List<Kunder> Kunder { get; set; }
    }

    public class Passorden
    {
        [Key, ForeignKey("Kunde")]
        public int PassordId { get; set; }
        public byte[] Passord { get; set; }
        public Kunder Kunde { get; set; }
    }

    public class Sko
    {
        [Key]
        public int SkoId { get; set; }
        public string Navn { get; set; }
        public int ForId { get; set; }
        public int KategoriId { get; set; }
        public string Farge { get; set; }
        public string Beskrivelse { get; set; }
        [DefaultValue(false)]
        public bool Slettet { get; set; }

        public virtual List<Priser> Pris { get; set; }
        public virtual For ForHvem { get; set; }
        public virtual Kategorier Kategori { get; set; }
        public virtual Merker Merke { get; set; }
        public virtual List<Bilder> Bilder { get; set; }
        public virtual List<Storlekar> Storlekar { get; set; }
    }

    public class Priser
    {
        [Key]
        [Column(Order = 0)]
        public int PrisId { get; set; }
        [Key]
        [Column(Order = 1)]
        public DateTime Dato { get; set; }
        public decimal Pris { get; set; }

        public virtual Sko Sko { get; set; }
    }

    public class For
    {
        [Key]
        public int ForId { get; set; }
        public string Navn { get; set; }

        public virtual List<Sko> Sko { get; set; }
    }

    public class Kategorier
    {
        [Key]
        public int KategoriId { get; set; }
        public string Navn { get; set; }

        public virtual List<Sko> Sko { get; set; }
    }

    public class Merker
    {
        [Key]
        public int MerkerId { get; set; }
        public string Navn { get; set; }

        public virtual List<Sko> Sko { get; set; }
    }

    public class Bilder
    {
        [Key]
        public int BildeId { get; set; }
        public string BildeUrl { get; set; }
        public Sko Sko { get; set; }
    }

    public class Storlekar
    {
        [Key]
        public int StorlekId { get; set; }
        public int Storlek { get; set; }
        public Sko Sko { get; set; }
        public int Antall { get; set; }
    }
    
    public class Ordrer
    {
        [Key]
        public int OrdreId { get; set; }
        public DateTime OrdreDato { get; set; }
        public int KundeId { get; set; }
        public decimal TotalBelop { get; set; }

        public virtual List<OrdreDetaljer> OrdreDetaljer { get; set; }
        public virtual Kunder Kunder { get; set; }

    }
    
    public class OrdreDetaljer
    {
        [Key]
        public int OrdreDetaljerId { get; set; }
        public int OrdreId { get; set; }
        public int SkoId { get; set; }
        public int Antall { get; set; }
        public decimal Pris { get; set; }
        public int Storlek { get; set; }
        
        public virtual Sko Sko { get; set; }
        public virtual Ordrer Ordre { get; set; }

    }

    public class Kundevogner
    {
        [Key]
        public int KundevognId {get; set;}
        public string SessionId { get; set; } 
        public int SkoId { get; set; }
        public int Storlek { get; set; }
        //Antal
        public DateTime Dato { get; set; }
        
        public virtual Sko Sko { get; set; }
    }
}