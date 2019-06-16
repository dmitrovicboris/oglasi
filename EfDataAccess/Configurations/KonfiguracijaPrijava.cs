using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class KonfiguracijaPrijava : IEntityTypeConfiguration<Prijave>
    {
        public void Configure(EntityTypeBuilder<Prijave> builder)
        {
            builder.HasKey(p => new { p.AutomobilId, p.KorisnikId });
        }
    }
}
