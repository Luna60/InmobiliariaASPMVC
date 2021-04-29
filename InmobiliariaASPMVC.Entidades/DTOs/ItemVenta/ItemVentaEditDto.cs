using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.DTOs.ItemVenta
{
    public class ItemVentaEditDto
    {
        public int ItemVentaId { get; set; }
        public int VentaId { get; set; }
        public PropiedadListDto Propiedad { get; set; }
        public decimal Total { get; set; }
        public decimal PrecioUnitario { get; set; }

    }
}
