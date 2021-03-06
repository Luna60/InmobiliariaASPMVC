using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.ViewModels.ItemVenta
{
    public class ItemVentaListViewModel
    {
        public int ItemVentaId { get; set; }
        public string Propiedad { get; set; }

        [Display(Name = "Precio Unit.")]
        public decimal PrecioUnitario { get; set; }
        public decimal Valor { get; set; }
        public decimal Total => PrecioUnitario + Valor;
    }
}
