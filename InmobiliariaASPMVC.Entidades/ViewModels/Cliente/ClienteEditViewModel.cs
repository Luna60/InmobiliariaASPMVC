using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using InmobiliariaASPMVC.Entidades.DTOs.TipoDocumento;
using InmobiliariaASPMVC.Entidades.ViewModels.Localidad;
using InmobiliariaASPMVC.Entidades.ViewModels.Provincia;
using InmobiliariaASPMVC.Entidades.ViewModels.TipoDocumento;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.ViewModels.Cliente
{
    public class ClienteEditViewModel
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo de Documento")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Tipo de Documento")]
        public int TipoDocumentoId { get; set; }
        //como tengo un Id de otra tabla, lo debo de apuntar a la tabla correspondiente
        public List<TipoDocumentoListViewModel> TipoDocumento { get; set; }


        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "NroDocumento")]
        public string NroDocumento { get; set; }


        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Provincia")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una Provincia")]
        public int ProvinciaId { get; set; }
        //como tengo un Id de otra tabla, lo debo de apuntar a la tabla correspondiente
        public List<ProvinciaListViewModel> Provincia { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Localidad")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una Localidad")]
        public int LocalidadId { get; set; }
        //como tengo un Id de otra tabla, lo debo de apuntar a la tabla correspondiente
        public List<LocalidadListViewModel> Localidad { get; set; }


        [MaxLength(20, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres")]
        [Display(Name = "Telefono Fijo")]
        public string TelefonoFijo{ get; set; }


        [MaxLength(20, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres")]
        [Display(Name = "Telefono Movil")]
        public string TelefonoMovil { get; set; }


        [MaxLength(20, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres")]
        [Display(Name = "Email")]
        public string CorreoElectronico { get; set; }


    }
}
