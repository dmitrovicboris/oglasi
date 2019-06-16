using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class KonfiguracijaModela : IEntityTypeConfiguration<ModelAutomobila>
    {
        public void Configure(EntityTypeBuilder<ModelAutomobila> builder)
        {
            builder.Property(m => m.Model)
                  .IsRequired()
                  .HasMaxLength(30);

            builder.HasIndex(m => m.Model).IsUnique();
            builder.Property(m => m.DateCreated).HasDefaultValueSql("GETDATE()");

            builder.HasMany(a => a.Automobils)
                   .WithOne(m => m.Model)
                   .HasForeignKey(a => a.ModelId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
