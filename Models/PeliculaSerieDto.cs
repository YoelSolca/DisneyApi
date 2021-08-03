using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyApi.Models
{
    public class PeliculaSerieDto
    {
        public int ID { get; set; }


        public string Imagen { get; set; }

        public string Titulo { get; set; }

        public DateTimeOffset FechaDeCreacion { get; set; }

        public string Calificacion { get; set; }
    }
}
