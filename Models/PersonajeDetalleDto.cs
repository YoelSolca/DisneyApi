using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyApi.Models
{
    public class PersonajeDetalleDto
    {
        public int ID { get; set; }

        public string Imagen { get; set; }
        public string Nombre { get; set; }

        public string Edad { get; set; }

        public string Peso { get; set; }

        public string Historia { get; set; }

        public ICollection<PersonajePeliculaSerieDto> PersonajePeliculaSerie { get; set; }
    }
}
