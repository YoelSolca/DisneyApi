using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisneyApi.Entities
{
    [Table("Genero", Schema="dbo")]
    public class Genero
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        public string Imagen { get; set; }

        [ForeignKey("FK_GeneroID")]
        public ICollection<PeliculaSerieGenero> PeliculaSerieGenero { get; set; }
    }
}
