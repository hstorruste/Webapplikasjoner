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
        public DbSet<Varer> Varer { get; set; }
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
        public string epost { get; set; }
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

    public class Varer
    {
        [Key]
        public int VareId { get; set; }
        public string Navn { get; set; }
        public string Kategori { get; set; }
        public double Pris { get; set; }
        public string Farge { get; set; }
        public string Beskrivelse { get; set; }
        public string Bilde { get; set; }
        

        public virtual List<Storlekar> Storlekar { get; set; }
    }


    public class Storlekar
    {
        [Key]
        public int VareId { get; set; }
        [Key]
        public int Storlek { get; set; }

        [ForeignKey("VareId")]
        public Varer Varer { get; set; }
    }

}