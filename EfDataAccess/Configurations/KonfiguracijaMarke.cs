using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class KonfiguracijaMarke : IEntityTypeConfiguration<Marka>
    {
        public void Configure(EntityTypeBuilder<Marka> builder)
        {
            builder.Property(m => m.MarkaAutomobila)
                  .IsRequired()
                  .HasMaxLength(30);

            builder.HasIndex(m => m.MarkaAutomobila).IsUnique();
            builder.Property(m => m.DateCreated).HasDefaultValueSql("GETDATE()");

            builder.HasMany(a => a.Automobils)
                   .WithOne(m => m.Marka)
                   .HasForeignKey(a => a.MarkaId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(mo => mo.Modeli)
                   .WithOne(m => m.Marka)
                   .HasForeignKey(mo => mo.MarkaId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
