using dotnet_g033.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Data.Mappers
{
    public class FeedbackConfig : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedback");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.TijdToegevoegd);
            builder.Property(f => f.Inhoud).HasMaxLength(500).IsRequired(false);
            builder.Property(f => f.AantalSterren).IsRequired(true);
            builder.Property(f => f.GebruikerUserName).IsRequired(true);
        }
    }
}
