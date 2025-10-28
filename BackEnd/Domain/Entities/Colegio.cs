using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Colegio
    {
        [Required(ErrorMessage = "El IdColegio es obligatorio")]
        public int IdColegio { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El RUC es obligatorio")]
        [StringLength(20, ErrorMessage = "El RUC no puede tener más de 20 caracteres")]
        public string RUC { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(150, ErrorMessage = "La dirección no puede tener más de 150 caracteres")]
        public string Direccion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(20, ErrorMessage = "El teléfono no puede tener más de 20 caracteres")]
        [Phone(ErrorMessage = "El teléfono no es válido")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es obligatorio")]
        [StringLength(80, ErrorMessage = "El email no puede tener más de 80 caracteres")]
        [EmailAddress(ErrorMessage = "El email no es válido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del director es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre del director no puede tener más de 100 caracteres")]
        public string Director { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool Estado { get; set; } = true;
    }
}
