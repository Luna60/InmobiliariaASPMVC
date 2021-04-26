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
        [Display(Name = "Descripcion Propiedad")]
        public string DescripcionP { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo de Propiedad")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Tipo de Propiedad")]
        public int TipoPropiedadId { get; set; }
        //como tengo un Id de otra tabla, lo debo de apuntar a la tabla correspondiente
        public List<TipoPropiedadListViewModel> TipoPropiedad { get; set; }



        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo de Operacion")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Tipo de Operacion")]
        public int TipoOperacionId { get; set; }
        //como tengo un Id de otra tabla, lo debo de apuntar a la tabla correspondiente
        public List<TipoOperacionListViewModel> TipoOperacion { get; set; }



        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Cliente")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Cliente")]
        public int ClienteId { get; set; }
        //como tengo un Id de otra tabla, lo debo de apuntar a la tabla correspondiente
        public List<ClienteListViewModel> Cliente { get; set; }


        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Fecha Ingreso")]
        public DateTime FechaIngreso { get; set; }



        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Disponible")]
        public bool Disponible { get; set; }



        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Ambientes")]
        public int Ambientes { get; set; }


        [Display(Name = "Superficie de Terreno")]
        public int SuperficieTerreno { get; set; }


        [Display(Name = "Superficie Edificada")]
        public int SuperficieEdificada { get; set; }


        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }




        [Display(Name = "Departamento")]
        public string Departamento { get; set; }


        [Display(Name = "Jardin")]
        public bool Jardin { get; set; }

        [Display(Name = "Garage")]
        public bool Garage { get; set; }


        [Display(Name = "Cochera")]
        public string Cochera { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Localidad")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una Localidad")]
        public int LocalidadId { get; set; }
        //como tengo un Id de otra tabla, lo debo de apuntar a la tabla correspondiente
        public List<LocalidadListViewModel> Localidad { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Provincia")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una Provincia")]
        public int ProvinciaId { get; set; }
        //como tengo un Id de otra tabla, lo debo de apuntar a la tabla correspondiente
        public List<ProvinciaListViewModel> Provincia { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Costo de la Operacion")]
        public decimal CostoOperacion { get; set; }


        [Display(Name = "Observacion")]
        public string Observacion { get; set; }

        [Display(Name = "Imagen")]
        public string Imagen { get; set; }


    }
}
