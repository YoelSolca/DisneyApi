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


            //Data
            modelBuilder.Entity<Personaje>().HasData(new Personaje
            {
                ID = 1,
                Imagen = "https://i.imgur.com/Zgi3edg.png",
                Nombre = "Winnie the Pooh",
                Edad = "95",
                Peso = "", 
                Historia = "",
            },
                new Personaje
                {
                    ID = 2,
                    Imagen = "https://i.imgur.com/RotLYaI.png",
                    Nombre = "Rayo McQueen",
                    Edad = "45",
                    Peso = "",
                    Historia = "",
                },  
                new Personaje
                {
                ID = 3,
                Imagen = "https://i.imgur.com/5M0XxkQ.jpg",
                Nombre = "James P. Sullivan",
                Edad = "30",
                Peso = "",
                Historia = "",
                },
                new Personaje
                {
                    ID = 4,
                    Imagen = "https://i.imgur.com/slzDY8A.png",
                    Nombre = "Dory",
                    Edad = "10",
                    Peso = "",
                    Historia = "",
                },
                 new Personaje
                 {
                     ID = 5,
                     Imagen = "https://i.imgur.com/t41xOG2.png",
                     Nombre = "Bolt",
                     Edad = "18",
                     Peso = "",
                     Historia = "",
                 },
                  new Personaje
                  {
                      ID = 6,
                      Imagen = "https://i.imgur.com/LPTOrA1.png",
                      Nombre = "Pumbaa",
                      Edad = "7",
                      Peso = "",
                      Historia = "",
                  },
                   new Personaje
                   {
                       ID = 7,
                       Imagen = "https://i.imgur.com/MyNomvq.png",
                       Nombre = "Mike Wazowski",
                       Edad = "28",
                       Peso = "",
                       Historia = "",
                   }
            );
        }

        public DbSet<Personaje> Personaje { get; set; }
        public DbSet<PeliculaSerie> PeliculaSerie { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<PersonajePeliculaSerie> PersonajePeliculaSerie { get; set; }
        public DbSet<PeliculaSerieGenero> PeliculaSerieGenero { get; set; }
    }
}
