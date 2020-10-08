using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Caching.Memory;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EntityConfiguration
{
    public class EntityConfigurationTypeProgrammers : IEntityTypeConfiguration<TipoProgramadores>
    {
        public void Configure(EntityTypeBuilder<TipoProgramadores> builder)
        {
            builder.ToTable("TipoProgramadores", "Masters");

            builder.HasKey(item => item.Id);

            builder
                .Property(item => item.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasData(TipoProgramadores.GetAll());
        }
    }
}
