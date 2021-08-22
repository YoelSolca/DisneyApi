
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace DisneyApi.Entities
{
    [Table("PeliculaSerie", Schema = "dbo")]
    public class PeliculaSerie
    {

        [Key]
        public int ID { get; set; }

        public string Imagen { get; set; }

        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; }

        [Required]
        public DateTimeOffset FechaDeCreacion { get; set; }

        [Required]
        [MaxLength(50)]
        public string Calificacion { get; set; }

        [ForeignKey("FK_PeliculaSerieID")]
        public ICollection<PersonajePeliculaSerie> PersonajePeliculaSerie { get; set; }

        [ForeignKey("FK_PeliculaSerieID")]
        public ICollection<PeliculaSerieGenero> PeliculaSerieGenero { get; set; }
    }
}
