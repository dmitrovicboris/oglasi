using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class KonfiguracijaKategorije : IEntityTypeConfiguration<Kategorija>
    {
        public void Configure(EntityTypeBuilder<Kategorija> builder)
        {
            builder.Property(c => c.Naziv)
                  .IsRequired()
                  .HasMaxLength(30);

            builder.HasIndex(c => c.Naziv).IsUnique();
            builder.Property(c => c.DateCreated).HasDefaultValueSql("GETDATE()");

            builder.HasMany(a => a.Automobils)
                   .WithOne(c => c.Kategorija)
                   .HasForeignKey(a => a.KategorijaId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
