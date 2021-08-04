using System;
using System.Collections.Generic;

namespace DisneyApi.Models
{
    public class PeliculaSerieDetallesDto
    {
        public int ID { get; set; }

        public string Imagen { get; set; }

        public string Titulo { get; set; }

        public DateTimeOffset FechaDeCreacion { get; set; }

        public string Calificacion { get; set; }

        public ICollection<PersonajePeliculaSerieDto> PersonajePeliculaSerie { get; set; }

    }
}
