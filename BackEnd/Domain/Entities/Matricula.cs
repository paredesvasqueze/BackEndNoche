using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Matricula
    {
        [Required(ErrorMessage = "El ID es obligatorio")]
        public int IdMatricula { get; set; }
        public int IdAlumno { get; set; }
        public int IdGrado { get; set; }
        public DateTime FechaMatricula { get; set; }
        public int AñoLectivo { get; set; }
        public bool Estado { get; set; }
    }
}