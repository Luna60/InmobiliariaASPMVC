using InmobiliariaASPMVC.Entidades.ViewModels.Propiedad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.ViewModels.TipoPropiedad
{
    public class TipoPropiedadDetailsViewModel
    {
        public TipoPropiedadListViewModel TipoPropiedadListViewModel { get; set; }
        public List<PropiedadListViewModel> PropiedadesVm { get; set; }


    }
}
