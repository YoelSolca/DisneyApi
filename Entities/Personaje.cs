
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DisneyApi.Entities
{
    [Table("Persona", Schema= "dbo")]
    public class Personaje
    {
        [Key]
        public int ID { get; set; }

        public string Imagen { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(3)]
        public string Edad { get; set; }

        [Required]
        [MaxLength(50)]
        public string Peso { get; set; }

        [Required]
        [MaxLength(500)]
        public string Historia { get; set; }

        [ForeignKey("FK_PersonajeID")]
        public ICollection<PersonajePeliculaSerie> PersonajePeliculaSerie { get; set; }

    }
}
