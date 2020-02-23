using dotnet_g033.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_g033.Data
{
    internal class LinkConfig : IEntityTypeConfiguration<Link>
    {
        public void Configure(EntityTypeBuilder<Link> builder)
        {
            builder.ToTable("Link");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Naam).HasMaxLength(50).IsRequired();
            builder.Property(l => l.Adress).HasMaxLength(100).IsRequired();
            builder.Property(l => l.TijdToegevoegd);
        }
    }
}