using InmobiliariaASPMVC.Entidades.ViewModels.ItemVenta;
using InmobiliariaASPMVC.Entidades.ViewModels.Propiedad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.ViewModels.Carrito
{
    public class ItemCarritoListViewModel
    {
        public PropiedadListViewModel PropiedadListViewModel { get; set; }
        public decimal Valor { get; set; }

    }
}
