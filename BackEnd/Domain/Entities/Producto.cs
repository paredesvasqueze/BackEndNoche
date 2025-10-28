using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Producto
    {
        [Required(ErrorMessage = "El Id es obligatorio")]
        public int Id { get; set; }


        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(250)]
        public string Descripcion { get; set; }

        [Range(0.01, 10000, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        [Range(0, 1000, ErrorMessage = "El stock debe ser al menos 0")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Debe Seleccionar una Categoria")]
        public int CategoriaId { get; set; }

        public string? cNombreCategoria { get; set; }

    }
}
