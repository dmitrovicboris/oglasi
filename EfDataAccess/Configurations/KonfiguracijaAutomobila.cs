using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class KonfiguracijaAutomobila : IEntityTypeConfiguration<Automobil>
    {
        public void Configure(EntityTypeBuilder<Automobil> builder)
        {
            builder.Property(a => a.Naziv)
                  .HasColumnType("text");
            builder.Property(a => a.Opis)
                  .HasColumnType("text");
            builder.Property(x => x.Vlasnik).HasDefaultValue(false);
            builder.HasMany(a => a.Prijave)
                   .WithOne(a => a.Automobil)
                   .HasForeignKey(a => a.AutomobilId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
