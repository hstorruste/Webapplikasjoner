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
            Database.CreateIfNotExists();
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
    }
    
    public class Kunder
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string Postnr { get; set; }
        public string Epost { get; set; }
        public string Passord { get; set; }

        public virtual Poststeder Poststeder { get; set; }
    }

    public class Poststeder
    {
        [Key]
        public string Postnr { get; set; }
        public string Poststed { get; set; }

        public virtual List<Kunder> Kunder { get; set; }
    }

    public class Sko
    {
        [Key]
        public int SkoId { get; set; }
        public string Navn { get; set; }
        public For ForHvem { get; set; }
        public Kategorier Kategori { get; set; }
        public double Pris { get; set; }
        public string Farge { get; set; }
        public string Beskrivelse { get; set; }

        public virtual List<Bilder> Bilder { get; set; }
        public virtual List<Storlekar> Storlekar { get; set; }
    }

    public class For
    {
        [Key]
        public string ForId { get; set; }
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
        public int SkoId { get; set; }
        [Key]
        public String Bilde { get; set; }

        [ForeignKey("VareId")]
        public Sko Varer { get; set; }
    }

    public class Storlekar
    {
        [Key]
        public int SkoId { get; set; }
        [Key]
        public int Storlek { get; set; }

        [ForeignKey("VareId")]
        public Sko Sko { get; set; }

    }

}