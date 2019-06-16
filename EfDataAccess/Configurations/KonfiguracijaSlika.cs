using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class KonfiguracijaSlika : IEntityTypeConfiguration<Slike>
    {
        public void Configure(EntityTypeBuilder<Slike> builder)
        {
            builder.Property(p => p.Putanja)
                  .HasColumnType("text");
        }
    }
}
