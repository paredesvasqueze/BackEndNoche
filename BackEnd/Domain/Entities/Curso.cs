using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Curso
    {
        // Id en la tabla es IdCurso (IDENTITY). No marcamos Required para creación.
        public int IdCurso { get; set; } // mapeado desde IdCurso

        [Required(ErrorMessage = "Seleccione un grado")]
        public int IdGrado { get; set; }

        [Required(ErrorMessage = "El nombre del curso es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string NombreCurso { get; set; } // NombreCurso

        [Range(0, 40, ErrorMessage = "Horas semanales entre 0 y 40")]
        public int HorasSemanales { get; set; }

        [Required(ErrorMessage = "Seleccione un docente")]
        public int DocenteEncargado { get; set; }

        public bool Estado { get; set; } = true;

        // Propiedades auxiliares para visualización
        public string? NombreGrado { get; set; }
        public string? NombreDocente { get; set; }
    }
}