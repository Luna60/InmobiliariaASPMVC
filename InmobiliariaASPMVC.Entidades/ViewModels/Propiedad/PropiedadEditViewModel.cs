using InmobiliariaASPMVC.Entidades.DTOs.Cliente;
using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using InmobiliariaASPMVC.Entidades.DTOs.TipoOperacion;
using InmobiliariaASPMVC.Entidades.DTOs.TipoPropiedad;
using InmobiliariaASPMVC.Entidades.ViewModels.Cliente;
using InmobiliariaASPMVC.Entidades.ViewModels.Localidad;
using InmobiliariaASPMVC.Entidades.ViewModels.Provincia;
using InmobiliariaASPMVC.Entidades.ViewModels.TipoOperacion;
using InmobiliariaASPMVC.Entidades.ViewModels.TipoPropiedad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.ViewModels.Propiedad
{
    public class PropiedadEditViewModel
    {
        public int PropiedadId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Descripcion")]
        public string DescripcionP { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }


        [DataType(DataType.ImageUrl)]
        public string Imagen { get; set; }


        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Cantidad de Ambientes")]
        public int Ambientes { get; set; }


        [MaxLength(10, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres")]
        [Display(Name = "Superficie de Terreno")]
        public int SuperficieTerreno { get; set; }


        [MaxLength(10, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres")]
        [Display(Name = "Superficie de Edificación")]
        public int SuperficieEdificada { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [MaxLength(20, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres")]
        [Display(Name = "Nro.Departamento")]
        public string Departamento { get; set; }


        [Display(Name = "Posee Jardin")]
        public bool Jardin { get; set; }



        [Display(Name = "Posee Garage")]
        public bool Garage { get; set; }


        [MaxLength(20, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres")]
        [Display(Name = "Posee Cochera")]
        public string Cochera { get; set; }


        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Costo de Operacion")]
        public decimal CostoOperacion { get; set; }


        [MaxLength(256, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres")]
        [Display(Name = "Observaciones")]
        public string Observacion { get; set; }

        [Display(Name = "Esta Disponible")]
        public bool Disponible { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Cliente")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Cliente")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo de Propiedad")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Tipo de Propiedad")]
        public int TipoPropiedadId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo de Operacion")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Tipo de Operación")]
        public int TipoOperacionId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Localidad")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una Localidad")]
        public int LocalidadId { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Provincia")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una Provincia")]
        public int ProvinciaId { get; set; }
        public List<ClienteListViewModel> Cliente { get; set; }
        public List<TipoPropiedadListViewModel> TipoPropiedad { get; set; }
        public List<TipoOperacionListViewModel> TipoOperacion { get; set; }
        public List<LocalidadListViewModel> Localidad { get; set; }
        public List<ProvinciaListViewModel> Provincia { get; set; }

    }
}
