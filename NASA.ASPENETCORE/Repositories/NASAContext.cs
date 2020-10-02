using Microsoft.EntityFrameworkCore;
using NASA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NASA.Repositories
{
    public class NASAContext : DbContext
    {
        public NASAContext(DbContextOptions<NASAContext> options) : base(options) { }

        public DbSet<Country> Countries {get; set;}
        public DbSet<Temperature> Temperatures {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            base.OnModelCreating(modelBuilder);
            // esto se escribe por cada relacion - es bidireccional
            modelBuilder.Entity<Temperature>().HasOne(e => e.Country).WithMany(e => e.Temperatures);
            // esto ahorra de escribir la anotacion key arriba, si hay muchas tablas queda muy largo
            modelBuilder.Entity<Country>().HasKey(e => e.CountryCode);
            // esto es para que le ponga el nombre que le paso por parámetro a la tabla
            modelBuilder.Entity<Temperature>().ToTable("temperature");


        }
    }
}
