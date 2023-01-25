using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWProvincias_Valoroso.Models
{
    [Table("Ciudad")]
    public class Ciudad
    {
        [Key]
        public int IdCiudad { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        
        
        public int ProvinciaId { get; set; }
        [ForeignKey("ProvinciaId")]
        public Provincia Provincia { get; set; }

    }
}
