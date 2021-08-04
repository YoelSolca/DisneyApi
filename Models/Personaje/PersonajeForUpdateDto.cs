using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyApi.Models
{
    public class PersonajeForUpdateDto
    {
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string Peso { get; set; }
        public string Historia { get; set; }
    }
}
