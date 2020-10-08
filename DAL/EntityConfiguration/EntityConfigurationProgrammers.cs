using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Caching.Memory;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EntityConfiguration
{
    public class EntityConfigurationProgrammers : IEntityTypeConfiguration<Programador>
    {
        public void Configure(EntityTypeBuilder<Programador> builder)
        {

            builder.ToTable("Programadores", "Core");
            builder.HasKey(e => e.Id);

            builder
                .Property(item => item.Nombre)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(item => item.Apellido)
                .HasMaxLength(20)
                .IsRequired();
            builder
                .Property(item => item.DNI_NIE)
                .HasMaxLength(9)
                .IsRequired();
            builder
                .Property(item => item.Edad)
                .HasMaxLength(120)
                .IsRequired();

            builder
                .HasOne(item => item.TipoProgramador)
                .WithMany()
                .HasForeignKey(item => item.TipoProgramadorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasComment("Tabla de programadores");
            builder.Property(item => item.Apellido).HasComment("Apellido del progrador");
            builder.Property(item => item.TipoProgramadorId).HasComment("ID(PK) a tipo de programador");
        }
    }
}
