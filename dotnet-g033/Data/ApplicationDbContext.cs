using System;
using System.Collections.Generic;
using System.Text;
using dotnet_g033.Data.Mappers;
using dotnet_g033.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotnet_g033.Data {
    public class ApplicationDbContext : IdentityDbContext {
        public DbSet<Sessie> Sessie { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Link> Link { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<Afbeelding> Afbeelding { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Media> Media { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=.;Database=ItLabTest;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SessieConfig());
            builder.ApplyConfiguration(new MediaConfig());
            builder.ApplyConfiguration(new VideoConfig());
            builder.ApplyConfiguration(new AfbeeldingConfig());
            builder.ApplyConfiguration(new DocumentConfig());
            builder.ApplyConfiguration(new LinkConfig());
            base.OnModelCreating(builder);
            
        }
    }
}
