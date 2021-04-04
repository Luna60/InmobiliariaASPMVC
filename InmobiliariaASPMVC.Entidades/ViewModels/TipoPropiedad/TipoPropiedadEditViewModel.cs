using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.ViewModels.TipoPropiedad
{
    public class TipoPropiedadEditViewModel
    {
        public int TipoPropiedadId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Tipo de Propiedad")]
        public string DescripcionTP { get; set; }

    }
}
