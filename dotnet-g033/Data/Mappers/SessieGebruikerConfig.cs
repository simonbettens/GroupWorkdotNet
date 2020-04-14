using dotnet_g033.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Data.Mappers {
    public class SessieGebruikerConfig : IEntityTypeConfiguration<SessieGebruiker> {
        public void Configure(EntityTypeBuilder<SessieGebruiker> builder) {
            builder.HasKey(t => new { t.SessieId, t.GebruikerId });
            builder.Property(t => t.IdNumber).HasColumnType("bigint");
            /*
            builder.HasOne(s => s.Sessie)
                .WithMany(s=>s.GebruikersIngeschreven)
                .HasForeignKey(pt => pt.SessieId)
                .OnDelete(DeleteBehavior.Cascade);
            */
            /*
            builder.HasOne(pt => pt.Gebruiker)
             .WithMany(g=>g.SessiesIngeschreven)
             .HasForeignKey(pt => pt.GebruikerId)
             .OnDelete(DeleteBehavior.Cascade);
             */
        }
    }
}
