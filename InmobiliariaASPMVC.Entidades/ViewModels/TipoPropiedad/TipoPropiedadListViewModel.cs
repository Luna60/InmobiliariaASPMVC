using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.ViewModels.TipoPropiedad
{
    public class TipoPropiedadListViewModel
    {
        public int TipoPropiedadId { get; set; }

        [Display(Name = "Tipo de Propiedad")]
        public string DescripcionTP { get; set; }

    }
}
