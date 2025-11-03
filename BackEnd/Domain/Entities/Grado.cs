using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Grado
    {
        [Key]
        [Required(ErrorMessage = "El Id del grado es obligatorio")]
        public int IdGrado { get; set; }

        [Required(ErrorMessage = "El Id del colegio es obligatorio")]
        public int IdColegio { get; set; }

        [Required(ErrorMessage = "El nivel es obligatorio")]
        [StringLength(50, ErrorMessage = "El nivel no puede tener más de 50 caracteres")]
        public string Nivel { get; set; }  // Ejemplo: Inicial, Primaria o Secundaria

        [Required(ErrorMessage = "El nombre del grado es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre del grado no puede tener más de 50 caracteres")]
        public string NombreGrado { get; set; } // Ejemplo: 3ro de Secundaria

        [Required(ErrorMessage = "La sección es obligatoria")]
        [StringLength(10, ErrorMessage = "La sección no puede tener más de 10 caracteres")]
        public string Seccion { get; set; } // Ejemplo: A, B, C

        [Required(ErrorMessage = "El tutor es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre del tutor no puede tener más de 100 caracteres")]
        public string Tutor { get; set; } // Docente encargado

        public bool Estado { get; set; } // Activo o Inactivo


    }
}

