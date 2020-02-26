using dotnet_g033.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Data.Mappers
{
    public class AfbeeldingConfig : IEntityTypeConfiguration<Afbeelding>
    {
        public void Configure(EntityTypeBuilder<Afbeelding> builder)
        {
            builder.Property(l => l.Naam).HasMaxLength(50).IsRequired();
            builder.Property(l => l.Adress).HasMaxLength(100).IsRequired();
            builder.Property(l => l.TijdToegevoegd);
        }
    }
}
