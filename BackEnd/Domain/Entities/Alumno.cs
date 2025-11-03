using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Alumno
    {
        [Key]
        [Required(ErrorMessage = "El Id del alumno es obligatorio")]
        public int IdAlumno { get; set; }

        [Required(ErrorMessage = "El Id del colegio es obligatorio")]
        public int IdColegio { get; set; }

        [Required(ErrorMessage = "Los nombres son obligatorios")]
        [StringLength(80, ErrorMessage = "Los nombres no pueden tener más de 80 caracteres")]
        public string Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(80, ErrorMessage = "Los apellidos no pueden tener más de 80 caracteres")]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "El DNI es obligatorio")]
        [StringLength(12, ErrorMessage = "El DNI no puede tener más de 12 caracteres")]
        public string DNI { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        [RegularExpression("^[MFmf]$", ErrorMessage = "El género debe ser 'M' o 'F'")]
        public char Genero { get; set; }

        [StringLength(150, ErrorMessage = "La dirección no puede tener más de 150 caracteres")]
        public string Direccion { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "El teléfono no puede tener más de 20 caracteres")]
        [Phone(ErrorMessage = "El formato del teléfono no es válido")]
        public string Telefono { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "El formato del correo no es válido")]
        [StringLength(80, ErrorMessage = "El correo no puede tener más de 80 caracteres")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool Estado { get; set; } = true;

        // Relación con la tabla Colegio
        //public Colegio? Colegio { get; set; }
    }
}