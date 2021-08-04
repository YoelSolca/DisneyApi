using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyApi.Models.PeliculaSerie
{
    public class PeliculaSerieForCreationDto
    {
        public string Imagen { get; set; }
  
        public string Titulo { get; set; }

        public DateTimeOffset FechaDeCreacion { get; set; } = DateTime.Now;

        public string Calificacion { get; set; }
    }
}
