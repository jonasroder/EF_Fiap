﻿using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(u => u.DataCriacao).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(u => u.DataNascimento).HasColumnType("DATETIME");
        }
    }
}
