using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.ViewModels.Provincia
{
    public class ProvinciaEditViewModel
    {
        public int ProvinciaId { get; set; }
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(50,ErrorMessage ="El campo {0} edbe tener entre {2} y {1} caracteres",MinimumLength = 3)]
        [Display(Name = "Provincias")]
        public string NombreProvincia { get; set; }

    }
}
