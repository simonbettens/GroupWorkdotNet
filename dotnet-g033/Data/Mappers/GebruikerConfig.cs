using dotnet_g033.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Data.Mappers
{
    public class GebruikerConfig : IEntityTypeConfiguration<Gebruiker>
    {
        public void Configure(EntityTypeBuilder<Gebruiker> builder)
        {
            builder.Property(g => g.UserName).HasMaxLength(50).IsRequired();
            builder.Property(g => g.Voornaam).IsRequired();
            builder.Property(g => g.Achternaam).IsRequired();
            builder.Property(g => g.Status).IsRequired();
        }
    }
}
