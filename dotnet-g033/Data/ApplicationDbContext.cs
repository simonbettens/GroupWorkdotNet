﻿using System;
using System.Collections.Generic;
using System.Text;
using dotnet_g033.Data.Mappers;
using dotnet_g033.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotnet_g033.Data {
    public class ApplicationDbContext : IdentityDbContext<Gebruiker, IdentityRole<Guid>, Guid> {

        #region DbSets
        public DbSet<Sessie> Sessie { get; set; }
        public DbSet<Gebruiker> Gebruiker { get; set; }
        public DbSet<Link> Link { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<Afbeelding> Afbeelding { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<SessieGebruiker> SessieGebruiker { get; set; }
        #endregion

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

            #region Config media items
            builder.ApplyConfiguration(new MediaConfig());
            builder.Entity<Link>().HasBaseType<Media>();
            builder.Entity<Afbeelding>().HasBaseType<Media>();
            builder.Entity<Document>().HasBaseType<Media>();
            builder.Entity<Video>().HasBaseType<Media>();
            builder.ApplyConfiguration(new VideoConfig());
            builder.ApplyConfiguration(new AfbeeldingConfig());
            builder.ApplyConfiguration(new DocumentConfig());
            builder.ApplyConfiguration(new LinkConfig());
            #endregion

            #region Config Gebruiker objecten
            builder.ApplyConfiguration(new GebruikerConfig());
            builder.Entity<Verantwoordelijke>().HasBaseType<Gebruiker>();
            builder.ApplyConfiguration(new VerantwoordelijkeConfig());
            #endregion

            builder.ApplyConfiguration(new SessieGebruikerConfig());
            base.OnModelCreating(builder);
            
        }
    }
}
