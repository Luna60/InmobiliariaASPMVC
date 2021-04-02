using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.ViewModels.Propiedad
{
    public class PropiedadListViewModel
    {
        public int PropiedadId { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        [Display(Name = "Disponible")]
        public bool Disponible { get; set; }

        [Display(Name = "Tipos de Propiedades")]
        public string TipoPropiedad { get; set; }

        [Display(Name = "Tipos de Operaciones")]
        public string TipoOperacion { get; set; }

        [Display(Name = "Localidades")]
        public string Localidad { get; set; }

        [Display(Name = "Provincias")]
        public string Provincia { get; set; }

    }
}
