using Domain;
using EfDataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace EfDataAccess
{
    public class MyDbContext : DbContext
    {
        public DbSet<Marka> Marke { get; set; }
        public DbSet<ModelAutomobila> Modeli { get; set; }
        public DbSet<Kategorija> Kategorije { get; set; }
        public DbSet<Tip> Tipovi { get; set; }
        public DbSet<Gorivo> VrsteGoriva { get; set; }
        public DbSet<Automobil> Automobili { get; set; }
        public DbSet<Slike> Slike { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Prijave> Prijave { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=desktop-8otflm7\sqlexpress;Initial Catalog=automobili;Integrated Security=True;Pooling=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new KonfiguracijaAutomobila());
            modelBuilder.ApplyConfiguration(new KonfiguracijaGoriva());
            modelBuilder.ApplyConfiguration(new KonfiguracijaKategorije());
            modelBuilder.ApplyConfiguration(new KonfiguracijaKorisnika());
            modelBuilder.ApplyConfiguration(new KonfiguracijaMarke());
            modelBuilder.ApplyConfiguration(new KonfiguracijaModela());
            modelBuilder.ApplyConfiguration(new KonfiguracijaPrijava());
            modelBuilder.ApplyConfiguration(new KonfiguracijaSlika());
            modelBuilder.ApplyConfiguration(new KonfiguracijaTipa());
        }
    }
}
