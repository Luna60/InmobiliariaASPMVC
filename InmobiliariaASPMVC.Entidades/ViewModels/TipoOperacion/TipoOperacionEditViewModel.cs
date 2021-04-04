using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.ViewModels.TipoOperacion
{
    public class TipoOperacionEditViewModel
    {
        public int TipoOperacionId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Tipo de Operacion")]
        public string DescripcionTO { get; set; }

    }
}
