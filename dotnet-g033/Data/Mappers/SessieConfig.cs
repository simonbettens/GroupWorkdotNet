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
            builder.HasKey(s => s.SessieId);

            builder.Property(s => s.SessieId).IsRequired();
            builder.Property(s => s.Naam).HasMaxLength(50).IsRequired();
            builder.Property(d => d.StartDatum).IsRequired();
            builder.Property(d => d.EindDatum).IsRequired();
            builder.Property(m => m.MaxCap).HasDefaultValue(30).IsRequired();
            builder.Property(m => m.AantalAanwezigeGebruikers).HasDefaultValue(0);
            builder.Property(l => l.Lokaal).IsRequired();
            //builder.HasOne(s => s.Media).WithOne().IsRequired().HasForeignKey<Media>(m => m.SessieId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(s => s.Media).WithOne().IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.Property(b => b.Beschrijving).HasMaxLength(1000).IsRequired(false);
            builder.HasOne(s => s.Verantwoordelijke).WithMany(v=>v.BeheerdeSessies).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
