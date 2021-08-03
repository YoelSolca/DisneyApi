using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyApi.Entities
{
    [Table("PersonajePeliculaSerie", Schema = "dbo")]
    public class PersonajePeliculaSerie
    {
        public int FK_PersonajeID { get; set; }

        public int FK_PeliculaSerieID { get; set; }

        public Personaje Personaje { get; set; }

        public PeliculaSerie PeliculaSerie { get; set; }

    }
}
