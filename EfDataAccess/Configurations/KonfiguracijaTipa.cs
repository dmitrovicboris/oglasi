using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class KonfiguracijaTipa : IEntityTypeConfiguration<Tip>
    {
        public void Configure(EntityTypeBuilder<Tip> builder)
        {
            builder.Property(t => t.Type)
                  .IsRequired()
                  .HasMaxLength(30);

            builder.HasIndex(t => t.Type).IsUnique();
            builder.Property(t => t.DateCreated).HasDefaultValueSql("GETDATE()");

            builder.HasMany(a => a.Automobils)
                   .WithOne(t => t.Tip)
                   .HasForeignKey(a => a.TipId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
