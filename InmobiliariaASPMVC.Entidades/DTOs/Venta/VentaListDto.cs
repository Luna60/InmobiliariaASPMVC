using InmobiliariaASPMVC.Entidades.DTOs.ItemVenta;
using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.DTOs.Venta
{
    public class VentaListDto
    {
        public int VentaId { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaVenta { get; set; }
        //public decimal Total { get; set; }
        //public decimal Total => Propiedad.CostoOperacion + IVentas.PrecioUnitario;

        public List<ItemVentaListDto> ItemVentas { get; set; } = new List<ItemVentaListDto>();
        //public PropiedadListDto Propiedad;
        //public ItemVentaListDto IVentas;

    }
}
