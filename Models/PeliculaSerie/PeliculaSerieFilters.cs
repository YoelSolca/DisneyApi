using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyApi.Models.PeliculaSerie
{
    public class PeliculaSerieFilters
    {
        public string Titulo { get; set; }

        public string CampoOrdenar { get; set; }

        public bool OrdenAscendente { get; set; }
    }
}
