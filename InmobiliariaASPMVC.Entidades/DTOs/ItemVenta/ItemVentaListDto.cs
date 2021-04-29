using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.DTOs.ItemVenta
{
    public class ItemVentaListDto
    {
        public int ItemVentaId { get; set; }
        //public string Venta { get; set; }
        public string Propiedad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total => Propiedadd.CostoOperacion + PrecioUnitario;

        public PropiedadListDto Propiedadd;
    }
}
