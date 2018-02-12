using System.ComponentModel.DataAnnotations;

namespace Aplicacion_Meteorologia.Models
{
    public class Usuario
    {
        public string Id { get; set; }

        [Required]
        public string Password { get; set; }

        public string NombreCompleto { get; set; }
        public string Dni { get; set; }
        public string Localizacion { get; set; }
        public string Meteorologia { get; set; }
    }
}