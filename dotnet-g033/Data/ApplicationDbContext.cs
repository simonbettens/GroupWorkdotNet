using System;
using System.Collections.Generic;
using System.Text;
using dotnet_g033.Data.Mappers;
using dotnet_g033.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotnet_g033.Data {
    public class ApplicationDbContext : IdentityDbContext {
        public DbSet<Sessie> Sessies { get; set; }

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
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new SessieConfig());
            
        }
    }
}
