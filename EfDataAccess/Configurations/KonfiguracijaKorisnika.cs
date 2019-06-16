using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class KonfiguracijaKorisnika : IEntityTypeConfiguration<Korisnik>
    {
        public void Configure(EntityTypeBuilder<Korisnik> builder)
        {
            builder.Property(u => u.Ime)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(u => u.Prezime)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.DateCreated).HasDefaultValueSql("GETDATE()");
            builder.HasMany(a => a.Automobils)
                   .WithOne(u => u.Korisnik)
                   .HasForeignKey(a => a.KorisnikId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.Prijave)
                   .WithOne(u => u.Korisnik)
                   .HasForeignKey(p => p.KorisnikId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
