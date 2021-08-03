using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyApi.Entities
{
    [Table("PeliculaSerieGenero", Schema = "dbo")]
    public class PeliculaSerieGenero
    {
        public int FK_PeliculaSerieID { get; set; }
        public int FK_GeneroID { get; set; }

        public PeliculaSerie PeliculaSerie { get; set; }

        public Genero Genero { get; set; }

    }
}
