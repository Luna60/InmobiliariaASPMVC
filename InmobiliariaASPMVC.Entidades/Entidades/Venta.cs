using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.Entidades
{
    public class Venta
    {
        public int VentaId { get; set; }
        public DateTime FechaVenta { get; set; }
        //public ModalidadVenta ModalidadVenta { get; set; }
        //public EstadoVenta EstadoVenta { get; set; }
        public List<ItemVenta> ItemVentas { get; set; } = new List<ItemVenta>();

    }
}
