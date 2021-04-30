using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.Entidades
{
    public class ItemVenta
    {
        public int ItemVentaId { get; set; }
        public int VentaId { get; set; }
        public int PropiedadId { get; set; }
        public decimal Valor { get; set; }
        public decimal PrecioUnitario { get; set; }

        public Venta Venta { get; set; }
        public Propiedad Propiedad { get; set; }

       
    }
}
