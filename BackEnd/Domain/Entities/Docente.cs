using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Docente
    {
        [Required(ErrorMessage = "El Id del docente es obligatorio")]
        public int IdDocente { get; set; }

        [Required(ErrorMessage = "El Id del colegio es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un colegio válido")]
        public int IdColegio { get; set; }

        [Required(ErrorMessage = "Los nombres son obligatorios")]
        [StringLength(80)]
        [RegularExpression(@"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$", ErrorMessage = "Solo letras")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(80)]
        [RegularExpression(@"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$", ErrorMessage = "Solo letras")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El DNI es obligatorio")]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Debe tener 8 dígitos")]
        public string DNI { get; set; }

        [EmailAddress(ErrorMessage = "Correo no válido")]
        [StringLength(80)]
        public string Email { get; set; }

        [RegularExpression(@"^9[0-9]{8}$", ErrorMessage = "Debe tener 9 dígitos y empezar con 9")]
        public string Telefono { get; set; }

        [StringLength(100)]
        [RegularExpression(@"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$", ErrorMessage = "Solo letras")]
        public string Especialidad { get; set; }

        [Required(ErrorMessage = "Fecha de ingreso obligatoria")]
        public DateTime FechaIngreso { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
