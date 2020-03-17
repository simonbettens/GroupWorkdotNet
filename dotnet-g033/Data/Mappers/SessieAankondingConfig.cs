﻿using dotnet_g033.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Data.Mappers
{
    public class SessieAankondingConfig : IEntityTypeConfiguration<SessieAankonding>
    {
        public void Configure(EntityTypeBuilder<SessieAankonding> builder)
        {
            builder.HasOne(sa => sa.Sessie).WithMany(s => s.Aankondingen).HasForeignKey(sa=>sa.SessieId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
