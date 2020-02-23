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
            builder.ToTable("Media");
            builder.HasKey(s => s.MediaId);
            builder.HasMany(m => m.Afbeeldingen).WithOne().IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(m => m.Linken).WithOne().IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(m => m.Documenten).WithOne().IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(m => m.Videos).WithOne().IsRequired().OnDelete(DeleteBehavior.Restrict);

        }
    }
}
