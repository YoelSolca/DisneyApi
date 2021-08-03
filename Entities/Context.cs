using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyApi.Entities
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
        : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonajePeliculaSerie>()

           .HasKey(s => new { s.FK_PersonajeID, s.FK_PeliculaSerieID});

            modelBuilder.Entity<PeliculaSerieGenero>()

           .HasKey(s => new { s.FK_PeliculaSerieID, s.FK_GeneroID });

        }

        public DbSet<Personaje> Personaje { get; set; }
        public DbSet<PeliculaSerie> PeliculaSerie { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<PersonajePeliculaSerie> PersonajePeliculaSerie { get; set; }
        public DbSet<PeliculaSerieGenero> PeliculaSerieGenero { get; set; }
    }
}
