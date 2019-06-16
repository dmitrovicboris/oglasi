using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class KonfiguracijaGoriva : IEntityTypeConfiguration<Gorivo>
    {
        public void Configure(EntityTypeBuilder<Gorivo> builder)
        {
            builder.Property(g => g.Naziv)
                  .IsRequired()
                  .HasMaxLength(30);

            builder.HasIndex(g => g.Naziv).IsUnique();
            builder.Property(g => g.DateCreated).HasDefaultValueSql("GETDATE()");

            builder.HasMany(a => a.Automobils)
                   .WithOne(g => g.Gorivo)
                   .HasForeignKey(a => a.GorivoId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
