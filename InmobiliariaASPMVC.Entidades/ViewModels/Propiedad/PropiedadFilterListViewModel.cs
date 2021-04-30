using InmobiliariaASPMVC.Entidades.ViewModels.TipoPropiedad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.ViewModels.Propiedad
{
    public class PropiedadFilterListViewModel
    {
        public List<PropiedadListViewModel> Propiedad { get; set; }
        public List<TipoPropiedadListViewModel> TipoPropiedad { get; set; }

    }
}
