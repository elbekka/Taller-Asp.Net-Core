using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class GestorContext : DbContext
    {
        public GestorContext(DbContextOptions<GestorContext> options) : base(options)
        {

        }

        public DbSet<Programador> Programadores { get; set; }
        public DbSet<TipoProgramadores> TipoProgramadores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyEntityConfiguration();
            base.OnModelCreating(modelBuilder);
        }
    }
}
