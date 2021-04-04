using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using InmobiliariaASPMVC.Entidades.ViewModels.Provincia;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.ViewModels.Localidad
{
    public class LocalidadEditViewModel
    {
        public int LocalidadId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Localidad")]
        public string NombreLocalidad { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Provincia")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una Provincia")]
        public int ProvinciaId { get; set; }
        //como tengo un Id de otra tabla, lo debo de apuntar a la tabla correspondiente
        public List<ProvinciaListViewModel> Provincia { get; set; }

    }
}
