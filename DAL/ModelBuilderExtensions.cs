using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder ApplyEntityConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new EntityConfiguration.EntityConfigurationProgrammers())
                .ApplyConfiguration(new EntityConfiguration.EntityConfigurationTypeProgrammers());
            return modelBuilder;
        }
    }
}
