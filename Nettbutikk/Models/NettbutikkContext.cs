namespace Nettbutikk.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public class NettbutikkContext : DbContext
    {
        
        public NettbutikkContext()
            : base("name=Nettbutikk")
        {
        }

        public DbSet<Kunder> Kunder { get; set; }
        public DbSet<Poststeder> Poststeder { get; set; }
        public DbSet<Sko> Sko { get; set; }
        public DbSet<For> For { get; set; }
        public DbSet<Kategorier> Kategorier { get; set; }
        public DbSet<Bilder> Bilder { get; set; }
        public DbSet<Storlekar> Storlekar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        //public System.Data.Entity.DbSet<Nettbutikk.Models.RedigerKundeModell> RedigerKundeModells { get; set; } //Tror ikke denne modellen skal være med her( DbSet setter hva som skal være med i databasen ), vi har jo allerede Kunder
    }

    public class Kunder
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public int Postnr { get; set; }
        public string Epost { get; set; }
        public string Passord { get; set; }

        public virtual Poststeder Poststeder { get; set; }
    }

    public class Poststeder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Postnr { get; set; }
        public string Poststed { get; set; }

        public virtual List<Kunder> Kunder { get; set; }
    }

    public class Sko
    {
        [Key]
        public int SkoId { get; set; }
        public string Navn { get; set; }
        public int ForId { get; set; }
        public int KategoriId { get; set; }
        public decimal Pris { get; set; }
        public string Farge { get; set; }
        public string Beskrivelse { get; set; }

        public virtual For ForHvem { get; set; }
        public virtual Kategorier Kategori { get; set; }
        public virtual List<Bilder> Bilder { get; set; }
        public virtual List<Storlekar> Storlekar { get; set; }
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
    }

}