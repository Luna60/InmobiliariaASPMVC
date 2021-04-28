using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.ViewModels.Carrito
{
    public class CarritoListViewModel
    {
        public List<ItemCarritoListViewModel> Items { get; set; }
        public string ReturnUrl { get; set; }

    }
}
