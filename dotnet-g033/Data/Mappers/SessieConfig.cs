using dotnet_g033.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Data.Mappers
{
    public class SessieConfig : IEntityTypeConfiguration<Sessie>
    {
        public void Configure(EntityTypeBuilder<Sessie> builder)
        {
            builder.ToTable("Sessie");
            builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.Naam).HasMaxLength(100).IsRequired();

            //builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.Naam).HasMaxLength(50).IsRequired();
            builder.Property(d => d.StartDatum).IsRequired();
            builder.Property(d => d.EindDatum).IsRequired();
            builder.Property(m => m.MaxCap).HasDefaultValue(30).IsRequired();
            builder.Property(m => m.AantalAanwezigeGebruikers).HasDefaultValue(1);
        }
    }
}
