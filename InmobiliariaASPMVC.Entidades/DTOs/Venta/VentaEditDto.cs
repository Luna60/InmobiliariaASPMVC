using InmobiliariaASPMVC.Entidades.DTOs.ItemVenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.DTOs.Venta
{
    public class VentaEditDto
    {
        public int VentaId { get; set; }
        public DateTime FechaVenta { get; set; }
        //public ModalidadVenta ModalidadVenta { get; set; }
        //public EstadoVenta EstadoVenta { get; set; }
        public List<ItemVentaEditDto> ItemVentas { get; set; } = new List<ItemVentaEditDto>();

    }
}
