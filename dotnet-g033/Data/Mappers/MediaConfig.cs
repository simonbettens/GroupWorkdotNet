using dotnet_g033.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Data.Mappers
{
    public class MediaConfig : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.HasDiscriminator<string>("TypeMedia")
                .HasValue<Video>("Video")
                .HasValue<Document>("Document")
                .HasValue<Link>("Link")
                .HasValue<Afbeelding>("Afbeelding");
            builder.ToTable("Media");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Naam).HasMaxLength(50).IsRequired();
            builder.Property(l => l.Adress).HasMaxLength(100).IsRequired();
            builder.Property(l => l.TijdToegevoegd);
        }
    }
}
