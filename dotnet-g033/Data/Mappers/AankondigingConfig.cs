using dotnet_g033.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Data.Mappers
{
    public class AankondigingConfig : IEntityTypeConfiguration<Aankondiging>
    {
        public void Configure(EntityTypeBuilder<Aankondiging> builder)
        {
            builder.HasKey(a => a.AankondingId);
            builder.ToTable("Aankonding");
            builder.Property(a => a.Gepost).IsRequired();
            builder.Property(a => a.Inhoud).IsRequired().HasMaxLength(200);
            builder.Property(a => a.Prioriteit).IsRequired();
            builder.HasOne(a => a.Verantwoordelijke).WithMany().OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
